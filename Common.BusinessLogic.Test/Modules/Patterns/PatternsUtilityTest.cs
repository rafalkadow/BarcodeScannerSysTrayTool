using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace Common.BusinessLogic.Test.Modules.Patterns
{
    [TestClass]
    public class PatternsUtilityTest
    {
        [TestMethod]
        public void PatternsElementsOrders()
        {
            //7000XXXXXX/XXXXX
            string barcode = "7000123456/12345";
            var pattern = @"^7000\d{6}/\d{5}";
            var parser = new Regex(pattern);
          
            var match = parser.Match(barcode);
            if (!match.Success)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void PatternsElementsMaterials()
        {
            //500XXXXXXX/XXXX
            string barcode = "5001234567/1234";
            var pattern = @"^500\d{7}/\d{4}";
            var parser = new Regex(pattern);
            
            var match = parser.Match(barcode);
            if (!match.Success)
            {
                Assert.Fail();
            }
        }
    }
}
