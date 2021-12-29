using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace Nuages.Web.Utilities;

 public interface IEncryption
    {
        // ReSharper disable once UnusedMemberInSuper.Global
        string Encrypt(string input, string password);
        // ReSharper disable once UnusedMemberInSuper.Global
        string Decrypt(string input, string password);
        string EncryptWithSalt(string text, string password);
        string DecryptWithSalt(string text, string password);
    }

    public class Encryption : IEncryption
    {
        private static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] saltBytes = {1, 2, 3, 4, 5, 6, 7, 8};
            using MemoryStream ms = new();

            using Aes aes = Aes.Create();

            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);
            aes.Mode = CipherMode.CBC;
            using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                cs.Close();
            }

            var encryptedBytes = ms.ToArray();

            return encryptedBytes;
        }

        private static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] saltBytes = {1, 2, 3, 4, 5, 6, 7, 8};

            using MemoryStream ms = new();

            using Aes aes = Aes.Create();
            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);
            aes.Mode = CipherMode.CBC;
            using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                cs.Close();
            }

            var decryptedBytes = ms.ToArray();

            return decryptedBytes;
        }

        public string Encrypt(string input, string password)
        {
            // Get the bytes of the string
            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            var result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }

        public string Decrypt(string input, string password)
        {
            // Get the bytes of the string
            var bytesToBeDecrypted = Convert.FromBase64String(input);
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            var result = Encoding.UTF8.GetString(bytesDecrypted);

            return result;
        }

        public string EncryptWithSalt(string text, string password)
        {
            var baPwd = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            var baPwdHash = SHA256.Create().ComputeHash(baPwd);

            var baText = Encoding.UTF8.GetBytes(text);

            var baSalt = GetRandomBytes();
            var baEncrypted = new byte[baSalt.Length + baText.Length];

            // Combine Salt + Text
            for (var i = 0; i < baSalt.Length; i++)
                baEncrypted[i] = baSalt[i];
            for (var i = 0; i < baText.Length; i++)
                baEncrypted[i + baSalt.Length] = baText[i];

            baEncrypted = AES_Encrypt(baEncrypted, baPwdHash);

            var result = Convert.ToBase64String(baEncrypted);
            return result;
        }

        public string DecryptWithSalt(string text, string password)
        {
            var baPwd = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            var baPwdHash = SHA256.Create().ComputeHash(baPwd);

            var baText = Convert.FromBase64String(text);

            var baDecrypted = AES_Decrypt(baText, baPwdHash);

            // Remove salt
            var saltLength = GetSaltLength();
            var baResult = new byte[baDecrypted.Length - saltLength];
            for (var i = 0; i < baResult.Length; i++)
                baResult[i] = baDecrypted[i + saltLength];

            var result = Encoding.UTF8.GetString(baResult);
            return result;
        }

        private static byte[] GetRandomBytes()
        {
            var saltLength = GetSaltLength();
            var ba = new byte[saltLength];
            RandomNumberGenerator.Create().GetBytes(ba);
            return ba;
        }

        private static int GetSaltLength()
        {
            return 8;
        }
    }
    
[ExcludeFromCodeCoverage]
public static class EncryptionConfig
{
    // ReSharper disable once UnusedMethodReturnValue.Global
    // ReSharper disable once UnusedMember.Global
    public static IServiceCollection AddEncryption(this IServiceCollection services)
    {
        services.AddTransient<IEncryption, Encryption>();

        return services;
    }
}