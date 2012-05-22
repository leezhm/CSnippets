// 
// ConstructorAndDestructor.cs
//  
// Author:
//       leezhm <leezhm(at)126.com>
// 
// Copyright (c) 2012 leezhm(at)126.com
// 
// Created:
//       leezhm <2012/5/22> 
// 
// Modified:
//       leezhm <2012/5/22> 
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

namespace CSnippets.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using System.Diagnostics;

    public class First
    {
        public First()
        {
            Trace.WriteLine("First's Constructor is called ... ");
        }

        ~First()
        {
            Trace.WriteLine("First's Destructor is called ... ");
        }
    }

    public class Second : First
    {
        public Second()
        {
            Trace.WriteLine("Second's Constructor is called ... ");
        }

        ~Second()
        {
            Trace.WriteLine("Second's Destructor is called ... ");
        }
    }

    public class Third : Second
    {
        public Third()
        {
            Trace.WriteLine("Third's Constructor is called ... ");
        }

        ~Third()
        {
            Trace.WriteLine("Third's Destructor is called ... ");
        }
    }

    public struct DefaultStruct
    {
        public DefaultStruct(int e)
        {
        }

        public DefaultStruct(short k)
        {
        }
    }

    public class Employee
    {
        private double Salary
        {
            get;
            set;
        }

        public Employee(double salary)
        {
            Salary = salary;
        }

        //public Employee(double weeklySalary, int NumberOfWeeks)
        //{
        //    Salary = weeklySalary * (double)NumberOfWeeks;
        //}

        public Employee(double weeklySalary, int NumberOfWeeks)
            : this(weeklySalary * (double)NumberOfWeeks)
        {
        }
    }

    public class Manager : Employee
    {

        public Manager(double salary):base(salary)
        {
            //
        }
    }

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ConstructorAndDestructor
    {
        public static void TestIt()
        {
            Third td = new Third();

            Manager m = new Manager(35000);
        }
    }
}
