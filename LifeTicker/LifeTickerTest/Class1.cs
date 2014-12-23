using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
namespace LifeTickerTest
{
    public class Class1
    {
        [Theory]
        [InlineData(1,"1")]
        public void PassingTest(int a, string b) {
            Assert.Equal(a, (int)Int32.Parse(b));
        }

        [Fact]
        public void anthTest() {
            Assert.Equal(1, 1);
        }
    }
}
