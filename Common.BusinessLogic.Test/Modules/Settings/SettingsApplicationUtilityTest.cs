using Common.BusinessLogic.Modules.Settings.Utilities;
using Common.BusinessModels.Modules.Models;
using Common.Utilities.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Common.BusinessLogic.Test.Modules.Settings
{
    [TestClass]
    public class SettingsApplicationUtilityTest
    {
        [TestMethod]
        public void SettingsElements()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), "BarcodeScannerSysTrayToolTests", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(tempDir);

            string exePath = Path.Combine(tempDir, "TestHost.exe");
            string configPath = exePath + ".config";

            try
            {
                File.WriteAllText(exePath, string.Empty);
                File.WriteAllText(configPath, @"<?xml version=""1.0"" encoding=""utf-8""?>
<configuration>
  <appSettings />
</configuration>");

                var settingsApplicationModel = new SettingsApplicationModel
                {
                    ExecutablePath = exePath,
                    Delay1 = 0.1,
                    Delay2 = 0.3,
                    Delay3 = 2.0,
                    PasswordSettings = "Password",
                    AskedClosing = false,
                    IsPasswordOnApplication = false,
                    PatternRegexCollection = string.Empty,
                    DefineTheSequence = "Barcode + Return"
                };

                SettingsApplicationUtility utility = new SettingsApplicationUtility();
                ResponseOperation responseOperation = utility.SaveSettingsElements(settingsApplicationModel);

                Assert.IsNotNull(responseOperation);
                Assert.IsTrue(responseOperation.OperationStatus, responseOperation.Exception);

                SettingsApplicationModel loaded = utility.LoadDataSettings(exePath);
                Assert.AreEqual(settingsApplicationModel.Delay1, loaded.Delay1, 0.001);
                Assert.AreEqual(settingsApplicationModel.Delay2, loaded.Delay2, 0.001);
                Assert.AreEqual(settingsApplicationModel.Delay3, loaded.Delay3, 0.001);
                Assert.AreEqual(settingsApplicationModel.DefineTheSequence, loaded.DefineTheSequence);
            }
            finally
            {
                if (Directory.Exists(tempDir))
                {
                    Directory.Delete(tempDir, true);
                }
            }
        }
    }
}
