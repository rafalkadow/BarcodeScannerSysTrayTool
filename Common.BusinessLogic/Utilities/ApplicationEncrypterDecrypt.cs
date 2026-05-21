using NLog;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common.BusinessLogic.Utilities
{
    public class ApplicationEncrypterDecrypt
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static readonly byte[] PublicKeyBytes = Encoding.UTF8.GetBytes("12345678");
        private static readonly byte[] SecretKeyBytes = Encoding.UTF8.GetBytes("87654321");

        public static string Encrypt(string textToEncrypt)
        {
            if (string.IsNullOrEmpty(textToEncrypt))
            {
                return string.Empty;
            }

            try
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(textToEncrypt);
                using (var des = new DESCryptoServiceProvider())
                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, des.CreateEncryptor(PublicKeyBytes, SecretKeyBytes), CryptoStreamMode.Write))
                {
                    cs.Write(inputBytes, 0, inputBytes.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Encrypt failed");
                return string.Empty;
            }
        }

        public static string Decrypt(string textToDecrypt)
        {
            if (string.IsNullOrEmpty(textToDecrypt))
            {
                return string.Empty;
            }

            if (!LooksLikeEncryptedValue(textToDecrypt))
            {
                return textToDecrypt;
            }

            try
            {
                byte[] inputBytes = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
                using (var des = new DESCryptoServiceProvider())
                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, des.CreateDecryptor(PublicKeyBytes, SecretKeyBytes), CryptoStreamMode.Write))
                {
                    cs.Write(inputBytes, 0, inputBytes.Length);
                    cs.FlushFinalBlock();
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Decrypt failed");
                return string.Empty;
            }
        }

        private static bool LooksLikeEncryptedValue(string value)
        {
            if (value.Length < 12 || value.Length % 4 != 0)
            {
                return false;
            }

            try
            {
                byte[] data = Convert.FromBase64String(value.Replace(" ", "+"));
                return data.Length >= 8;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
