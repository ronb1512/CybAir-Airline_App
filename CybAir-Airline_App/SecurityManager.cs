using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CybAir_Airline_App
{
    public class SecurityManager
    {

        public RSA rsa { get; set; }
        public Aes aes { get; set; }
        public StreamWriter writer { get; set; }
        public StreamReader reader { get; set; }
        /// <summary>
        /// creates the aes details and encrypts the message with it
        /// if the message is the first one sent, the rsa key encrypts the aes key and sends the message with it and the IV value
        /// otherwise it sends the encrypted message and the IV value
        /// </summary>
        /// <param name="msg"></param>
        public void writeEncrypted(string msg)
        {
            try
            {

                if (writer == null && ConnectionManager.writer != null)
                {
                    writer = ConnectionManager.writer;
                    reader = ConnectionManager.reader;
                }
                byte[] msg_bytes = Encoding.UTF8.GetBytes(msg);

                bool first = this.aes == null;
                (byte[] aes_key, byte[] IV) = this.create_aes_details();

                byte[] encrypted_msg_bytes = this.aes_encryption(msg_bytes, aes_key, IV);

                string IV_string = Convert.ToBase64String(IV);
                string encrypted_msg_string = Convert.ToBase64String(encrypted_msg_bytes);

                if (first)
                {
                    byte[] encrypted_key_bytes = this.encrypt_aes_key(aes_key);
                    string encrypted_key_string = Convert.ToBase64String(encrypted_key_bytes);
                    writer.WriteLine(IV_string + ":" + encrypted_key_string + ":" + encrypted_msg_string);
                }
                else
                {
                    writer.WriteLine(IV_string + ":" + encrypted_msg_string);
                }
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// reads the message over the tcp connection
        /// if the message has 3 parts it means that the server recieved the first message
        /// and it initializes the symmetric encryption with the client
        /// takes the IV and the aes key and decryptes the message
        /// returns the message
        /// </summary>
        /// <returns></returns>
        public string readEncrypted()
        {
            try
            {
                if (writer == null && ConnectionManager.writer != null)
                {
                    writer = ConnectionManager.writer;
                    reader = ConnectionManager.reader;
                }
                string msg = reader.ReadLine();

                if (msg == null) return null;
                if (msg.Split(':').Length < 2 || msg.Split(':').Length > 3) return null;
                string IV_string = msg.Split(':')[0];
                string encrypted_msg_string;
                string encrypted_key_string;
                byte[] decrypted_msg_bytes;

                if (msg.Split(':').Length == 3)
                {
                    encrypted_key_string = msg.Split(':')[1];
                    encrypted_msg_string = msg.Split(':')[2];
                    byte[] decrypted_aes_key = Server.rsa.Decrypt(Convert.FromBase64String(encrypted_key_string), RSAEncryptionPadding.OaepSHA1);
                    decrypted_msg_bytes = this.aes_decryption(Convert.FromBase64String(encrypted_msg_string), decrypted_aes_key, Convert.FromBase64String(IV_string));
                    this.aes = Aes.Create();
                    this.aes.Mode = CipherMode.CBC;
                    this.aes.Padding = PaddingMode.PKCS7;
                    this.aes.Key = decrypted_aes_key;
                    this.aes.IV = Convert.FromBase64String(IV_string);
                }
                else
                {
                    encrypted_msg_string = msg.Split(':')[1];
                    decrypted_msg_bytes = this.aes_decryption(Convert.FromBase64String(encrypted_msg_string), this.aes.Key, Convert.FromBase64String(IV_string));
                    this.aes.IV = Convert.FromBase64String(IV_string);
                    this.aes.Mode = CipherMode.CBC;
                    this.aes.Padding = PaddingMode.PKCS7;
                }
                return Encoding.UTF8.GetString(decrypted_msg_bytes);
            }
            catch
            {

                return null;
                throw;
            }

        }
        /// <summary>
        /// returns the server rsa as a xml string
        /// </summary>
        /// <returns></returns>
        public string get_public_key()
        {
            return Server.rsa.ToXmlString(false);
        }
        /// <summary>
        /// creates an rsa instance from a public key
        /// </summary>
        /// <param name="publicKeyXml"></param>
        public void rsa_from_public_key(string publicKeyXml)
        {
            rsa = RSA.Create();
            rsa.FromXmlString(publicKeyXml);
        }
        /// <summary>
        /// generates new aes instance and key if dont exist
        /// generates new IV value
        /// returns a tuple of the key and the IV value
        /// </summary>
        /// <returns></returns>
        public (byte[] Key, byte[] IV) create_aes_details()
        {

            if (aes == null)
            {
                aes = Aes.Create();
                aes.GenerateKey();
            }
            aes.GenerateIV();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            return (aes.Key, aes.IV);
        }
        /// <summary>
        /// uses the public rsa key to encrypt the aes key
        /// </summary>
        /// <param name="aesKey"></param>
        /// <returns></returns>
        public byte[] encrypt_aes_key(byte[] aesKey)
        {
            return rsa.Encrypt(aesKey, RSAEncryptionPadding.OaepSHA1);
        }
        /// <summary>
        /// encrypts the given message using the given aes key and IV value
        /// </summary>
        /// <param name="msg_bytes"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public byte[] aes_encryption(byte[] msg_bytes, byte[] key, byte[] iv)
        {
            using (Aes aes1 = Aes.Create())
            {
                aes1.Key = key;
                aes1.IV = iv;
                aes1.Mode = CipherMode.CBC;
                aes1.Padding = PaddingMode.PKCS7;
                ICryptoTransform encryptor = aes1.CreateEncryptor();
                return encryptor.TransformFinalBlock(msg_bytes, 0, msg_bytes.Length);
            }
        }
        /// <summary>
        /// decrypts the given message using the given aes key and IV value
        /// </summary>
        /// <param name="msg_bytes"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public byte[] aes_decryption(byte[] msg_bytes, byte[] key, byte[] iv)
        {
            using (Aes aes1 = Aes.Create())
            {
                aes1.Key = key;
                aes1.IV = iv;
                aes1.Mode = CipherMode.CBC;
                aes1.Padding = PaddingMode.PKCS7;
                ICryptoTransform decryptor = aes1.CreateDecryptor();
                return decryptor.TransformFinalBlock(msg_bytes, 0, msg_bytes.Length);
            }
        }
        /// <summary>
        /// does the hash operation on the password and salt and returns it
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static byte[] hash_password(string password, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] combined = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();
                return sha256.ComputeHash(combined);
            }
        }
        /// <summary>
        /// generates a 32 byte array of random characters and returns it
        /// </summary>
        /// <returns></returns>
        public static byte[] generate_salt()
        {
            int size = 32;
            var salt = new byte[size];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}
