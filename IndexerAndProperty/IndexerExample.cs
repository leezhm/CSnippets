// 
// IndexerExample.cs
//  
// Author:
//       leezhm <leezhm(at)126.com>
// 
// Copyright (c) 2012 leezhm(at)126.com
// 
// Created:
// 	leezhm <2012/5/28> 
// 
// Modified:
// 	leezhm <2012/5/28> 
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 

namespace CSnippets.IndexerAndProperty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public enum WeekDay
    {
        Sun,    // Sunday
        Mon,    // Monday
        Tue,    // Tuesday
        Wed,    // Wednesday
        Thu,    // Thursday
        Fri,    // Friday
        Sat     // Saturday
    }

    public class Today
    {
        private Today[] Indexer = new Today[7];

        public Today this[int index]
        {
            get
            {
                return Indexer[index];
            }
        }

        private string tips = "Now is ";

        public Today()
        {
        }

        public string Tip
        {
            get
            {
                return this.tips;
            }
        }

        public void Init()
        {
            for (int i = 0; i < Indexer.Length; ++ i )
            {
                Indexer[i] = new Today();
                Indexer[i].tips += DateTime.Now.ToLongDateString() + ", "
                                 + DateTime.Now.ToLongTimeString();
            }
        }
    }

    class IndexerExample
    {
        public static void TestIndexerExample()
        {
            Today td = new Today();
            td.Init();

            foreach(var day in Enum.GetValues(typeof(WeekDay)))
            {
                Console.WriteLine("{0} -> {1}", day, td[(int)day].Tip);
            }
        }
    }
}
