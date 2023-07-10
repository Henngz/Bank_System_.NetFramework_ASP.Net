using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using BankOfBIT_YZ.Data;
using BankOfBIT_YZ.Models;
using System.Xml;
using Utility;
using System.Globalization;
using WindowsBanking.TransactionManagerServiceReference;

namespace WindowsBanking
{
    public class Batch
    {
        /// <summary>
        /// The name of the xml input file.
        /// </summary>
        private String inputFileName;

        /// <summary>
        /// The name of the log file.
        /// </summary>
        private String logFileName;

        /// <summary>
        /// The data to be written to the log file.
        /// </summary>
        private String logData;

        // Declare an instance of BankOfBIT_YZ database.
        BankOfBIT_YZContext db = new BankOfBIT_YZContext();

        /// <summary>
        /// This method will process all detail errors found within the current file being processed.
        /// </summary>
        /// <param name="beforeQuery">represents the records that existed before the round of validation.</param>
        /// <param name="afterQuery">represents the records that remained following the round of validation.</param>
        /// <param name="message">represents the error message that is to be written to the log file based on the record(s) failing the round of validation.</param>
        private void ProcessErrors(IEnumerable<XElement> beforeQuery, IEnumerable<XElement> afterQuery, String message)
        {
            IEnumerable<XElement> errors = beforeQuery.Except(afterQuery);

            foreach(XElement record in errors)
            {
                logData += "\r\n------ERROR------";
                logData += "\r\nFile: " + inputFileName;
                logData += "\r\nInstitution: " + record.Element("institution");
                logData += "\r\nAccount Number: " + record.Element("account_no");
                logData += "\r\nTransaction Type: " + record.Element("type");
                logData += "\r\nAmount: " + record.Element("amount");
                logData += "\r\nNotes: " + record.Element("notes");
                logData += "\r\nNodes: " + record.Elements().Nodes().Count();
                logData += "\r\n" + message + "\r\n";
            }        
        }

        /// <summary>
        /// This method is used to verify the attributes of the xml file’s root element.
        /// </summary>
        private void ProcessHeader()
        {
            XDocument xDocument = XDocument.Load(inputFileName);

            XElement root = xDocument.Element("account_update");

            // Check attribute count
            if(root.Attributes().Count() != 3)
            {
                int attributesNumber = root.Attributes().Count();

                throw new Exception(String.Format("\r\nERROR: Root attributes number: " + "{0} in file {1} is incorrect.\r\n"
                                                , attributesNumber, inputFileName));
            }

            //Check date
            if (!DateTime.Parse(root.Attribute("date").Value)
                .Equals(DateTime.Today))
            {
                throw new Exception(String.Format("\r\nERROR: Date: " + "{0} in file {1} is invalid.\r\n"
                                                , root.Attribute("date").Value, inputFileName));
            }

            //Check institution
            int institutionAttribute = int.Parse(root.Attribute("institution").Value);

            Institution institution = db.Institutions.
                                        Where(x => x.InstitutionNumber == institutionAttribute).
                                        SingleOrDefault();

            if (institution == null)
            {
                throw new Exception(String.Format("\r\nERROR: Institution: " + "{0} in file {1} does not exist.\r\n"
                                                , institutionAttribute, inputFileName));
            }

            //Check checksum
            int accountnoSum = 0;

            IEnumerable<XElement> account_noElements = xDocument.Descendants().
                                                                Where(d => d.Name == "account_no");

            foreach (XElement xele in account_noElements)
            {
                accountnoSum += int.Parse(xele.Value);
            }

            if(int.Parse(root.Attribute("checksum").Value) != accountnoSum)
            {
                throw new Exception(String.Format("\r\nERROR: The checksum: " + "{0} in file {1} is invalid.\r\n"
                                                , root.Attribute("checksum").Value, inputFileName));
            }
        }

