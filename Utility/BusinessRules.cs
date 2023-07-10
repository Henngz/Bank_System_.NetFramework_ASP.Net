using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    /// <summary>
    /// Business Rules:  This class contains functionality that is specific to the
    /// business rules supporting the BANK OF BIT application.  As the course progresses,
    /// students are encouraged to add methods containing functionality common to various
    /// aspects of the BANK OF BIT application.
    /// </summary>
    public static class BusinessRules
    {
        public const int BANK_OF_BIT_NUMBER = 45910;

        /// <summary>
        /// BankNumber:  Returns the value of the BANK OF BIT bank number.
        /// </summary>
        /// <returns>The BANK OF BIT bank number.</returns>
        public static int BankNumber()
        {
            return BANK_OF_BIT_NUMBER;
        }

        /// <summary>
        /// AccountFormat:  A method that provides the formatting characters for each
        /// type of bank account.
        /// </summary>
        /// <param name="accountType">The type of bank account.</param>
        /// <returns>The formatting characters specific to the type of bank account.</returns>
        public static String AccountFormat(String accountType)
        {
            string[] ACCOUNT_TYPE = { "Savings", "Mortgage", "Investment", "Chequing" };
            string[] ACCOUNT_MASK = { "0-000-0", "000-000", "00-000-00", "000-00-000" };


            //initial format (empty string)
            string format = "";

            //compare account type to predefined types
            for (int i = 0; i < ACCOUNT_TYPE.Length; i++)
            {
                //if a match, return the corresonding mask
                if (accountType.ToLower().Equals(ACCOUNT_TYPE[i].ToLower()))
                {
                    format = ACCOUNT_MASK[i];
                }
            }
            //return the mask or empty string
            return format;
        }

        /// <summary>
        /// This method is to get only account state or  the name of the BankAccount subtype.
        /// </summary>
        /// <param name="typeName">the typename of the current instance </param>
        /// <returns>Return only account state or the name of the BankAccount subtype.</returns>
        public static String GetStateOrSubtype(String typeName)
        {
            int index = 0;

            if (typeName.IndexOf("State") != -1)
            {
                index = typeName.IndexOf("State");
            }
            else if (typeName.IndexOf("Account") != -1)
            {
                index = typeName.IndexOf("Account");
            }

            return typeName.Substring(0, index);
        }
    }
    }
