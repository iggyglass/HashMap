using HashMap;
using Xunit;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Tests
{
    public class UnitTest1
    {
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
    }
}
