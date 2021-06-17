using Common.BusinessLogic.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogic.Test.Utilities
{

    /// <summary>
    /// Summary description for DateTimeToStringUtilityUnitTest
    /// </summary>
    [TestClass]
    public class DateTimeToStringUtilityUnitTest
    {
        public DateTimeToStringUtilityUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        public void TestMethod1()
        {
            string message = "test";
            string result = DateTimeToStringUtility.AddDateTime(message);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Contains(message));
        }
    }
}
