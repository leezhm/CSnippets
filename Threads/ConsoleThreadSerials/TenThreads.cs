using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSnippets.Threads.ConsoleThreadSerials
{
    internal class Account
    {
        int balance = 0;
        Random r = new Random();

        internal Account(int init)
        {
            this.balance = init;
        }

        internal int Running(int amount)
        {
            if (balance < 0)
            {
                throw new System.Exception("Negative Balance ... ");
            }

            lock (this)
            {
                Console.WriteLine("Current Thread : {0} -> {1} -> {2}", 
                    System.Threading.Thread.CurrentThread.Name, balance, amount);


                if (balance >= amount)
                {
                    System.Threading.Thread.Sleep(5);
                    balance -= amount;

                    return amount;
                }
                else
                {
                    return 0; // less than amount
                }
            }
        }

        internal void DoTransactions()
        {
            for (int i = 0; i < 10; i++)
            {
                Running(r.Next(-50, 100));
            }
        }
    }

    class TenThreads
    {
        static internal System.Threading.Thread[] threads = new System.Threading.Thread[10];

        public static void TenThreadsExample()
        {
            Account at = new Account(0);

            for (int i = 0; i < 2; i++)
            {
                System.Threading.Thread td = new System.Threading.Thread(new System.Threading.ThreadStart(at.DoTransactions));
                td.Name = i.ToString();
                threads[i] = td;

                // start thread
                threads[i].Start();
            }

            Console.ReadLine();
        }
    }
}
