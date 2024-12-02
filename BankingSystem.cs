using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Многопоточность
{
    class BankingSystem
    {
        private BankAccount account;
        private List<Thread> _operationThreads;
        private Random _random;

        public BankingSystem(BankAccount bankAccount)
        {
            this.account = bankAccount;
            _random = new Random();
            _operationThreads = new List<Thread>();
        }
        public void StartOperations(int operationCount)
        {
            for (int i = 0; i < operationCount; i++)
            {
                var thread = new Thread(PerformRandomOperation);
                thread.Start();
                _operationThreads.Add(thread);
            }
        }
        public void WaitForCompletion()
        {
            foreach (var thread in _operationThreads)
            {
                thread.Join();
            }
        }
        private void PerformRandomOperation()
        {
            decimal amount = _random.Next(50, 500); 
            bool deposit = _random.Next(0, 2) == 0; 

            Transaction transaction;
            if (deposit)
            {
                if (account.TryDeposit(amount))
                {
                    transaction = new Transaction(1, amount, "Deposit", "Success");
                    LogOperation(transaction.ToString());
                }
                else
                {
                    transaction = new Transaction(1, amount, "Deposit", "Failed");
                    LogOperation(transaction.ToString());
                }
            }
            else
            {
                if (account.TryWithdraw(amount))
                {
                    transaction = new Transaction(2, amount, "Withdrawal", "Success");
                    LogOperation(transaction.ToString());
                }
                else
                {
                    transaction = new Transaction(2, amount, "Withdrawal", "Insufficient funds");
                    LogOperation(transaction.ToString());
                }
            }
        }
        private void LogOperation(string message)
        {
            Console.Write(message);
        }
    }
}
