namespace Многопоточность
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 задание\n");
            ThreadCounter threadCounter = new ThreadCounter(5, 10);
            threadCounter.StartCounting();
            threadCounter.WaitForCompletion();
            Console.WriteLine("2 задание\n");
            BankAccount account = new BankAccount("123456789", 1000.00m);
            BankingSystem bankingSystem = new BankingSystem(account);

            bankingSystem.StartOperations(10); // Запускаем 10 операций
            bankingSystem.WaitForCompletion(); // Ждем завершения всех операций

            Console.WriteLine($"Final Balance: ${account.Balance:F2}");
        }
    }
}
