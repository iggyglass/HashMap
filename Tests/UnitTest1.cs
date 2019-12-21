using System;
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
    }
}
