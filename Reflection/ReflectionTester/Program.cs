

namespace ReflectionTester
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using System.Reflection;

    class ReflectionTester
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int Area
        {
            get
            {
                return Width * Height;
            }
        }

        public ReflectionTester(int w, int h)
        {
            Width = w;
            Height = h;
        }

        public ReflectionTester(double w, double h)
            : this((int)w, (int)h)
        {

        }

        public ReflectionTester(int i)
            : this(i, i)
        {
        }

        public ReflectionTester()
            : this(10, 20)
        {
        }

        public int Primeter()
        {
            return (Width + Height) * 2;
        }

        public void Show()
        {
            Console.WriteLine("Size are Width: {0}, Height:{1} and Area is {2}", Width, Height, Area);
        }
    }

    class Reflector
    {
        public string Msg { get; private set; }

        public Reflector(string str)
        {
            Msg = str;
        }

        public void Show()
        {
            Console.WriteLine("Current Message : {0}", Msg);
        }
    }

    class ReflectionDemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
        }
    }
}
