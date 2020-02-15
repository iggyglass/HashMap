namespace UnionFind
{
    // Integer implimentation of quick union
    public class QuickUnion
    {

        private int[] data;

        /// <summary>
        /// Initializes a Quick Union Union Find data structure with n elements
        /// </summary>
        /// <param name="n">The number of elements</param>
        public QuickUnion(int n)
        {
            data = new int[n];

            for (int i = 0; i < n; i++)
            {
                data[i] = i;
            }
        }

        /// <summary>
        /// Finds which set node a is in
        /// </summary>
        /// <param name="a">The node to find</param>
        /// <returns>The set node a is in</returns>
        public int Find(int a)
        {
            while (a != data[a])
            {
                a = data[a];
            }

            return a;
        }

        /// <summary>
        /// Checks if nodes a and b are in the same set
        /// </summary>
        /// <param name="a">The first node</param>
        /// <param name="b">The second node</param>
        /// <returns>Whether the nodes are in the same set</returns>
        public bool IsConnected(int a, int b)
        {
            return Find(a) == Find(b);
        }

        /// <summary>
        /// Puts nodes a and b into the same set
        /// </summary>
        /// <param name="a">The first node</param>
        /// <param name="b">The second node</param>
        public void Union(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if (rootA == rootB) return;

            data[rootA] = rootB;
        }
    }
}
