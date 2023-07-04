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
            Assert.Equal(new float[][] {new float[] {1, 2 , 1}, new float[] {1, 2 ,0} },LinearSystem.Decode(testInput));
        }
        [Fact]
        public void LinearSubtractionTest()
        {
            var test = LinearSystem.Decode(testInput);
            LinearSystem.subtractLinear(test[0], test[1], 2);
            Assert.Equal(new float[] { -1, -2, 1 }, test[0]); 
        }
    }
}
