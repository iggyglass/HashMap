using HashMap;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Insert()
        {
            HashMap<int, string> map = new HashMap<int, string>();

            map.Insert(1, "a");
            map.Insert(2, "b");
            map.Insert(3, "c");

            Assert.Equal("b", map[2]);
        }

        [Fact]
        public void Remove()
        {
            HashMap<int, string> map = new HashMap<int, string>();

            map.Insert(1, "a");
            map.Insert(2, "b");
            map.Insert(3, "c");

            Assert.True(map.Exists(2));

            map.Remove(2);

            Assert.False(map.Exists(2));
        }

        [Fact]
        public void Set()
        {
            HashMap<int, string> map = new HashMap<int, string>();

            map.Insert(1, "a");
            map.Insert(2, "b");
            map.Insert(3, "c");

            Assert.Equal("b", map[2]);

            map[2] = "e";

            Assert.Equal("e", map[2]);
        }
    }
}
