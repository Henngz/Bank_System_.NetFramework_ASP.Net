using BankOfBIT_YZ.Data;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using Utility;
using static System.Net.Mime.MediaTypeNames;


namespace BankOfBIT_YZ.Models
{
    /// <summary>
    /// Client Model - to represent Clinets table in database
    /// </summary>
    public class Client
    {
        // ClientId automatically generated as an identity field.
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        // ClientNumber ClientNumber is require and the value must be within the range of 10000000 and 99999999.
        [Display(Name = "Client\nNumber")]
        public long ClientNumber { get; set; }

        // FirstName is required and data must be between 1 and 35 characters.       
        [Required]
        [Display(Name = "First\nName")]
        [StringLength(35, MinimumLength = 1)]
        public String FirstName { get; set; }

        // LastName is required and the data must be between 1 and 35 characters
        [Required]
        [Display(Name = "Last\nName")]
        [StringLength(35, MinimumLength = 1)]
        public String LastName { get; set; }

        // Address is required and the data must be between 1 and 35 characters
        [Required]
        [StringLength(35, MinimumLength = 1)]
        public String Address { get; set; }

        // City is required and the data must be between 1 and 35 characters
        [Required]
        [StringLength(35, MinimumLength = 1)]
        public String City { get; set; }

        // Limit user to only Canadian province codes
        [Required]
        [RegularExpression("^(N[BLSTU]|[AMN]B|[BQ]C|ON|PE|SK|YT)")]
        public String Province { get; set; }

        // Use "{0:d}" for short date format 
        [Required]
        [Display(Name = "Date\nCreated")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateCreated { get; set; }

        public String Notes { get; set; }

        // The Heading/Label for FullName is “Name”.
        [Display(Name = "Name")]
        public String FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        // The Heading/Label for FullAddress is “Address”
        [Display(Name = "Address")]
        public String FullAddress
        {
            get
            {
                return String.Format("{0} {1} {2}", Address, City, Province);
            }
        }

        //Represents a 0 or many relationship
        public virtual ICollection<BankAccount> BankAccount { get; set; }

        /// <summary>
        /// The method is to set NextClientNumber by using StoredProcedure.NextNumber method.
        /// </summary>
        public void SetNextClientNumber()
        {
            long? nextClientNumber = StoredProcedure.NextNumber("NextClient");

            if (nextClientNumber != null)
            {
                this.ClientNumber = (long)nextClientNumber;
            }
        }
    }

    /// <summary>
    /// AccountState Model - to represent  AccountStates table in database
    /// </summary>
    public abstract class AccountState
    {
        // AccountStateId will be automatically generated as an identity field.
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AccountStateId { get; set; }

        // LowerLimit is required and should be displayed to 2 decimal places in currency format
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C2}")]
        [Display(Name = "Lower\nLimit")]
        public double LowerLimit { get; set; }

        // UpperLimit is required and should be displayed to 2 decimal places in currency format
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C2}")]
        [Display(Name = "Upper\nLimit")]
        public double UpperLimit { get; set; }

