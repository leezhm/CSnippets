// 
// ExceptionExample.cs
//  
// Author:
//       leezhm <leezhm(at)126.com>
// 
// Copyright (c) 2012 leezhm(at)126.com
// 
// Created:
// 		 leezhm <2012/5/29> 
// 
// Modified:
// 	     leezhm <2012/5/29> 
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSnippets.Exception
{
    internal class ExceptA : System.Exception
    {
        public ExceptA(string msg)
            : base(msg)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    internal class ExceptB : ExceptA
    {
        public ExceptB(string msg)
            : base(msg)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    class ExceptionExample
    {
        private static void ThrowException()
        {
            for (int i = 0; i < 5; ++i)
            {
                try
                {
                    if (0 == i) throw new ExceptA("Exception Type is A ...");
                    else if (1 == i) throw new ExceptB("Exception Type is B ...");
                    else if (2 == i) throw new IndexOutOfRangeException("Index out of range, Just for test ...");
                    else throw new System.Exception("What's wrong? Just for test ...");
                }
                catch (ExceptB eb)
                {
                    Console.WriteLine("Stack trace: " + eb.StackTrace);
                    Console.WriteLine("Message: " + eb.Message);
                    Console.WriteLine("Target Site: " + eb.TargetSite);
                    Console.WriteLine();
                }
                catch (ExceptA ea)
                {
                    Console.WriteLine("Stack trace: " + ea.StackTrace);
                    Console.WriteLine("Message: " + ea.Message);
                    Console.WriteLine("Target Site: " + ea.TargetSite);
                    Console.WriteLine();
                }
            }
        }

        public static void TestExceptionExample()
        {
            try
            {
                ThrowException();
            }
            catch (IndexOutOfRangeException expt) // the loop will break when this exception was captured.
            {
                Console.WriteLine("Stack trace: " + expt.StackTrace);
                Console.WriteLine("Message: " + expt.Message);
                Console.WriteLine("Target Site: " + expt.TargetSite);
                Console.WriteLine();
            }
            catch // Never execute this statement.Do you know why?
            {     // Because the IndexOutRange exception had break the loop.
                Console.WriteLine("What's wrong? ...");
            }
        }
    }
}
