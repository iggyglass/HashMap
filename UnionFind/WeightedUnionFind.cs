namespace UnionFind
{
    public class WeightedUnionFind
    {

        private int[] data;
        private int[] size;

        /// <summary>
        /// Initializes a new Weighted Quick Union Union Find data 
        /// structure with n elements
        /// </summary>
        /// <param name="n">The number of elements in the data structure</param>
        public WeightedUnionFind(int n)
        {
            data = new int[n];
            size = new int[n];

            for (int i = 0; i < n; i++)
            {
                data[i] = i;
                size[i] = 1;
            }
        }

        /// <summary>
        /// Finds element a in Union Find data structure
        /// </summary>
        /// <param name="a">The element to find</param>
        /// <returns>The tree which element a is a part</returns>
        public int Find(int a)
        {
            while (a != data[a])
            {
                a = data[a];
            }

            return a;
        }

        /// <summary>
        /// Returns whether the two elements are connected
        /// </summary>
        /// <param name="a">The first element to check</param>
        /// <param name="b">The second element to check</param>
        /// <returns>Whether the two elements are connected</returns>
        public bool IsConnected(int a, int b)
        {
            return Find(a) == Find(b);
        }

        /// <summary>
        /// Creates a Union between elements a and b
        /// </summary>
        /// <param name="a">The first element to connect</param>
        /// <param name="b">The second element to connect</param>
        public void Union(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if (rootA == rootB) return;

            if (size[rootA] < size[rootB])
            {
                data[rootA] = rootB;
                size[rootB] += size[rootA];
            }
            else
            {
                data[rootB] = rootA;
                size[rootA] += size[rootB];
            }
        }
    }
}
