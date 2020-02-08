using System;
using System.Collections.Generic;
using System.Text;
using HashMap;

namespace UnionFind
{
    public class UnionFind<T>
    {

        private HashMap<T, int> data;

        /// <summary>
        /// Initializes a Union Find data structure with items
        /// </summary>
        /// <param name="items">The items to include in Union Find</param>
        public UnionFind(IEnumerable<T> items)
        {
            data = new HashMap<T, int>();
            int count = 0;

            // 11 and 12 never get added to data -- the issue might be with add of the hash map

            foreach (T item in items)
            {
                if (count == 11) ;

                data.Add(item, count);
                count++;
            }
        }

        /// <summary>
        /// Returns true if a and b are connected
        /// </summary>
        /// <param name="a">The first set</param>
        /// <param name="b">The second set</param>
        /// <returns>Whether a and b are connected</returns>
        public bool IsConnected(T a, T b)
        {
            return Find(a) == Find(b);
        }

        /// <summary>
        /// Creates a union between sets a and b
        /// </summary>
        /// <param name="a">The first set</param>
        /// <param name="b">The second set</param>
        public void Union(T a, T b)
        {
            int tmp = data[a];

            foreach (KeyValuePair<T, int> item in data)
            {
                if (item.Value == tmp) data[item.Key] = data[b];
            }
        }

        /// <summary>
        /// Finds which set node a is in
        /// </summary>
        /// <param name="a">The node to find</param>
        /// <returns>The set in which node a is a part</returns>
        public int Find(T a)
        {
            return data[a];
        }
    }
}
