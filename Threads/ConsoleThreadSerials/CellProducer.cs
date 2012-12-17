using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSnippets.Threads.ConsoleThreadSerials
{
    public class CellProducer
    {
        /// <summary>
        /// 被操作的Cell对象
        /// </summary>
        public Cell CellPro { get; set; }

        // 生产者生产次数，初始化为1
        private int Quantity = 1;

        public CellProducer(Cell box, int request)
        {
            CellPro = box;
            Quantity = request;
        }

        public void ThreadRuning()
        {
            for (int looper = 1; looper <= Quantity; looper++)
            {
                // 本生产者向操作对象Cell写入数据
                CellPro.WriteToCell(looper);
            }
        }
    }
}
