namespace UnionFind
{
    public class IntegerUnionFind
    {

        private int[] data;

        /// <summary>
        /// Initializes a Union find data structure with n elements
        /// </summary>
        /// <param name="n">The number of elements</param>
        public IntegerUnionFind(int n)
        {
            data = new int[n];

            for (int i = 0; i < n; i++)
            {
                data[i] = i;
            }
        }

        /// <summary>
        /// Checks if a and b are connected
        /// </summary>
        /// <param name="a">The first node</param>
        /// <param name="b">The second node</param>
        /// <returns>Whether a and b are connected</returns>
        public bool IsConnected(int a, int b)
        {
            return Find(a) == Find(b);
        }

        /// <summary>
        /// Creates a union between sets a and b
        /// </summary>
        /// <param name="a">The first node</param>
        /// <param name="b">The second node</param>
        public void Union(int a, int b)
        {
            int tmp = data[a];

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == tmp) data[i] = b;
            }
        }

        /// <summary>
        /// Finds which set node a is in
        /// </summary>
        /// <param name="a">The node to find</param>
        /// <returns>The set in which node a is a part</returns>
        public int Find(int a)
        {
            return data[a];
        }
    }
}
