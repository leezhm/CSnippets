// 
// LambdaExample.cs
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

namespace CSnippets.Lambda
{
    // First, declare a delegate type that can compatible with lambda expression.
    delegate int IncrThree(int operand);

    delegate bool IsEven(int operand);

    class LambdaExample
    {
        public static void TestLambdaExample()
        {
            // Second, create an IncrThree delegate instance that refers to 
            // a lambda expression that increases its parameter by 3.
            IncrThree it = count => count + 3;

            // Finally, use the it lambda expression
            int x = -20;
            for (int i = 1; i <= 10; ++i)
            {
                Console.WriteLine("x = {0}\t, and then x = {1}", x, x = it(x));
            }

            IsEven ie = n => 0 == n % 2;

            for (int j = 1; j <= 20; ++j)
            {
                if (ie(j)) Console.WriteLine(j + "\t is Even ...");
            }
        }
    }
}
