using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService_AlarmSystem;

namespace UnitTestProject_AlarmSystem
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_AlarmStatusIsSmallerThan2()
        {
            Service1 TestService = new Service1();
            Assert.IsTrue(TestService.GetAlarmStatus() < 2);
        }

        [TestMethod]
        public void TestMethod_AlarmStatusIsLargerThan0()
        {
            Service1 TestService = new Service1();
            Assert.IsTrue(TestService.GetAlarmStatus() >= 0);
        }
    }
}
