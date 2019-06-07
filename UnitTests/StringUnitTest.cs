using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class StringUnitTest
    {
        public static string inputString = ConfigurationManager.AppSettings["startingStr"];
        string expectedValidOutput = ConfigurationManager.AppSettings["validOutput"];
        string expectedInValidOutput = ConfigurationManager.AppSettings["invalidOutput"];


        [TestMethod]
        public void TestMethodAreEqual()
        {
            
            string dbString = GetMockString();

            //get our result and test againt equality
            string result = StringsWork.ReverseTestCase(dbString);
            Assert.AreEqual(result, expectedValidOutput);
        }

        [TestMethod]
        public void TestMethodAreNotEqual()
        {
            
            string dbString = GetMockString();

            //get our result and test againt equality
            string result = StringsWork.ReverseTestCase(dbString);
            Assert.AreNotEqual(result, expectedInValidOutput);
        }

        [TestMethod]
        public void TestMethodNullString()
        {
            string expectedResult = null;
            string workString = null;

            //get our result and test against null string
            string result = StringsWork.ReverseTestCase(workString);
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void TestMethodEmptyString()
        {
            string expectedResult = string.Empty;
            string workString = "    ";

            //get our result and test against null string
            string result = StringsWork.ReverseTestCase(workString);
            Assert.AreEqual(result, expectedResult);
        }

        private string GetMockString()
        {
            //get the mock string from the mock database
            DbRepository db = new DbRepository();
            var dbMoq = new Mock<IDbRepository>();

            dbMoq.Setup(a => a.GetDbValue()).Returns(inputString);
            string exTst = dbMoq.Object.GetDbValue();
            Assert.AreEqual(exTst, inputString);

            return exTst;
        }
    }
}
