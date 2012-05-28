// 
// OperatorExample.cs
//  
// Author:
//       leezhm <leezhm(at)126.com>
// 
// Copyright (c) 2012 leezhm(at)126.com
// 
// Created:
// 	leezhm <2012/5/25> 
// 
// Modified:
// 	leezhm <2012/5/25> 
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

namespace CSnippets.OperatorOverload
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ThreeD
    {
        double xIndex = 0.0f;
        double yIndex = 0.0f;
        double zIndex = 0.0f;

        public ThreeD()
        {
            xIndex = yIndex = zIndex = 0.0f;
        }

        public ThreeD(double x, double y, double z)
        {
            xIndex = x;
            yIndex = y;
            zIndex = z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fstThreeD"></param>
        /// <param name="secdThreeD"></param>
        /// <returns></returns>
        public static ThreeD operator +(ThreeD fstThreeD, ThreeD secdThreeD)
        {
            ThreeD result = new ThreeD();

            result.xIndex = fstThreeD.xIndex + secdThreeD.xIndex;
            result.yIndex = fstThreeD.yIndex + secdThreeD.yIndex;
            result.zIndex = fstThreeD.zIndex + secdThreeD.zIndex;

            return result;
        }

        public static ThreeD operator -(ThreeD fstThreeD, ThreeD secdThreeD)
        {
            ThreeD result = new ThreeD();

            result.xIndex = fstThreeD.xIndex - secdThreeD.xIndex;
            result.yIndex = fstThreeD.yIndex - secdThreeD.yIndex;
            result.zIndex = fstThreeD.zIndex - secdThreeD.zIndex;

            return result;
        }

        /// <summary>
        /// unary operator
        /// </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public static ThreeD operator -(ThreeD operand)
        {
            ThreeD result = new ThreeD();

            result.xIndex = -operand.xIndex;
            result.yIndex = -operand.yIndex;
            result.zIndex = -operand.zIndex;

            return result;
        }

        public static ThreeD operator ++(ThreeD operand)
        {
            ThreeD result = new ThreeD();

            result.xIndex = operand.xIndex + 1;
            result.yIndex = operand.yIndex + 1;
            result.zIndex = operand.zIndex + 1;

            return result;
        }

        public static ThreeD operator --(ThreeD operand)
        {
            ThreeD result = new ThreeD();

            result.xIndex = operand.xIndex - 1;
            result.yIndex = operand.yIndex - 1;
            result.zIndex = operand.zIndex - 1;

            return result;
        }

        public override string ToString()
        {
            string str = String.Empty;

            str += "(" + xIndex + ", " + yIndex + ", " + zIndex + ")";

            return str;
        }

    }


    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class OperatorExample
    {
        public static void TestOperatorExample()
        {
            ThreeD td1 = new ThreeD(1, 2, 3);
            ThreeD td2 = new ThreeD(10, 20, 30);
            ThreeD td3 = null;

            Console.WriteLine("td1 is {0}", td1.ToString());
            Console.WriteLine("td2 is {0}", td2.ToString());

            td3 = td1 + td2;
            Console.WriteLine("Result of td1 + td2 is {0}", td3.ToString());

            td3 += td2;
            Console.WriteLine("Result of td3 += td2 is {0}", td3.ToString());

            td3 = td1 + td2 + td3;
            Console.WriteLine("Result of td1 + td2 + td3 is {0}", td3.ToString());

            td3 = td3 - td1;
            Console.WriteLine("Result of td3 - td1 is {0}", td3.ToString());

            td3 = td3 - td2;
            Console.WriteLine("Result of td3 - td2 is {0}", td3.ToString());

            td3 -= td3;
            Console.WriteLine("Result of td3 -= td3 is {0}", td3.ToString());

            td3 = td1++;
            Console.WriteLine("Result of td3{0} = td1 ++ is {1}", td3.ToString(), td1.ToString());

            td3 = ++td1;
            Console.WriteLine("Result of td3{0} = ++ td1 is {1}", td3.ToString(), td1.ToString());

            td3 = -td2;
            Console.WriteLine("Result of td3{0} = - td2 is {1}", td3.ToString(), td2.ToString());
        }
    }
}

       