using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService_AlarmSystem;

namespace UnitTestProject_AlarmSystem
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Service1 ggg = new Service1();

            ggg.GetData(6);
            string gggg = "You entered: 6"; 

            Assert.AreEqual(ggg.GetData(6), gggg);
        }
    }
}
