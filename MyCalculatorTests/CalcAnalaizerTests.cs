using System;
using CalcClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalcClassTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add_10and20_30returned()
        {
            // arrange

            int x = 10;
            int y = 20;
            int expected = 30;

            // act

            int actual = Calc.Add(x, y);

            // asset

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Div_10and2_5returned()
        {
            // arrange

            int x = 10;
            int y = 2;
            int expected = 5;

            // act

            int actual = Calc.Div(x, y);

            // asset

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Sub_3and2_6returned()
        {
            // arrange

            int x = 3;
            int y = 2;
            int expected = 1;

            // act

            int actual = Calc.Sub(x, y);

            // asset

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Mult_6and3_18returned()
        {
            // arrange

            int x = 6;
            int y = 3;
            int expected = 18;

            // act

            int actual = Calc.Sub(x, y);

            // asset

            Assert.AreEqual(expected, actual);

        }
        
        [TestMethod]
        public void Mod_10and2_0returned()
        {
            // arrange

            int x = 10;
            int y = 2;
            int expected = 0;

            // act

            int actual = Calc.Mod(x,y);

            // asset

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Abs_6_7returned()
        {
            // arrange

            int x = 6;
            int expected = 7;

            // act

            int actual = Calc.ABS(x);

            // asset

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void IAbs_6_5returned()
        {
            // arrange

            int x = 6;
            int expected = 5;

            // act

            int actual = Calc.IABS(x);

            // asset

            Assert.AreEqual(expected, actual);

        }




    }
}
