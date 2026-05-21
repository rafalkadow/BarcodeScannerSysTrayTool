using Common.BusinessLogic.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.BusinessLogic.Test.Utilities
{
    /// <summary>
    /// Summary description for ApplicationEncrypterDecryptUnitTest
    /// </summary>
    [TestClass]
    public class ApplicationEncrypterDecryptUnitTest
    {
        public ApplicationEncrypterDecryptUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        public void TestMethod1()
        {
            string message = "test";
            string resultEncrypt = ApplicationEncrypterDecrypt.Encrypt(message);
            string resultDescrypt = ApplicationEncrypterDecrypt.Decrypt(resultEncrypt);
            Assert.IsNotNull(resultDescrypt);
            Assert.AreEqual(message, resultDescrypt);
        }

        [TestMethod]
        public void Decrypt_ReturnsPlaintext_WhenValueIsNotEncrypted()
        {
            const string plaintextPassword = "Password";
            Assert.AreEqual(plaintextPassword, ApplicationEncrypterDecrypt.Decrypt(plaintextPassword));
        }

        [TestMethod]
        public void Encrypt_ReturnsEmpty_ForNullOrEmptyInput()
        {
            Assert.AreEqual(string.Empty, ApplicationEncrypterDecrypt.Encrypt(null));
            Assert.AreEqual(string.Empty, ApplicationEncrypterDecrypt.Encrypt(string.Empty));
        }
    }
}
