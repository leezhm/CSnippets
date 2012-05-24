// 
// ArgumentWithRefAndOut.cs
//  
// Author:
//       leezhm <leezhm(at)126.com>
// 
// Copyright (c) 2012 leezhm(at)126.com
// 
// Created:
// 	leezhm <2012/5/24> 
// 
// Modified:
// 	leezhm <2012/5/24> 
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

namespace CSnippets.RefAndOut
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tester
    {
        public int ta = 0;
        public int tb = 0;

        public Tester(int a, int b)
        {
            ta = a;
            tb = b;
        }

        public void Print()
        {
            Console.WriteLine("Here is it: ta = {0}, tb = {1}", ta, tb);
        }
    }

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ArgumentWithRefAndOut
    {
        public void ChangeRefType(Tester t)
        {
            // we change the reference of str
            t.ta *= 10;
            t.tb *= 10;

            // and then we changed the t itself
            t = new Tester(100, 200);
        }

        public void ChangedRefTypeWithRef(ref Tester t)
        {
            // we change the reference of str
            t.ta *= -10;
            t.tb *= -10;

            // and then we changed the t itself
            t = new Tester(100, 200);
        }

        public static void TestArgumentWithRefAndOut()
        {
            Tester test = new Tester(1, 2);
            test.Print();

            //
            ArgumentWithRefAndOut aw = new ArgumentWithRefAndOut();
            aw.ChangeRefType(test);
            test.Print();

            // we changed test object, so it means if we using ref for a 
            // reference argument,the reference argument itself is also 
            // call-by-reference
            aw.ChangedRefTypeWithRef(ref test);
            test.Print();
        }
    }
}