        /// <summary>
        /// This method is used to verify the contents of the detail records in the input file.
        /// </summary>
        private void ProcessDetails()
        {
            XDocument xDocument = XDocument.Load(inputFileName);

            XElement root = xDocument.Element("account_update");

            IEnumerable<XElement> totalTransactions = xDocument.Descendants().
                                                                Where(d => d.Name == "transaction");

            // Get child elements of valid transactions
            IEnumerable<XElement> childElementsOfTransactions = totalTransactions.
                                                                Where(x => x.Elements().Nodes().Count() == 5);

            ProcessErrors(totalTransactions, childElementsOfTransactions, "Incorrect number of Child Elements of Transactions.\r\n");

            // Get transaction elements whose institution node matches the institution attribute of the root element
            IEnumerable<XElement> validInstitutionTransactions = childElementsOfTransactions.
                                                       Where(x => int.Parse(x.Element("institution").Value).Equals(int.Parse(root.Attribute("institution").Value)));

            ProcessErrors(childElementsOfTransactions, validInstitutionTransactions, "Incorrect Institution Number\r\n");

            // Get transaction elements whose type and amount nodes are numeric.
            IEnumerable<XElement> validTypeAmountTransactions = validInstitutionTransactions.
                                                       Where(x => Utility.Numeric.IsNumeric(x.Element("type").Value, NumberStyles.Integer) == true 
                                                                && Utility.Numeric.IsNumeric(x.Element("amount").Value, NumberStyles.Float) == true);
            ProcessErrors(validInstitutionTransactions, validTypeAmountTransactions, "Invalid data type of the Type or Amount number of Transactions\r\n");

            // Get transaction node must have a value of 2 or 6.
            IEnumerable<XElement> validType2or6Transactions = validTypeAmountTransactions.
                                                      Where(x => int.Parse(x.Element("type").Value) == 2 
                                                            || int.Parse(x.Element("type").Value) == 6);

            ProcessErrors(validTypeAmountTransactions, validType2or6Transactions, "Invalid Type Number of Transactions.\r\n");

            // Get transaction elements whose type node is 6 AND amount node is 0,
            // OR whose type node is 2 AND amount node is greater than 0.
            IEnumerable<XElement> matchTypeTransactions = validType2or6Transactions.
                                                     Where(x => (int.Parse(x.Element("type").Value) == 6 && double.Parse(x.Element("amount").Value) == 0) 
                                                           || (int.Parse(x.Element("type").Value) == 2 && double.Parse(x.Element("amount").Value) > 0));

            ProcessErrors(validType2or6Transactions, matchTypeTransactions, "Transactions with Type Number with unmatch Amount.\r\n");

            // Get error free records.
            IEnumerable<long> accountNumber = db.BankAccounts.
                                            Select(x => x.AccountNumber).ToList();

            IEnumerable<XElement> errorFreeTransactions = matchTypeTransactions.
                                                     Where(x => accountNumber.Contains(long.Parse(x.Element("account_no").Value)));

            ProcessErrors(matchTypeTransactions, errorFreeTransactions, "Acount_no does not exist.\r\n");

            ProcessTransactions(errorFreeTransactions);

        }

        /// <summary>
        /// This method is used to process all valid transaction records.
        /// </summary>
        /// <param name="transactionRecords">all valid transaction records</param>
        private void ProcessTransactions(IEnumerable<XElement> transactionRecords)
        {
            foreach(XElement record in transactionRecords)
            {
                long accountNumber = long.Parse(record.Element("account_no").Value);
                double amount = double.Parse(record.Element("amount").Value);
                string notes = record.Element("notes").Value;

                BankAccount bankAccount = db.BankAccounts.
                                                Where(x => x.AccountNumber == accountNumber).
                                                SingleOrDefault();

                int accountId = bankAccount.BankAccountId;

                TransactionManagerClient transactionManagerClient = new TransactionManagerClient();

                if (int.Parse(record.Element("type").Value) == 2)
                {                   
                    double? newBalance =(double?) transactionManagerClient.Withdrawal(accountId, amount, notes);

                    if(newBalance != null)
                    {
                        logData += "\r\nTransaction completed successfully: Withdrawal - " + amount + " applied to account " + accountNumber + " .\r\n";
                    }
                    else
                    {
                        logData += "\r\nTransaction completed unsuccessfully.\r\n";
                    }

                }

                if(int.Parse(record.Element("type").Value) == 6)
                {
                    double? interests = (double?)transactionManagerClient.CalculateInterest(accountId, notes);

                    if (interests != null)
                    {
                        logData += "\r\nTransaction completed successfully: Interest - " + interests + " applied to account " + accountNumber + " .\r\n";
                    }
                    else
                    {
                        logData += "\r\nTransaction completed unsuccessfully.\r\n";
                    }
                }
            }
        }

        /// <summary>
        /// This method is to write log data to a text file.
        /// </summary>
        /// <returns></returns>
        public String WriteLogData()
        {
            String fullLogData = "";
            fullLogData += logData;

            StreamWriter sw = new StreamWriter(logFileName);
            sw.WriteLine(logData);
            sw.Close();

            logData = String.Empty;
            inputFileName = String.Empty;

            return fullLogData;
        }

        /// <summary>
        /// This method will initiate the batch process by determining the appropriate filename 
        /// and then proceeding with the header and detail processing.
        /// </summary>
        /// <param name="institution">Represent institution number</param>
        /// <param name="key"></param>
        public void ProcessTransmission(String institution, String key)
        {
            try
            {
                //Formulate the value for the inputFileName
                DateTime currentDate = DateTime.Today;

                String dayOfYear = currentDate.DayOfYear.ToString();

                String currentYear = DateTime.Now.Year.ToString();

                inputFileName = currentYear + "-" + dayOfYear + "-" + institution + ".xml";

                //Formulate logFileName that is to represent the name of the log file
                logFileName = "LOG " + currentYear + "-" + dayOfYear + "-" + institution + ".txt";

                //Check the existence of the inputfile
                if (File.Exists(inputFileName))
                {
                    ProcessHeader();
                    ProcessDetails();
                }
                else
                {
                    logData += "\r\nERROR: " + inputFileName + " doesn't exist\r\n";
                }
            }
            catch (Exception ex)
            {
                logData += ex.Message + "\r\n";
            }
        }
    }
}
