using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebApp_Common_Helper
{
    public class EncryptionHelper
    {
        private const string EncryptionKey = "PeDH2+TQIenNiawHM0eNL3hPPZ+WZwsjzWSAYRhZ5/s="; // Replace with your own encryption key
        private const int KeySize = 256;
        public static string GenerateEncryptionKey()
        {
            using (var aes = Aes.Create())
            {
                aes.KeySize = 256; // Set the key size to 256 bits
                aes.GenerateKey();
                return Convert.ToBase64String(aes.Key);
            }
        }
        public static string EncryptId(int id)
        {
            byte[] idBytes = BitConverter.GetBytes(id);
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(idBytes, 0, idBytes.Length);
                        csEncrypt.FlushFinalBlock();
                        byte[] encryptedBytes = msEncrypt.ToArray();
                        return Convert.ToBase64String(encryptedBytes);
                    }
                }
            }
        }

        public static int DecryptId(string encryptedId)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedId);
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];

                using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, aesAlg.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] decryptedBytes = new byte[4]; // Assuming the ID is represented as 4 bytes (int)
                        csDecrypt.Read(decryptedBytes, 0, decryptedBytes.Length);
                        return BitConverter.ToInt32(decryptedBytes, 0);
                    }
                }
            }
        }
    }
}
