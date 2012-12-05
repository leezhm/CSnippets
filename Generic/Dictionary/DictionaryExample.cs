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

            Console.WriteLine("{0, -4} {1, -16}", "Key", "Value");
            foreach (var item in dict)
            {
                Console.WriteLine("{0, -4} {1, -16}", item.Key, item.Value);
            }
            Console.WriteLine("\n\n");

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
    }
}
