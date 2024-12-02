using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq.Expressions;

namespace Многопоточность
{
    class ThreadCounter
    {
        private int _threadCount;
        private int _maxNumber;
        private readonly object _consoleLock = new object();
        private Random _random;
        Thread[] threads;

        public ThreadCounter(int threadCount, int maxNumber)
        {
            this._maxNumber = maxNumber;
            this._threadCount = threadCount;
            _random = new Random();
            threads = new Thread[_threadCount];
        }
        public void StartCounting()
        {
            
            for (int i = 0; i < _threadCount; i++)
            {
                threads[i] = new Thread(CountNumbers);
                threads[i].Start(i + 1);
            }
        }
        public void WaitForCompletion()
        {
            //Thread[] threads = new Thread[_threadCount];

            for (int i = 0; i < _threadCount; i++)
            {
                threads[i].Join(); 
            }
        }
        private void CountNumbers(object threadId)
        {
            int id = (int)threadId;

            for (int i = 1; i <= _maxNumber; i++)
            {
                int delay = _random.Next(100, 301);
                Thread.Sleep(delay);
                SafeConsoleWrite($"Thread-{id}: Number {i} (delay: {delay}ms)\n");
            }
        }
        private void SafeConsoleWrite(string message)
        {
            lock (_consoleLock)
            {
                Console.WriteLine(message);
            }
        }
    }
}
