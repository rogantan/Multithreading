using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Многопоточность
{
    class BankAccount
    {
        private decimal balance;
        private readonly object _lockObject = new object();
        private int _operationCount;
        public string AccountNumber { get; }
        public decimal Balance
        {
            get
            {
                lock (_lockObject)
                {
                    return balance;
                }
            }
        }

        public BankAccount(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            balance = initialBalance;
        }
        public bool TryDeposit(decimal amount)
        {
            lock (_lockObject)
            {
                if (amount <= 0)
                    return false;

                balance += amount;
                _operationCount++;
                return true;
            }
        }
        public bool TryWithdraw(decimal amount)
        {
            lock (_lockObject)
            {
                if (amount <= 0)
                    return false;

                if (amount > balance)
                    return false;

                balance -= amount;
                _operationCount++;
                return true;
            }
        }
    }
}
