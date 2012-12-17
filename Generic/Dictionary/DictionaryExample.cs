using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSnippets.Generic.Dictionary
{
    class DictionaryExample
    {
        public static void TestDictionaryExample()
        {
            Dictionary<uint, double> dict = new Dictionary<uint, double>();

            dict.Add(1, 1.4142135623731);
            dict.Add(2, 17.8044938147649);
            dict.Add(3, 9.21954445729289);
            dict.Add(4, 10.6301458127347);
            dict.Add(5, 11.4017542509914);
            dict.Add(6, 4);
            dict.Add(7, 13.8924439894498);
            dict.Add(8, 7.07106781186548);
            dict.Add(9, 5.3851648071345);
            dict.Add(10, 14.7648230602334);
            dict.Add(11, 13);
            dict.Add(12, 15.4142135623731);
            dict.Add(13, 13.6014705087354);

            IEnumerable<KeyValuePair<uint, double>> sort = from entry in dict
                                                           orderby entry.Value ascending
                                                           select entry;
            dict = sort.ToDictionary(pair => pair.Key, pair => pair.Value);

            Console.WriteLine("{0, -4} {1, -16}", "Key", "Value");
            foreach (var item in dict)
            {
                Console.WriteLine("{0, -4} {1, -16}", item.Key, item.Value);
            }
            Console.WriteLine("\n\n");
        }

        public static void TestDictionaryExample1()
        {
            ArrayList al = new ArrayList();
            al.Add(new Dictionary<uint, double>());
            Dictionary<uint, double> dict = (Dictionary<uint, double>)al[0];

            dict.Add(1, 1.4142135623731);
            dict.Add(2, 17.8044938147649);
            dict.Add(3, 9.21954445729289);
            dict.Add(4, 10.6301458127347);
            dict.Add(5, 11.4017542509914);
            dict.Add(6, 4);
            dict.Add(7, 13.8924439894498);
            dict.Add(8, 7.07106781186548);
            dict.Add(9, 5.3851648071345);
            dict.Add(10, 14.7648230602334);
            dict.Add(11, 13);
            dict.Add(12, 15.4142135623731);
            dict.Add(13, 13.6014705087354);

            IEnumerable<KeyValuePair<uint, double>> sort = from entry in dict
                                                           orderby entry.Value ascending
                                                           select entry;
            dict = sort.ToDictionary(pair => pair.Key, pair => pair.Value);

            int k = 8;

            Console.WriteLine("{0, -4} {1, -16}", "Key", "Value");
            foreach (var item in dict)
            {
                Console.WriteLine("{0, -4} {1, -16}", item.Key, item.Value);
            }
            Console.WriteLine("\n\n");

            al.RemoveAt(0);
            al.Insert(0, dict);

            Console.WriteLine("{0, -4} {1, -16} -----ArrayList", "Key", "Value");
            foreach (var item in (Dictionary<uint, double>)al[0])
            {
                Console.WriteLine("{0, -4} {1, -16}", item.Key, item.Value);
            }
            Console.WriteLine("\n\n");

            Dictionary<uint, double> afterSort = new Dictionary<uint, double>();
            afterSort = sort.ToDictionary(pair => pair.Key, pair => pair.Value);

            Console.WriteLine("{0, -4} {1, -16} ---- After Sort ----", "Key", "Value");
            foreach (var item in afterSort)
            {
                Console.WriteLine("{0, -4} {1, -16}", item.Key, item.Value);
            }
            Console.WriteLine("\n\n");

            al.Add(afterSort);

            Console.WriteLine("{0, -4} {1, -16} -----ArrayList", "Key", "Value");
            foreach (var item in (Dictionary<uint, double>)al[1])
            {
                Console.WriteLine("{0, -4} {1, -16}", item.Key, item.Value);
            }
            Console.WriteLine("\n\n");
        }

        #region Test Reference in Dict
        public class Point
        {
            public float X { get; private set; }
            public float Y { get; private set; }

            public Point(float x, float y)
            {
                this.X = x;
                this.Y = y;
            }

            public override string ToString()
            {
                return "(" + this.X + ", " + this.Y + ")" ;
            }
        }

        public static void TestDictionaryExample2()
        {
            Dictionary<int, Point> dictPoint = new Dictionary<int, Point>();

            for (int i = 0; i < 10; ++i)
            {
                dictPoint.Add(i, new Point((float)i * i, (float)i + i));
            }

            Console.WriteLine("TestDictionaryExample2 ----- ");
            foreach (var item in dictPoint)
	        {
		        Console.WriteLine(item.ToString());
	        }

            // update
            Point p = new Point(1000.0f, 1000.0f);
            dictPoint[3] = p;

            try
            {
                dictPoint[300] = p;
            }
            catch (System.Collections.Generic.KeyNotFoundException expt)
            {
                Console.WriteLine(expt.ToString());
            }

            dictPoint.Remove(7);
            dictPoint.Remove(100);

            Console.WriteLine("\n ----Update ----- ");
            foreach (var item in dictPoint)
            {
                Console.WriteLine(item.ToString());
            }
        }
        #endregion // Test Reference in Dict
    }
}
