using System;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [TestMethod]
        public void TestMethod1()
        {
            Calculator c = new Calculator();
            c.setExpression("00..00025");
            Assert.AreEqual("0.00025", c.doSolve().ToString());
        }
        [TestMethod]
        public void TestMethod2()
        {
            Calculator c = new Calculator();
            c.setExpression("10+2=");
            Assert.AreEqual("12", c.doSolve().ToString());
        }
        [TestMethod]
        public void TestMethod3()
        {
            Calculator c = new Calculator();
            c.setExpression("10/0=");
            Assert.AreEqual("-E-", c.doSolve().ToString());
        }
        [TestMethod]
        public void TestMethod4()
        {
            Calculator c = new Calculator();
            c.setExpression("12+2sss=");
            Assert.AreEqual("10", c.doSolve().ToString());
        }
        [TestMethod]
        public void TestMethod5()
        {
            Calculator c = new Calculator();
            c.setExpression("1+2+3+=");
            Assert.AreEqual("12", c.doSolve().ToString());
        }
        [TestMethod]
        public void TestMethod6()
        {
            Calculator c = new Calculator();
            c.setExpression("1+2+c");
            Assert.AreEqual("0", c.doSolve().ToString());
        }

        [TestMethod]
        public void TestMethod7()
        {
            Calculator c = new Calculator();
            c.setExpression("20-9-8-=");
            Assert.AreEqual("0", c.doSolve().ToString());
        }
        [TestMethod]
        public void TestMethod8()
        {
            Calculator c = new Calculator();
            c.setExpression("10/5=");
            Assert.AreEqual("2", c.doSolve().ToString());
        }

    }
}
