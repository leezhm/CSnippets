using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSnippets.Threads.ConsoleThreadSerials
{
    public class Alpha
    {
        public void Beta()
        {
            while (true)
            {
                Console.WriteLine("Alpha::Beta is running in its own thread ...");
            }
        }
    }

    public class FirstSimpleThread
    {
        public static void FirstSimpleThreadExample()
        {
            Console.WriteLine("Thread Start/Stop/Join Sample ...");

            Alpha alpha = new Alpha();

            // Create a thread and run the method Alpha::Beta
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(alpha.Beta));

            // Start the thread
            thread.Start();

            while (!thread.IsAlive)
            {
                System.Threading.Thread.Sleep(1);
            }

            //thread.Abort();

            thread.Join();

            Console.WriteLine("\nAlpha.Beta has finished ...");

            try
            {
                Console.WriteLine("Try to restart the Alpha::Beta thread");
                
                // Start again
                thread.Start();
            }
            catch (System.Threading.ThreadStateException expt)
            {
                Console.WriteLine("Thread State Exception : {0}", expt.ToString());

                Console.ReadLine();
            }
        }
    }
}
