using System;

namespace UnionFind
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vals = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            UnionFind<int> uf = new UnionFind<int>(vals);

            ;

            uf.Union(0, 1);
            uf.Union(1, 2);
            uf.Union(4, 5);
            uf.Union(0, 3);
            uf.Union(7, 8);
            uf.Union(8, 9);
            uf.Union(6, 11); // error?
            uf.Union(11, 10);
            uf.Union(9, 12);
            uf.Union(1, 12);

            bool a = uf.IsConnected(2, 5); // False
            bool b = uf.IsConnected(7, 12); // True
            bool c = uf.IsConnected(6, 8); // False
            bool d = uf.IsConnected(0, 12); // True

            ;
        }
    }
}
