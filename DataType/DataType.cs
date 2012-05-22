// 
// DataType.cs
//  
// Author:
//       leezhm <leezhm(at)126.com>
// 
// Copyright (c) 2012 leezhm(at)126.com
// 
// Created:
//       leezhm <2012/5/21>
// 
// Modified:
//       leezhm <2012/5/21> 
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

namespace DataType
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class DataType
    {
        public static void SizeofType()
        {
            Console.WriteLine("{0}\t{1}\t\t{2}", "Type In C#", "Type In .NET", "Meaning");
            Console.WriteLine("{0}\t\t{1}\t\t{2} bits", "char",    typeof(char),    sizeof(char) * 8);
            Console.WriteLine("{0}\t\t{1}\t\t{2} bits", "byte",    typeof(byte),    sizeof(byte) * 8);
            Console.WriteLine("{0}\t\t{1}\t\t{2} bits", "sbyte",   typeof(sbyte),   sizeof(sbyte) * 8);
            Console.WriteLine("{0}\t\t{1}\t\t{2} bits", "short",   typeof(short),   sizeof(short) * 8);
            Console.WriteLine("{0}\t\t{1}\t\t{2} bits", "ushort",  typeof(ushort),  sizeof(ushort) * 8);
            Console.WriteLine("{0}\t\t{1}\t\t{2} bits", "int",     typeof(int),     sizeof(int) * 8);
            Console.WriteLine("{0}\t\t{1}\t\t{2} bits", "uint",    typeof(uint),    sizeof(uint) * 8);
            Console.WriteLine("{0}\t\t{1}\t\t{2} bits", "long",    typeof(long),    sizeof(long) * 8);
            Console.WriteLine("{0}\t\t{1}\t\t{2} bits", "ulong",   typeof(ulong),   sizeof(ulong) * 8);
            Console.WriteLine("{0}\t\t{1}\t\t{2} bits", "float",   typeof(float),   sizeof(float) * 8);
            Console.WriteLine("{0}\t\t{1}\t\t{2} bits", "double",  typeof(double),  sizeof(double) * 8);
            Console.WriteLine("{0}\t\t{1}\t\t{2} bits", "decimal", typeof(decimal), sizeof(decimal) * 8);
            Console.WriteLine("{0}\t\t{1}\t\t{2} bits", "bool",    typeof(bool),    sizeof(bool) * 8);
            Console.WriteLine("{0}\t\t{1}\t\t{2} bits", "null",    typeof(Nullable), "");
            Console.WriteLine("{0}\t\t{1}\t\t{2} bits", "enum",    typeof(Enum),    ""); 
        }
    }
}