        // Rate is required and should be displayed to 2 decimal places in currency format
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:p2}")]
        public double Rate { get; set; }

        // This is used to get account state of accounts.
        [Display(Name = "Account\nState")]
        public String Description
        {
            get
            {
                return BusinessRules.GetStateOrSubtype(this.GetType().Name);
            }
        }

        // Define a protected static variable of your data context object
        // so that the following can be achieved in each of the derived classes.
        protected static BankOfBIT_YZContext db = new BankOfBIT_YZContext();

        // Represents a 0 or many relationship
        public virtual ICollection<BankAccount> BankAccount { get; set; }

        /// <summary>
        /// This abstract method is to check if need to change the bank account's state.
        /// </summary>
        /// <param name="bankAccount"></param>
        public abstract void StateChangeCheck(BankAccount bankAccount);

        /// <summary>
        /// This abstract method is to adjust rate for different account state. 
        /// </summary>
        /// <param name="bankAccount">Parameter is bankAccount</param>
        /// <returns>Return interest rate</returns>
        public abstract double RateAdjustment(BankAccount bankAccount);
    }

    /// <summary>
    /// BronzeState Model - to represent BronzeStates table in database
    /// </summary>
    public class BronzeState : AccountState
    {
        // Field
        private static BronzeState bronzeState;

        /// <summary>
        /// This is a method to construct object of BronzeState class.
        /// </summary>
        private BronzeState()
        {
            LowerLimit = 0;

            UpperLimit = 5000;

            Rate = 0.01;
        }

        /// <summary>
        /// This method is to get an instance of SronzeState if there is no record then it will generate a new one.
        /// </summary>
        /// <returns>Return an instance of BronzeState</returns>
        public static BronzeState GetInstance()
        {
            if (bronzeState == null)
            {
                bronzeState = db.BronzeStates.SingleOrDefault();

                if (bronzeState == null)
                {
                    bronzeState = new BronzeState();

                    db.BronzeStates.Add(bronzeState);

                    db.SaveChanges();
                }
            }
            return bronzeState;
        }

        /// <summary>
        /// This method is to check if need to change the bank account's state.
        /// </summary>
        /// <param name="bankAccount">Parameter is bankAccount.</param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (bankAccount.Balance > UpperLimit)
            {
                bankAccount.AccountStateId = SilverState.GetInstance().AccountStateId;

                db.SaveChanges();
            }
        }

        /// <summary>
        /// This abstract method is to adjust rate for different account state. 
        /// </summary>
        /// <param name="bankAccount">Parameter is bankAccount</param>
        /// <returns>Return interest rate</returns>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            double newRate = 0;

            if (bankAccount.Balance <= 0)
            {
                newRate = 0.055;
            }
            else
            {
                newRate = Rate;
            }

            return newRate;
        }
    }

    /// <summary>
    /// SilverState Model - to represent SilverStates table in database
    /// </summary>
    public class SilverState : AccountState
    {
        // Field
        private static SilverState silverState;

        /// <summary>
        /// This is a method to construct object of SilverState class.
        /// </summary>
        private SilverState()
        {
            LowerLimit = 5000;

            UpperLimit = 10000;

            Rate = 0.0125;
        }

        /// <summary>
        /// This method is to get an instance of SilverState if there is no record then it will generate a new one.
        /// </summary>
        /// <returns>Return an instance of SilverState</returns>
        public static SilverState GetInstance()
        {
            if (silverState == null)
            {
                silverState = db.SilverStates.SingleOrDefault();

                if (silverState == null)
                {
                    silverState = new SilverState();

                    db.SilverStates.Add(silverState);

                    db.SaveChanges();
                }
            }
            return silverState;
        }

        /// <summary>
        /// This method is to check if need to change the bank account's state.
        /// </summary>
        /// <param name="bankAccount">Parameter is bankAccount.</param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (bankAccount.Balance > UpperLimit)
            {
                bankAccount.AccountStateId = GoldState.GetInstance().AccountStateId;

                db.SaveChanges();
            }
            else if (bankAccount.Balance < LowerLimit)
            {
                bankAccount.AccountStateId = BronzeState.GetInstance().AccountStateId;

                db.SaveChanges();
            }
        }

        /// <summary>
        /// This abstract method is to adjust rate for different account state. 
        /// </summary>
        /// <param name="bankAccount">Parameter is bankAccount</param>
        /// <returns>Return interest rate</returns>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            return Rate;
        }
    }
    /// <summary>
    /// GoldState Model - to represent GoldStates table in database
    /// </summary>
    public class GoldState : AccountState
    {
        // Field
        private static GoldState goldState;

        /// <summary>
        /// This is a method to construct object of GoldState class.
        /// </summary>
        private GoldState()
        {
            LowerLimit = 10000;

            UpperLimit = 20000;

            Rate = 0.02;
        }

        /// <summary>
        /// This method is to get an instance of GoldSronzeState if there is no record then it will generate a new one.
        /// </summary>
        /// <returns>Return an instance of GoldState</returns>
        public static GoldState GetInstance()
        {
            if (goldState == null)
            {
                goldState = db.GoldStates.SingleOrDefault();

                if (goldState == null)
                {
                    goldState = new GoldState();

                    db.GoldStates.Add(goldState);

                    db.SaveChanges();
                }
            }
            return goldState;
        }

        /// <summary>
        /// This method is to check if need to change the bank account's state.
        /// </summary>
        /// <param name="bankAccount">Parameter is bankAccount.</param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (bankAccount.Balance > UpperLimit)
            {
                bankAccount.AccountStateId = PlatinumState.GetInstance().AccountStateId;

                db.SaveChanges();
            }
            else if (bankAccount.Balance < LowerLimit)
            {
                bankAccount.AccountStateId = SilverState.GetInstance().AccountStateId;

                db.SaveChanges();
            }
        }

        /// <summary>
        /// This abstract method is to adjust rate for different account state. 
        /// </summary>
        /// <param name="bankAccount">Parameter is bankAccount</param>
        /// <returns>Return interest rate</returns>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            double newRate = 0;

            DateTime currentDate = DateTime.Now;

            DateTime over10YearsDate = bankAccount.DateCreated.AddYears(10);

            if (currentDate >= over10YearsDate)
            {
                newRate = Rate + 0.01;
            }
            else
            {
                newRate = Rate;
            }
            return newRate;
        }
    }

    /// <summary>
    /// PlatinumState Model - to represent PlatinumStates table in database
    /// </summary>
    public class PlatinumState : AccountState
    {
        // Field
        private static PlatinumState platinumState;

        /// <summary>
        /// This is a method to construct object of PlatinumState class.
        /// </summary>
        private PlatinumState()
        {
            LowerLimit = 20000;

            UpperLimit = 0;

            Rate = 0.025;
        }

        /// <summary>
        /// This method is to get an instance of PlatinumState if there is no record then it will generate a new one.
        /// </summary>
        /// <returns>Return an instance of PlatinumState</returns>
        public static PlatinumState GetInstance()
        {
            if (platinumState == null)
            {
                platinumState = db.PlatinumStates.SingleOrDefault();

                if (platinumState == null)
                {
                    platinumState = new PlatinumState();

                    db.PlatinumStates.Add(platinumState);

                    db.SaveChanges();
                }
            }
            return platinumState;
        }

        /// <summary>
        /// This method is to check if need to change the bank account's state.
        /// </summary>
        /// <param name="bankAccount">Parameter is bankAccount.</param>
        public override void StateChangeCheck(BankAccount bankAccount)
        {
            if (bankAccount.Balance < LowerLimit)
            {
                bankAccount.AccountStateId = GoldState.GetInstance().AccountStateId;

                db.SaveChanges();
            }
        }

        /// <summary>
        /// This abstract method is to adjust rate for different account state. 
        /// </summary>
        /// <param name="bankAccount">Parameter is bankAccount</param>
        /// <returns>Return interest rate</returns>
        public override double RateAdjustment(BankAccount bankAccount)
        {
            double newRate = 0;

            DateTime currentDate = DateTime.Now;

            DateTime over10YearsDate = bankAccount.DateCreated.AddYears(10);

            if (bankAccount.Balance > 2 * LowerLimit && currentDate >= over10YearsDate)
            {
                newRate = Rate + 0.005 + 0.01;
            }
            else if (currentDate > over10YearsDate)
            {
                newRate = Rate + 0.01;
            }
            else if (bankAccount.Balance > 2 * LowerLimit)
            {
                newRate = Rate + 0.005;
            }
            else
            {
                newRate = Rate;
            }
            return newRate;
        }
    }

    /// <summary>
    /// BankAccount Model - to represent BankAccounts table in database
    /// </summary>
    public abstract class BankAccount
    {
        // BankAccountId is primary key
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BankAccountId { get; set; }

        // ClinetId is a foreign key
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        // AccountStateId is a foreign key
        [ForeignKey("AccountState")]
        public int AccountStateId { get; set; }

        // AccountNumber is required
        [Display(Name = "Account\nNumber")]
        public long AccountNumber { get; set; }

        // Balance is required and should be displayed to 2 decimal places in currency format
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C2}")]
        public double Balance { get; set; }

        // Use "{0:d}" for short date format 
        [Required]
        [Display(Name = "Date\nCreated")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateCreated { get; set; }

        public String Notes { get; set; }

        // This is to get the subtype of accounts.
        public String Description
        {
            get
            {
                return BusinessRules.GetStateOrSubtype(this.GetType().Name);
            }
        }

        //Define a private instance of the Data Context class.
        private BankOfBIT_YZContext db = new BankOfBIT_YZContext();

        //represents a 1 relationship on class diagram
        public virtual Client Client { get; set; }

        public virtual AccountState AccountState { get; set; }

        //Represents a 0 or many relationship
        public virtual ICollection<Transaction> Transaction { get; set; }

        /// <summary>
        /// This method is to change state if the balance of bank account changed
        /// </summary>
        public void ChangeState()
        {
            AccountState oldRecord = db.AccountStates.Find(AccountStateId);
            AccountState newRecord = null;

            while (newRecord != oldRecord)
            {
                newRecord = oldRecord;

                oldRecord.StateChangeCheck(this);

                oldRecord = db.AccountStates.Find(AccountStateId);
            }
        }

        /// <summary>
        /// This is an abstrat method which is used to set next account number.
        /// </summary>
        public abstract void SetNextAccountNumber();
        
    }

    /// <summary>
    /// SavingsAccount Model - to represent SavingsAccounts table in database
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        //SavingsServiceCharges is required and should be displayed to 2 decimal places in currency
        //format
        [Required]
        [Display(Name = "Savings\nService\nCharges")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c2}")]
        public double SavingsServiceCharges { get; set; }

        /// <summary>
        /// This method overrides the abstract SetNextAccountNumber from super class.
        /// </summary>
        public override void SetNextAccountNumber()
        {
            long? nextSavingsAccountNumber = StoredProcedure.NextNumber("NextSavingsAccount");

            if (nextSavingsAccountNumber != null)
            {
                this.AccountNumber = (long)nextSavingsAccountNumber;
            }           
        }
    }

    /// <summary>
    /// MortgageAccount Model - to represent MortgageAccounts table in database
    /// </summary>
    public class MortgageAccount : BankAccount
    {
        //SavingsServiceCharges is required and should be displayed to 2 decimal places in percent format.
        [Required]
        [Display(Name = "Mortgage\nRate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:p2}")]
        public double MortgageRate { get; set; }

        // Amortization is required.
        [Required]
        public int Amortization { get; set; }

        /// <summary>
        /// This method overrides the abstract SetNextAccountNumber from super class.
        /// </summary>
        public override void SetNextAccountNumber()
        {
            long? nextMortgageAccountNumber = StoredProcedure.NextNumber("NextMortgageAccount");
            
            if(nextMortgageAccountNumber != null)
            {
                this.AccountNumber = (long)nextMortgageAccountNumber;
            }
        }
    }

    /// <summary>
    /// InvestmentAccount Model - to represent InvestmentAccounts table in database
    /// </summary>
    public class InvestmentAccount : BankAccount
    {
        //InterestRate is required and should be displayed to 2 decimal places in percent format.
        [Required]
        [Display(Name = "Interest\nRate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:p2}")]
        public double InterestRate { get; set; }

        /// <summary>
        /// This method overrides the abstract SetNextAccountNumber from super class.
        /// </summary>
        public override void SetNextAccountNumber()
        {
            long? nextInvestmentAccountNumber = StoredProcedure.NextNumber("NextInvestmentAccount");

            if (nextInvestmentAccountNumber != null)
            {
                this.AccountNumber = (long)nextInvestmentAccountNumber;
            }           
        }
    }

    /// <summary>
    /// ChequingAccount Model - to represent ChequingAccounts table in database
    /// </summary>
    public class ChequingAccount : BankAccount
    {
        //InterestRate is required and should be displayed to 2 decimal places in currency format.
        [Required]
        [Display(Name = "Chequing\nService\nCharges ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c2}")]
        public double ChequingServiceCharges { get; set; }

        /// <summary>
        /// This method overrides the abstract SetNextAccountNumber from super class.
        /// </summary>
        public override void SetNextAccountNumber()
        {
            long? nextChequingAccountNumber = StoredProcedure.NextNumber("NextChequingAccount");

            if (nextChequingAccountNumber != null)
            {
                this.AccountNumber = (long)nextChequingAccountNumber;
            }
        }
    }

    /// <summary>
    /// Payee Model - to represent Payees table in database
    /// </summary>
    public class Payee
    {
        // PayeeId is a primary key.
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PayeeId { get; set; }

        // Description is required.
        [Required]
        [Display(Name = "Payee")]
        public String Description { get; set; }
    }

    /// <summary>
    /// Institution Model - to represent Institutions table in database
    /// </summary>
    public class Institution
    {
        // InstitutionId is a primary key.
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InstitutionId { get; set; }

        //InstitutionNumber is required.
        [Required]
        [Display(Name = "Number")]
        public int InstitutionNumber { get; set; }

        // Description is required.
        [Required]
        [Display(Name = "Institution")]
        public String Description { get; set; }
    }

    /// <summary>
    /// TransactionType Model - to represent TransactionTypes table in database
    /// </summary>
    public class TransactionType
    {
        // TransactionTypeId is a primary key.
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TransactionTypeId { get; set; }

        // Description is required.
        [Required]
        [Display(Name = "Type")]
        public String Description { get; set; }

        //Represents a 0 or many relationship
        public virtual ICollection<Transaction> Transaction { get; set; }
    }

    /// <summary>
    /// Transaction Model - to represent Transactions table in database
    /// </summary>
    public class Transaction
    {
        // TransactionId is a primary key.
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        // BankAccountId is a foreign key
        [ForeignKey("BankAccount")]
        public int BankAccountId { get; set; }

        // TransactionTypeId is a foreign key
        [ForeignKey("TransactionType")]
        public int TransactionTypeId { get; set; }

        //The Heading and Label for TransactionNumber should be “Number”.
        [Display(Name = "Number")]
        public long TransactionNumber { get; set; }

        //Deposit data should be displayed to 2 decimal places in currency format.
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c2}")]
        public double? Deposit { get; set; }

        // Withdrawal data should be displayed to 2 decimal places in currency format.
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c2}")]
        public double? Withdrawal { get; set; }

        // DateCreated is required.
        [Required]
        [Display(Name = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateCreated { get; set; }
       
        public String Notes { get; set; }

        //represents a 1 relationship on class diagram
        public virtual TransactionType TransactionType { get; set; }

        public virtual BankAccount BankAccount { get; set; }

        /// <summary>
        /// The method is to set NextTransactionNumber by using StoredProcedure.NextNumber method.
        /// </summary>
        public void SetNextTransactionNumber()
        {
            long? nextTransactionNumber = StoredProcedure.NextNumber("NextTransaction");

            if (nextTransactionNumber != null)
            {
                this.TransactionNumber = (long)nextTransactionNumber;
            }
        }
    }

    /// <summary>
    /// NextUniqueNumber Model - to represent NextUniqueNumbers table in database
    /// </summary>
    public abstract class NextUniqueNumber
    {
        // NextUniqueNumberId is a PK.
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextUniqueNumberId { get; set; }

        // NextAvailableNumber is required.
        [Required]
        public long NextAvailableNumber { get; set; }

        protected static BankOfBIT_YZContext db = new BankOfBIT_YZContext();
    }

    /// <summary>
    /// NextSavingAccount Model - to represent NextSavingAccounts table in database
    /// </summary>
    public class NextSavingsAccount : NextUniqueNumber
    {
        // Field
        private static NextSavingsAccount nextSavingsAccount;

        /// <summary>
        /// This is a constructor method to construct object of NextSavingAccount class.
        /// </summary>
        private NextSavingsAccount()
        {
            NextAvailableNumber = 20000;
        }

        /// <summary>
        /// This method is to get an instance of NextSavingsAccount if there is no record then it will generate a new one.
        /// </summary>
        /// <returns>Return an instance of NextSavingsAccount</returns>
        public static NextSavingsAccount GetInstance()
        {
            if (nextSavingsAccount == null)
            {
                nextSavingsAccount = db.NextSavingsAccounts.SingleOrDefault();

                if (nextSavingsAccount == null)
                {
                    nextSavingsAccount = new NextSavingsAccount();

                    db.NextSavingsAccounts.Add(nextSavingsAccount);

                    db.SaveChanges();
                }
            }
            return nextSavingsAccount;
        }
    }

    /// <summary>
    /// NextMortgageAccount Model - to represent NextMortgageAccounts table in database
    /// </summary>
    public class NextMortgageAccount: NextUniqueNumber
    {
        // Field
        private static NextMortgageAccount nextMortgageAccount;

        /// <summary>
        /// This is a constructor method to construct object of NextMortgageAccount class.
        /// </summary>
        private NextMortgageAccount() 
        {
            NextAvailableNumber = 200000;
        }

        /// <summary>
        /// This method is to get an instance of NextMortgageAccount.
        /// </summary>
        /// <returns>Return an instance of NextMortgageAccount.</returns>
        public static NextMortgageAccount GetInstance()
        {
            if(nextMortgageAccount == null)
            {
                nextMortgageAccount = db.NextMortgageAccounts.SingleOrDefault();

                if(nextMortgageAccount == null)
                {
                    nextMortgageAccount = new NextMortgageAccount();

                    db.NextMortgageAccounts.Add(nextMortgageAccount);

                    db.SaveChanges();
                }
            }
            return nextMortgageAccount;
        }
    }

    /// <summary>
    /// NextInvestmentAccount Model - to represent NextMortgageAccounts table in database
    /// </summary>
    public class NextInvestmentAccount: NextUniqueNumber 
    { 
        // Field
        private static NextInvestmentAccount nextInvestmentAccount;

        /// <summary>
        /// This is a constructor method to construct object of NextInvestmentAccount class.
        /// </summary>
        private NextInvestmentAccount() 
        {
            NextAvailableNumber = 2000000;
        }

        /// <summary>
        /// This method is to get an instance of NextInvestmentAccount.
        /// </summary>
        /// <returns>Return an instance of NextInvestmentAccount.</returns>
        public static NextInvestmentAccount GetInstance()
        {
            if(nextInvestmentAccount == null)
            {
                nextInvestmentAccount = db.NextInvestmentAccounts.SingleOrDefault();

                if(nextInvestmentAccount == null)
                {
                    nextInvestmentAccount = new NextInvestmentAccount();

                    db.NextInvestmentAccounts.Add(nextInvestmentAccount);

                    db.SaveChanges();
                }
            }
            return nextInvestmentAccount;
        }
    }

    /// <summary>
    /// NextChequingAccount Model - to represent NextChequingAccounts table in database
    /// </summary>
    public class NextChequingAccount : NextUniqueNumber
    {
        // Field
        private static NextChequingAccount nextChequingAccount;

        /// <summary>
        /// This is a constructor method to construct object of NextChequingAccount class.
        /// </summary>
        private NextChequingAccount() 
        {
            NextAvailableNumber = 20000000;
        }

        /// <summary>
        /// This method is to get an instance of NextChequingAccount.
        /// </summary>
        /// <returns>Return an instance of NextChequingAccount.</returns>
        public static NextChequingAccount GetInstance()
        {
            if(nextChequingAccount == null)
            {
                nextChequingAccount = db.NextChequingAccounts.SingleOrDefault();

                if(nextChequingAccount == null)
                {
                    nextChequingAccount = new NextChequingAccount();

                    db.NextChequingAccounts.Add(nextChequingAccount);

                    db.SaveChanges();
                }
            }
            

            return nextChequingAccount;
        }
    }

    /// <summary>
    /// NextClient Model - to represent NextClients table in database
    /// </summary>
    public class NextClient : NextUniqueNumber
    {
        // Field
        private static NextClient nextClient;

        /// <summary>
        /// This is a constructor method to construct object of NextClient class.
        /// </summary>
        private NextClient() 
        {
            NextAvailableNumber = 20000000;
        }

        /// <summary>
        /// This method is to get an instance of NextClient.
        /// </summary>
        /// <returns>Return an instance of NextClient.</returns>
        public static NextClient GetInstance()
        {
            if (nextClient == null)
            {
                nextClient = db.NextClients.SingleOrDefault();

                if (nextClient == null)
                {
                    nextClient = new NextClient();

                    db.NextClients.Add(nextClient);

                    db.SaveChanges();
                }
            }   
            return nextClient;
        }
    }

    /// <summary>
    /// NextTransaction Model - to represent NextTransactions table in database
    /// </summary>
    public class NextTransaction : NextUniqueNumber
    {
        // Field
        private static NextTransaction nextTransaction;

        /// <summary>
        /// This is a constructor method to construct object of NextTransaction class.
        /// </summary>
        private NextTransaction() 
        {
            NextAvailableNumber = 700;
        }

        /// <summary>
        /// This method is to get an instance of NextTransaction.
        /// </summary>
        /// <returns>Return an instance of NextTransaction.</returns>
        public static NextTransaction GetInstance()
        {
            if (nextTransaction == null)
            {
                nextTransaction = db.NextTransactions.SingleOrDefault();

                if (nextTransaction == null)
                {
                    nextTransaction = new NextTransaction();

                    db.NextTransactions.Add(nextTransaction);

                    db.SaveChanges();
                }
            }

            return nextTransaction;
        }
    }

    /// <summary>
    /// The class is used to create StoredProcedure.
    /// </summary>
    public static class StoredProcedure
    {           
        /// <summary>
        /// This method is to get next number by utilizing next_number stored procedure in SSMS.
        /// </summary>
        /// <param name="discriminator">the value of discriminator should be the subclasses of NextUniqueNumber.</param>
        /// <returns>This method will return next number</returns>
        public static long? NextNumber(string discriminator)
        {
            try
            {
                // Build connection with database
                SqlConnection connection = new SqlConnection("Data Source=localhost;" +
                "Initial Catalog=BankOfBIT_YZContext;Integrated Security=True");

                // Assign 0 to returnValue
                long? returnValue = 0;

                // Instaniate an object of sqlCommand which is the next_number from this connection.
                SqlCommand storedProcedure = new SqlCommand("next_number", connection);

                // Set the object's command type as StoredProcedure
                storedProcedure.CommandType = CommandType.StoredProcedure;

                // Add the value of discriminator of NextUniqueNumber to the Discriminator parameter of StoredProcedure 
                storedProcedure.Parameters.AddWithValue("@Discriminator", discriminator);

                // Set NewVal as Output parameter
                SqlParameter outputParameter = new SqlParameter("@NewVal", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Output
                };

                // Add outputParameter as parameter of  storedProcedure
                storedProcedure.Parameters.Add(outputParameter);

                // Open connection
                connection.Open();

                // Excute storedProcedure
                storedProcedure.ExecuteNonQuery();

                // Close connection.
                connection.Close();

                // Assign the value of outputParameter to returnvalue.
                returnValue = (long?)outputParameter.Value;

                // Return next available number.
                return returnValue;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}


