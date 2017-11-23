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

            ggg.GetData();
            string gggg = "FROM REST_SERVICE: GetData called"; 

            Assert.AreEqual(ggg.GetData(), gggg);
        }
    }
}
