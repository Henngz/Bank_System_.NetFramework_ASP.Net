using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankOfBIT_YZ.Data
{
    public class BankOfBIT_YZContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BankOfBIT_YZContext() : base("name=BankOfBIT_YZContext")
        {
        }

        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.AccountState> AccountStates { get; set; }
        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.BronzeState> BronzeStates { get; set; }
        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.SilverState> SilverStates { get; set; }
        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.GoldState> GoldStates { get; set; }
        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.PlatinumState> PlatinumStates { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.BankAccount> BankAccounts { get; set; }
        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.SavingsAccount> SavingsAccounts { get; set; }
        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.MortgageAccount> MortgageAccounts { get; set; }
        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.InvestmentAccount> InvestmentAccounts { get; set; }
        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.ChequingAccount> ChequingAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.NextUniqueNumber> NextUniqueNumbers { get; set; }
 

        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.NextMortgageAccount> NextMortgageAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.NextInvestmentAccount> NextInvestmentAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.NextChequingAccount> NextChequingAccounts { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.NextTransaction> NextTransactions { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.NextClient> NextClients { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.Payee> Payees { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.Institution> Institutions { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.Transaction> Transactions { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.TransactionType> TransactionTypes { get; set; }

        public System.Data.Entity.DbSet<BankOfBIT_YZ.Models.NextSavingsAccount> NextSavingsAccounts { get; set; }
    }
}
