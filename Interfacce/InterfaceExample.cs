// 
// InterfaceExample.cs
//  
// Author:
//       leezhm <leezhm(at)126.com>
// 
// Copyright (c) 2012 leezhm(at)126.com
// 
// Created:
//       leezhm <2012/5/29> 
// 
// Modified:
//       leezhm <2012/5/29> 
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

namespace CSnippets.Interfacce
{
    interface ISharp
    {
        double Area();
    }

    interface IRegualSharp : ISharp
    {
        double Width
        {
            get;
            set;
        }

        double Height
        {
            get;
            set;
        }
    }

    internal class Rectangle : IRegualSharp
    {
        private double width = 0.0f;
        private double height = 0.0f;

        public double Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        public double Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public Rectangle(double w, double h)
        {
            Width = w;
            Height = h;
        }

        public double Area()
        {
            return Width * Height;
        }
    }

    class InterfaceExample
    {
        public static void TestInterfaceExample()
        {
            Rectangle rt = new Rectangle(20.5, 45.2f);
            Console.WriteLine("Area({0}) = Width({1}) * Height({2})", rt.Area(), rt.Width, rt.Height);
        }
    }
}
