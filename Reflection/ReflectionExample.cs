// 
// ReflectionExample.cs
//  
// Author:
//       leezhm <leezhm(at)126.com>
// 
// Copyright (c) 2012 leezhm(at)126.com
// 
// Created:
// 		 leezhm <2012/6/11> 
// 
// Modified:
// 	     leezhm <2012/6/12> 
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

namespace CSnippets.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using System.Reflection;    // Type

    class Justing
    {
        private int x = 0;
        private int y = 0;

        public Justing(int i, int j)
        {
            x = i;
            y = j;
        }

        public int Sum()
        {
            return x + y;
        }

        public bool IsBetween(int i)
        {
            if (x < i && i < y) return true;
            else return false;
        }

        public void Reset(int a, int b)
        {
            x = a;
            y = b;

            Console.Write("Int32 -> ");
            Show();
        }

        public void Reset(double a, double b)
        {
            x = (int)a;
            y = (int)b;

            Console.Write("Double -> ");
            Show();
        }

        public void Show()
        {
            Console.WriteLine("x: {0}, y: {1}", x, y);
        }
    }

    class ReflectionExample
    {
        public static void TestReflectionExample()
        {
            Type t = typeof(Justing);

            Console.WriteLine("Analyzing methods in {0}\n", t.FullName);
            Console.WriteLine("Methods supported: ");

            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
            {
                Console.Write(" {0}\t\t{1}(", m.ReturnType.Name, m.Name);

                // Get the parameters
                ParameterInfo[] pi = m.GetParameters();
                if (0 < pi.Length)
                {
                    for (int i = 0; i < pi.Length; ++i)
                    {
                        Console.Write(pi[i].ParameterType.Name + " " + pi[i].Name + ((i == pi.Length - 1) ? ")\n" : ", "));
                    }
                }
                else
                {
                    Console.Write(")\n");
                }
            }

            // Invoke the method
            Justing just = new Justing(0, 0);
            foreach(MethodInfo m in mi)
            {
                if (0 == m.Name.CompareTo("Reset"))
                {
                    ParameterInfo[] pi = m.GetParameters();
                    if (typeof(int) == pi[0].ParameterType)
                    {
                        object[] args = { 10, 20};

                        m.Invoke(just, args);
                    }
                    else if(typeof(double) == pi[0].ParameterType)
                    {
                        object[] args = { 16.03, 24.87 };

                        m.Invoke(just, args);
                    }
                }
            }

            Type objType = typeof(System.Array);

            // Print the full assembly name.
            Console.WriteLine("Full assembly name: {0}.", objType.Assembly.FullName.ToString());

            // Print the qualified assembly name.
            Console.WriteLine("Qualified assembly name: {0}.", objType.AssemblyQualifiedName.ToString());
        }

        public static void TestReflectionExample2()
        {
            string dir = System.Environment.CurrentDirectory;
            // Load ReflectionTester
            Assembly asm = Assembly.Load(".\\ReflectionTester.exe");

            Console.WriteLine(asm.FullName);
        }
    }
}
