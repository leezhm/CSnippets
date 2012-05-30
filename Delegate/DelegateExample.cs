// 
// DelegateExample.cs
//  
// Author:
//       leezhm <leezhm(at)126.com>
// 
// Copyright (c) 2012 leezhm(at)126.com
// 
// Created:
// 		 leezhm <2012/5/30> 
// 
// Modified:
// 	     leezhm <2012/5/30> 
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

namespace CSnippets.Delegate
{
    /// <summary>
    /// Declare a delegate type.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    delegate string StringTools(string str);

    internal class StringExtension
    {
        public static string ReplaceString(string src)
        {
            Console.WriteLine("Source string is " + src);

            string temp = src.Replace(' ', '-');

            Console.WriteLine("Resulting string is " + temp + "\n");
            return temp;
        }

        public static string RemoveSpace(string src)
        {
            Console.WriteLine("Source string is " + src);

            string temp = String.Empty;
            foreach (char ch in src)
            {
                if (' ' != ch) temp += ch;
                else continue;
            }

            Console.WriteLine("Resulting string is " + temp + "\n");
            return temp;
        }

        public static string Reverse(string src)
        {
            Console.WriteLine("Source string is " + src);

            string temp = string.Empty;
            for(int i = (src.Length - 1); i >= 0; -- i)
            {
                temp += src[i];
            }
            
            Console.WriteLine("Resulting string is " + temp + "\n");
            return temp;
        }

        //public string ReplaceSpaceWith
    }

    class DelegateExample
    {
        public static void TestDelegateExample()
        {
            StringTools st = new StringTools(StringExtension.ReplaceString);
            string dst = st("This is a test for you ...");

            st = new StringTools(StringExtension.RemoveSpace);
            dst = st("This is a test for you ...");

            st = new StringTools(StringExtension.Reverse);
            dst = st("This is a test for you ...");

            StringTools st2 = StringExtension.ReplaceString;
            st2 += StringExtension.RemoveSpace;
            st2 += StringExtension.Reverse;
            dst = st2("Welcome to use this code snippets ...");

            st2 -= StringExtension.ReplaceString;
            dst = st2("Another test case ...");
        }
    }
}
