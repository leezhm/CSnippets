using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSnippets.Threads.ConsoleThreadSerials
{
    public class Cell
    {
        /// <summary>
        /// Cell Content
        /// </summary>
        public int CellContent { get; set; }

        /// <summary>
        /// Flag for reader
        /// 
        /// It can read if ReaderFlag is true, otherwise it is writing.
        /// </summary>
        public bool ReaderFlag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ReadFromCell()
        {
            lock (this) // 对本对象的锁定  
            {
                if (!ReaderFlag) 
                {
                    // 不可读取
                    try
                    {
                        // 等待WriteToCell的方法中调用Monitor.Pulse()方法
                        System.Threading.Monitor.Wait(this);
                    }
                    catch (System.Threading.SynchronizationLockException expt)
                    {
                        Console.WriteLine("Synchronization Lock Exption : {0}", expt.ToString());
                    }
                    catch (System.Threading.ThreadInterruptedException expt)
                    {
                        Console.WriteLine("Thread Interrupted Exception : {0}", expt.ToString());
                    }
                }

                Console.WriteLine("Consume : {0}", CellContent);
                ReaderFlag = false;

                // 重置ReaderFlag标志，表示消费者行为已经完成
                System.Threading.Monitor.Pulse(this);

                // 通知WriteToCell()方法
            }

            return CellContent;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cc"></param>
        public void WriteToCell(int cc)
        {
            lock (this)
            {
                if (ReaderFlag)
                {
                    try
                    {
                        // 等待读操作完成
                        System.Threading.Monitor.Wait(this);
                    }
                    catch (System.Threading.SynchronizationLockException expt)
                    {
                        Console.WriteLine("Synchronization Lock Exption : {0}", expt.ToString());
                    }
                    catch (System.Threading.ThreadInterruptedException expt)
                    {
                        Console.WriteLine("Thread Interrupted Exception : {0}", expt.ToString());
                    }
                }

                CellContent = cc;
                Console.WriteLine("Produce : {0}", CellContent);

                ReaderFlag = true;

                System.Threading.Monitor.Pulse(this);
            }
        }
    }
}
