using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITransactionManager" in both code and config file together.
    [ServiceContract]
    public interface ITransactionManager
    {
        [OperationContract]
        void DoWork();

        /// <summary>
        /// The method is to return the updated balance after depositing.
        /// </summary>
        /// <param name="accountId">Represent the account id</param>
        /// <param name="amount">Represent the amount of the account</param>
        /// <param name="notes">Represent notes of this transcation </param>
        /// <returns>Return updated balance</returns>
        [OperationContract]
        double? Deposit(int accountId, double amount, String notes);

        /// <summary>
        /// The method is to return the updated balance after withdrawal.
        /// </summary>
        /// <param name="accountId">Represent the account id</param>
        /// <param name="amount">Represent the amount of the account</param>
        /// <param name="notes">Represent notes of this transcation </param>
        /// <returns>Return updated balance</returns>
        [OperationContract]
        double? Withdrawal(int accountId, double amount, String notes);

        /// <summary>
        /// The method is to return the updated balance after bill payment.
        /// </summary>
        /// <param name="accountId">Represent the account id</param>
        /// <param name="amount">Represent the amount of the account</param>
        /// <param name="notes">Represent notes of this transcation </param>
        /// <returns>Return updated balance</returns>
        [OperationContract]
        double? BillPayment(int accountId, double amount, String notes);

        /// <summary>
        /// The method is to return the updated balance after transfering.
        /// </summary>
        /// <param name="fromAccountId">Represent the account id of sending account</param>
        /// <param name="toAccountId">Represent the account id of receiving account</param>
        /// <param name="amount">Represent the amount of the account</param>
        /// <param name="notes">Represent notes of this transcation </param>
        /// <returns>Return updated balance</returns>
        [OperationContract]
        double? Transfer(int fromAccountId, int toAccountId, double amount, String notes);

        /// <summary>
        /// The method is to calculate and return interest.
        /// </summary>
        /// <param name="accountId">Represent the account id</param>
        /// <param name="notes">Represent notes of this transcation </param>
        /// <returns>Return interest</returns>
        [OperationContract]
        double? CalculateInterest(int accountId, String notes);
    }
}
