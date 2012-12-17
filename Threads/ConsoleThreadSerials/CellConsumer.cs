using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSnippets.Threads.ConsoleThreadSerials
{
    public class CellConsumer
    {
        /// <summary>
        /// 
        /// </summary>
        public Cell CellCon { get; set; }

        int Quantity = 1;

        public CellConsumer(Cell box, int request)
        {
            CellCon = box;
            Quantity = request;
        }

        public void ThreadRuning()
        {
            int ValReturned = 0;

            for (int looper = 1; looper <= Quantity; looper++)
            {
                // 本对象从操作对象中读取信息
                ValReturned = CellCon.ReadFromCell();
            }
        }
    }
}
