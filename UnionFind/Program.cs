using System;

namespace UnionFind
{
    class Program
    {
        static void Main(string[] args)
        {
            IntegerUnionFind uf = new IntegerUnionFind(13);

            ;

            uf.Union(0, 1);
            uf.Union(1, 2);
            uf.Union(4, 5);
            uf.Union(0, 3);
            uf.Union(7, 8);
            uf.Union(8, 9);
            uf.Union(6, 11);
            uf.Union(11, 10);
            uf.Union(9, 12);
            uf.Union(1, 12);

            bool a = uf.IsConnected(2, 5);
            bool b = uf.IsConnected(7, 12);
            bool c = uf.IsConnected(6, 8);
            bool d = uf.IsConnected(0, 12);

            ;
        }
    }
}
