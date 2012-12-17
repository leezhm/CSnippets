using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSnippets.Threads.ConsoleThreadSerials
{
    public class CellExample
    {
        public static void CellExampleExample()
        {
            // 一个标志位，如果为0，表示程序没有出现错误，否则表明有错误发生
            int result = 0;

            Cell cell = new Cell();

            // 创建Producer和Consumer对象，并设置生产和消费各20次
            CellProducer cpro = new CellProducer(cell, 20);
            CellConsumer ccon = new CellConsumer(cell, 20);

            // 创建Producer和Consumer的线程
            System.Threading.Thread producer = new System.Threading.Thread(new System.Threading.ThreadStart(cpro.ThreadRuning));
            System.Threading.Thread consumer = new System.Threading.Thread(new System.Threading.ThreadStart(ccon.ThreadRuning));

            try
            {
                producer.Start();
                consumer.Start();

                producer.Join();
                consumer.Join();

                Console.ReadLine();
            }
            catch (System.Threading.SynchronizationLockException expt)
            {
                Console.WriteLine("Synchronization Lock Exception : {0}", expt.ToString());
                result = 1;
            }
            catch (System.Threading.ThreadInterruptedException expt)
            {
                Console.WriteLine("Thread Interrupted Exception : {0}", expt.ToString());
                result = 1;
            }

            System.Environment.ExitCode = result;
        }
    }
}
