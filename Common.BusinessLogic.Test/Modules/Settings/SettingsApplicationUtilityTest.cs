using Common.BusinessLogic.Modules.Settings.Utilities;
using Common.BusinessModels.Modules.Models;
using Common.Utilities.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.BusinessLogic.Test.Modules.Settings
{
    [TestClass]
    public class SettingsApplicationUtilityTest 
    {
        [TestMethod]
        public void SettingsElements()
        {
            SettingsApplicationUtility utility = new SettingsApplicationUtility();
            ResponseOperation responseOperation = utility.SaveSettingsElements(new SettingsApplicationModel());
            Assert.IsNotNull(responseOperation);
            Assert.IsTrue(responseOperation.OperationStatus);            
        }
    }
}
