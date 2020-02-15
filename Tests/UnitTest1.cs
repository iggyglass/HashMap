using HashMap;
using UnionFind;
using Xunit;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Tests
{
    public class UnitTest1
    {

        #region Hash Map Tests

        [Fact]
        public void Insert()
        {
            HashMap<int, string> map = new HashMap<int, string>();

            map.Add(1, "a");
            map.Add(2, "b");
            map.Add(3, "c");

            Assert.Equal("b", map[2]);
        }

        [Fact]
        public void Remove()
        {
            HashMap<int, string> map = new HashMap<int, string>();

            map.Add(1, "a");
            map.Add(2, "b");
            map.Add(3, "c");

            Assert.True(map.ContainsKey(2));

            map.Remove(2);

            Assert.False(map.ContainsKey(2));
        }

        [Fact]
        public void Set()
        {
            HashMap<int, string> map = new HashMap<int, string>();

            map.Add(1, "a");
            map.Add(2, "b");
            map.Add(3, "c");

            Assert.Equal("b", map[2]);

            map[2] = "e";

            Assert.Equal("e", map[2]);
        }

        [Fact]
        public void Indexer()
        {
            HashMap<int, string> map = new HashMap<int, string>();

            map.Add(1, "a");

            Assert.Equal("a", map[1]);

            map[1] = "b";

            Assert.Equal("b", map[1]);
        }

        [Fact]
        public void TryGetValue()
        {
            HashMap<int, string> map = new HashMap<int, string>();

            map.Add(1, "a");
            map.Add(2, "b");
            map.Add(3, "c");

            string val;

            Assert.False(map.TryGetValue(4, out val));
            Assert.True(map.TryGetValue(3, out val));
            Assert.Equal("c", val);
        }

        [Fact]
        public void Copy()
        {
            KeyValuePair<int, string>[] data = new KeyValuePair<int, string>[5];
            HashMap<int, string> map = new HashMap<int, string>();

            KeyValuePair<int, string>[] expected = new KeyValuePair<int, string>[]
            {
                new KeyValuePair<int, string>(4, "d"),
                new KeyValuePair<int, string>(5, "e"),
                new KeyValuePair<int, string>(1, "a"),
                new KeyValuePair<int, string>(2, "b"),
                new KeyValuePair<int, string>(3, "c")
            };

            map.Add(1, "a");
            map.Add(2, "b");
            map.Add(3, "c");

            data[0] = new KeyValuePair<int, string>(4, "d");
            data[1] = new KeyValuePair<int, string>(5, "e");

            map.CopyTo(data, 2);

            Assert.Equal(expected, data);
        }

        [Fact]
        [SuppressMessage("Assertions", "xUnit2013:Do not use equality check to check for collection size.", Justification = "This is a unit test checking if count works.")]
        public void Count()
        {
            HashMap<int, string> map = new HashMap<int, string>();

            map.Add(1, "a");
            map.Add(2, "b");
            map.Add(3, "c");

            Assert.Equal(3, map.Count);

            map.Remove(2);

            Assert.Equal(2, map.Count);

            map.Clear();

            Assert.Equal(0, map.Count);
        }

        [Fact]
        public void GetKeysAndValues()
        {
            HashMap<int, string> map = new HashMap<int, string>();

            int[] expectedKeys = new int[] { 1, 2, 3 };
            string[] expectedValues = new string[] { "a", "b", "c" };

            map.Add(1, "a");
            map.Add(2, "b");
            map.Add(3, "c");

            Assert.Equal(expectedKeys, map.Keys);
            Assert.Equal(expectedValues, map.Values);
        }

        [Fact]
        [SuppressMessage("Assertions", "xUnit2017:Do not use Contains() to check if a value exists in a collection", Justification = "This is a unit test checking if contains works.")]
        public void ContainsTest()
        {
            HashMap<int, string> map = new HashMap<int, string>();

            map.Add(1, "a");
            map.Add(2, "b");
            map.Add(3, "c");

            KeyValuePair<int, string> containsA = new KeyValuePair<int, string>(1, "a");
            KeyValuePair<int, string> containsB = new KeyValuePair<int, string>(1, "b");

            Assert.True(map.Contains(containsA));
            Assert.False(map.Contains(containsB));

            Assert.True(map.ContainsKey(1));
            Assert.False(map.ContainsKey(4));
        }

        [Fact]
        [SuppressMessage("Assertions", "xUnit2017:Do not use Contains() to check if a value exists in a collection", Justification = "This test is to check if all values have been enumerated through")]
        public void Enumeration()
        {
            HashMap<int, string> map = new HashMap<int, string>();

            KeyValuePair<int, string> a = new KeyValuePair<int, string>(1, "a");
            KeyValuePair<int, string> b = new KeyValuePair<int, string>(2, "b");
            KeyValuePair<int, string> c = new KeyValuePair<int, string>(3, "c");

            List<KeyValuePair<int, string>> data = new List<KeyValuePair<int, string>>();

            map.Add(1, "a");
            map.Add(2, "b");
            map.Add(3, "c");

            foreach (var kvp in map)
            {
                data.Add(kvp);
            }

            Assert.True(data.Contains(a));
            Assert.True(data.Contains(b));
            Assert.True(data.Contains(c));
        }

        #endregion

        #region Union Find Tests

        // Integer Quick Find Union Find
        [Fact]
        public void IntUnion()
        {
            IntegerUnionFind uf = new IntegerUnionFind(13);

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

            Assert.False(uf.IsConnected(2, 5));
            Assert.True(uf.IsConnected(7, 12));
            Assert.False(uf.IsConnected(6, 8));
            Assert.True(uf.IsConnected(0, 12));
        }

        [Fact]
        public void IntFind()
        {
            IntegerUnionFind uf = new IntegerUnionFind(13);

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

            Assert.Equal(12, uf.Find(0));
            Assert.Equal(5, uf.Find(4));
        }

        // Generic Union Find
        [Fact]
        public void GenericUnion()
        {
            int[] vals = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            UnionFind<int> uf = new UnionFind<int>(vals);

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

            Assert.False(uf.IsConnected(2, 5));
            Assert.True(uf.IsConnected(7, 12));
            Assert.False(uf.IsConnected(6, 8));
            Assert.True(uf.IsConnected(0, 12));
        }

        [Fact]
        public void GenericFind()
        {
            int[] vals = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            UnionFind<int> uf = new UnionFind<int>(vals);

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

            Assert.Equal(12, uf.Find(0));
            Assert.Equal(5, uf.Find(4));
        }

        // Integer Quick Union
        [Fact]
        public void QuickUnion()
        {
            QuickUnion uf = new QuickUnion(13);

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

            Assert.False(uf.IsConnected(2, 5));
            Assert.True(uf.IsConnected(7, 12));
            Assert.False(uf.IsConnected(6, 8));
            Assert.True(uf.IsConnected(0, 12));
        }

        [Fact]
        public void QuickUnionFind()
        {
            QuickUnion uf = new QuickUnion(13);

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

            Assert.Equal(12, uf.Find(0));
            Assert.Equal(5, uf.Find(4));
        }

        #endregion
    }
}
