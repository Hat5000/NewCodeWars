using CodeWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class AnagramTest
    {
        [Fact]
        public void newPossibilitiesTest1()
        {
            Assert.Equal(24, Anagrams.newPosibilities(60, 2, 5));
        }
        [Fact]
        public void newPossibilitiesTest2()
        {
            Assert.Equal(12, Anagrams.newPosibilities(40, 3, 5));
        }
        [Fact]
        public void newPossibilitiesTest3()
        {
            Assert.Equal(12, Anagrams.newPosibilities(30, 2, 5));
        }
        [Fact]
        public void newPossibilitiesTest4()
        {
            Assert.Equal(12, Anagrams.newPosibilities(60, 1, 5));
        }
        [Fact]
        public void newPossibilitiesTest5()
        {
            Assert.Equal(3, Anagrams.newPosibilities(4, 3, 4));
        }
    }
}
