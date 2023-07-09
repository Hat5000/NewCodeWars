using CodeWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class LinearSystemTest
    {
        private string testInput = "1 2 1\r\n1 2 0";

        [Fact]
        public void DecodeTest() 
        {
            Assert.Equal(new double[][] {new double[] {1, 2 , 1}, new double[] {1, 2 ,0} },LinearSystem.Decode(testInput));
        }
        [Fact]
        public void LinearSubtractionTest()
        {
            var test = LinearSystem.Decode(testInput);
            LinearSystem.subtractLinear(test[0], test[1], 2);
            Assert.Equal(new double[] { -1, -2, 1 }, test[0]); 
        }
        [Fact]
        public void GcdTest() {
            Assert.Equal(12, Fractal.Gcd(60, 24));
        }
    }
}
