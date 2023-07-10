using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfBIT_YZ;
using BankOfBIT_YZ.Models;

namespace WindowsBanking
{
    public class ConstructorData
    {
        //Set Auto-Implemented properties of Client
        public Client client { get; set; }

        //Set Auto-Implemented properties of BankAccount
        public BankAccount bankAccount { get; set; }
    }
}
