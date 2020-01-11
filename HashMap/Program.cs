using System;
using System.Collections.Generic;

namespace HashMap
{
    class Program
    {
        static void Main(string[] args)
        {
            HashMap<int, string> map = new HashMap<int, string>(5);

            map.Add(1, "a");
            map.Add(2, "b");
            map.Add(3, "c");

            KeyValuePair<int, string>[] data = new KeyValuePair<int, string>[16];

            map.CopyTo(data, 0);

            Console.ReadKey();
        }
    }
}
