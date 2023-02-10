using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace Help.Script.Help.Utility
{
    public interface IUtilityFile
    {
        bool KeyExist(string key);
        void SaveString(string key, string value);
        string LoadString(string key);

        void SaveInt(string key, int value);
        int LoadInt(string key);


        void SaveFloat(string key, float value);
        float LoadFloat(string key);
    }

    public class UtilitySimplePLayerPrefs : IUtilityFile
    {
        public bool KeyExist(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        public void SaveString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }

        public string LoadString(string key)
        {
            return PlayerPrefs.GetString(key);
        }

        public void SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        public int LoadInt(string key)
        {
            return PlayerPrefs.GetInt(key);
        }

        public void SaveFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
        }

        public float LoadFloat(string key)
        {
            return PlayerPrefs.GetFloat(key);
        }
    }


    public class UtilityEcryptedPlayerPrefs : IUtilityFile
    {
        public bool KeyExist(string key)
        {
            var decryptedKey = Decrypt(key);
            return PlayerPrefs.HasKey(decryptedKey);
        }

        public void SaveString(string key, string value)
        {
            string encryptedKey = Encrypt(key);
            string encryptedValue = Encrypt(value);
            PlayerPrefs.SetString(encryptedKey, encryptedValue);
        }

        public string LoadString(string key)
        {
            string encryptedKey = Encrypt(key);
            var result = Decrypt(PlayerPrefs.GetString(encryptedKey));
            return result;
        }

        public void SaveInt(string key, int value)
        {
            string encryptedKey = Encrypt(key);
            PlayerPrefs.SetInt(encryptedKey, value + _intOffset);
        }

        public int LoadInt(string key)
        {
            string encryptedKey = Encrypt(key);
            return PlayerPrefs.GetInt(encryptedKey) - _intOffset;
        }

        public void SaveFloat(string key, float value)
        {
            string encryptedKey = Encrypt(key);
            PlayerPrefs.SetFloat(encryptedKey, value + _floatOffset);
        }

        public float LoadFloat(string key)
        {
            string encryptedKey = Encrypt(key);
            return PlayerPrefs.GetFloat(encryptedKey) - _floatOffset;
        }


        private int _intOffset = 464;
        private float _floatOffset = 595;
        static readonly string PasswordHash = "passpasspasswasss";
        static readonly string SaltKey = "saltsaltsalt";
        private const string ViKey = "@1B2c3D4e5F6g7H8";


        private static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(ViKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }

                memoryStream.Close();
            }

            return Convert.ToBase64String(cipherTextBytes);
        }


        private static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(ViKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
    }
}