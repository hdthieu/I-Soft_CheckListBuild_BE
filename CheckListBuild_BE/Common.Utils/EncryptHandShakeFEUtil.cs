using CheckListBuild_BE.Configs;
using CheckListBuild_BE.Entities;
using System.Security.Cryptography;
using System.Text;

namespace CheckListBuild_BE.Common.Utils
{
    public class EncryptHandshakeFEUtil
    {
        //public static string Encrypt(string source)
        //{
        //    if (string.IsNullOrEmpty(source))
        //    {
        //        return source;
        //    }

        //    string text = "";
        //    try
        //    {
        //        text = CommonConfig.EncryptHandshakeSecretKey;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error("Encrypt, " + ex.ToString());
        //        throw new BaseException(ex);
        //    }

        //    if (string.IsNullOrEmpty(text))
        //    {
        //        Log.Error("Encrypt, secretKey is empty");
        //        throw new BaseException("Encrypt, secretKey is empty");
        //    }

        //    if (MemCached.Instance.IsTimeToRun("_5m_ check_secretKey", 300000L))
        //    {
        //        Log.Information("Encrypt, secretKey: " + text.SubstringSafe(0, 4) + "***");
        //    }

        //    if (Encoding.UTF8.GetBytes(text).Length < 32)
        //    {
        //        throw new ArgumentException("Secret key must be at least 256 bits (32 characters)");
        //    }

        //    byte[] key = Encoding.UTF8.GetBytes(text).Take(32).ToArray();
        //    using Aes aes = Aes.Create();
        //    aes.Key = key;
        //    aes.GenerateIV();
        //    byte[] iV = aes.IV;
        //    using MemoryStream memoryStream = new MemoryStream();
        //    memoryStream.Write(iV, 0, iV.Length);
        //    using (ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV))
        //    {
        //        using CryptoStream stream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
        //        using StreamWriter streamWriter = new StreamWriter(stream);
        //        streamWriter.Write(source);
        //    }

        //    return Convert.ToBase64String(memoryStream.ToArray()).Replace("+", "-").Replace("/", "_")
        //        .Replace("=", "");
        //}

        public static string Decrypt(string encodedText)
        {
            if (string.IsNullOrEmpty(encodedText))
            {
                return encodedText;
            }

            try
            {
                encodedText = encodedText.Replace("-", "+").Replace("_", "/");
                while (encodedText.Length % 4 != 0)
                {
                    encodedText += "=";
                }

                byte[] source = Convert.FromBase64String(encodedText);
                string encryptHandshakeSecretKey = CommonConfig.EncryptHandshakeSecretKey;
                if (Encoding.UTF8.GetBytes(encryptHandshakeSecretKey).Length < 32)
                {
                    throw new ArgumentException("Secret key must be at least 256 bits (32 characters)");
                }

                byte[] key = Encoding.UTF8.GetBytes(encryptHandshakeSecretKey).Take(32).ToArray();
                using Aes aes = Aes.Create();
                aes.Key = key;
                byte[] iV = source.Take(16).ToArray();
                byte[] buffer = source.Skip(16).ToArray();
                aes.IV = iV;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                using ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);
                using MemoryStream stream = new MemoryStream(buffer);
                using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
                using StreamReader streamReader = new StreamReader(stream2);
                return streamReader.ReadToEnd();
            }
            catch (FormatException innerException)
            {
                throw new FormatException("The input is not a valid Base-64 string.", innerException);
            }
            catch (Exception ex)
            {
                throw new BaseException("An error occurred during decryption.", ex);
            }
        }
    }
}
