using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace WIN_Lam_Client
{
    class AESHMAC_CRYPTO
    {
        private readonly RandomNumberGenerator Random = RandomNumberGenerator.Create();

        //Preconfigured Encryption Parameters
        public readonly int BlockBitSize = 128;
        public readonly int KeyBitSize = 256;

        //Preconfigured Password Key Derivation Parameters
        public readonly int SaltBitSize = 64;
        public readonly int Iterations = 10000;
        public readonly int MinPasswordLength = 3;

        private bool m_iserror;
        private string m_errormessage;

        public AESHMAC_CRYPTO()
        {
            m_iserror = false;
            m_errormessage = "";
        }

        public bool IsError
        {
            get { return m_iserror; }
            set { m_iserror = value; }
        }
        public string ErrorMessage
        {
            set { m_errormessage = value; }
            get { return m_errormessage; }
        }

        private void SetError(string msg)
        {
            if (m_errormessage.Length > 0)
                ErrorMessage += ";";

            m_iserror = true;
            m_errormessage += msg;
        }

        public byte[] NewKey()
        {
            var key = new byte[KeyBitSize / 8];

            try
            {
                Random.GetBytes(key);
            }
            catch(Exception ex)
            { SetError(ex.Message); }
            return key;
        }

        /// <summary>
        /// Simple Encryption (AES) then Authentication (HMAC) for a UTF8 Message.
        /// </summary>
        /// <param name="secretMessage">The secret message.</param>
        /// <param name="cryptKey">The crypt key.</param>
        /// <param name="authKey">The auth key.</param>
        /// <param name="nonSecretPayload">(Optional) Non-Secret Payload.</param>
        /// <returns>
        /// Encrypted Message
        /// </returns>
        /// <exception cref="System.ArgumentException">Secret Message Required!;secretMessage</exception>
        /// <remarks>
        /// Adds overhead of (Optional-Payload + BlockSize(16) + Message-Padded-To-Blocksize +  HMac-Tag(32)) * 1.33 Base64
        /// </remarks>
        public string SimpleEncrypt(string secretMessage, byte[] cryptKey, byte[] authKey,
                           byte[] nonSecretPayload = null)
        {
            byte[] cipherText = null;
            try
            {
                if (string.IsNullOrEmpty(secretMessage))
                    throw new ArgumentException("Secret Message Required!", "secretMessage");

                var plainText = Encoding.UTF8.GetBytes(secretMessage);
                cipherText = SimpleEncrypt(plainText, cryptKey, authKey, nonSecretPayload);
            }
            catch(Exception ex)
            { SetError(ex.Message); }
            return Convert.ToBase64String(cipherText);
        }

        /// <summary>
        /// Simple Authentication (HMAC) then Decryption (AES) for a secrets UTF8 Message.
        /// </summary>
        /// <param name="encryptedMessage">The encrypted message.</param>
        /// <param name="cryptKey">The crypt key.</param>
        /// <param name="authKey">The auth key.</param>
        /// <param name="nonSecretPayloadLength">Length of the non secret payload.</param>
        /// <returns>
        /// Decrypted Message
        /// </returns>
        /// <exception cref="System.ArgumentException">Encrypted Message Required!;encryptedMessage</exception>
        public string SimpleDecrypt(string encryptedMessage, byte[] cryptKey, byte[] authKey,
                           int nonSecretPayloadLength = 0)
        {
            Byte[] plainText = null;

            try
            {
                if (string.IsNullOrWhiteSpace(encryptedMessage))
                    throw new ArgumentException("Encrypted Message Required!", "encryptedMessage");

                var cipherText = Convert.FromBase64String(encryptedMessage);
                plainText = SimpleDecrypt(cipherText, cryptKey, authKey, nonSecretPayloadLength);
            }
            catch(Exception ex)
            { SetError(ex.Message); }

            return plainText == null ? null : Encoding.UTF8.GetString(plainText);
        }

        /// <summary>
        /// Simple Encryption (AES) then Authentication (HMAC) of a UTF8 message
        /// using Keys derived from a Password (PBKDF2).
        /// </summary>
        /// <param name="secretMessage">The secret message.</param>
        /// <param name="password">The password.</param>
        /// <param name="nonSecretPayload">The non secret payload.</param>
        /// <returns>
        /// Encrypted Message
        /// </returns>
        /// <exception cref="System.ArgumentException">password</exception>
        /// <remarks>
        /// Significantly less secure than using random binary keys.
        /// Adds additional non secret payload for key generation parameters.
        /// </remarks>
        public string SimpleEncryptWithPassword(string secretMessage, string password,
                                 byte[] nonSecretPayload = null)
        {
            Byte[] cipherText = null;
            try
            {
                if (string.IsNullOrEmpty(secretMessage))
                    throw new ArgumentException("Secret Message Required!", "secretMessage");

                var plainText = Encoding.UTF8.GetBytes(secretMessage);
                cipherText = SimpleEncryptWithPassword(plainText, password, nonSecretPayload);
            }
            catch(Exception ex)
            { SetError(ex.Message); }
            return Convert.ToBase64String(cipherText);
        }

        /// <summary>
        /// Simple Authentication (HMAC) and then Descryption (AES) of a UTF8 Message
        /// using keys derived from a password (PBKDF2). 
        /// </summary>
        /// <param name="encryptedMessage">The encrypted message.</param>
        /// <param name="password">The password.</param>
        /// <param name="nonSecretPayloadLength">Length of the non secret payload.</param>
        /// <returns>
        /// Decrypted Message
        /// </returns>
        /// <exception cref="System.ArgumentException">Encrypted Message Required!;encryptedMessage</exception>
        /// <remarks>
        /// Significantly less secure than using random binary keys.
        /// </remarks>
        public string SimpleDecryptWithPassword(string encryptedMessage, string password,
                                 int nonSecretPayloadLength = 0)
        {
            Byte[] plainText = null;
            try
            {
                if (string.IsNullOrWhiteSpace(encryptedMessage))
                    throw new ArgumentException("Encrypted Message Required!", "encryptedMessage");

                var cipherText = Convert.FromBase64String(encryptedMessage);
                plainText = SimpleDecryptWithPassword(cipherText, password, nonSecretPayloadLength);
            }
            catch(Exception ex)
            { SetError(ex.Message); }
            return plainText == null ? null : Encoding.UTF8.GetString(plainText);
        }

        public byte[] SimpleEncrypt(byte[] secretMessage, byte[] cryptKey, byte[] authKey, byte[] nonSecretPayload = null)
        {
            MemoryStream encryptedStream = new MemoryStream();
            try
            {

                //User Error Checks
                if (cryptKey == null || cryptKey.Length != KeyBitSize / 8)
                    throw new ArgumentException(String.Format("Key needs to be {0} bit!", KeyBitSize), "cryptKey");

                if (authKey == null || authKey.Length != KeyBitSize / 8)
                    throw new ArgumentException(String.Format("Key needs to be {0} bit!", KeyBitSize), "authKey");

                if (secretMessage == null || secretMessage.Length < 1)
                    throw new ArgumentException("Secret Message Required!", "secretMessage");

                //non-secret payload optional
                nonSecretPayload = nonSecretPayload ?? new byte[] { };

                byte[] cipherText;
                byte[] iv;

                using (var aes = new AesManaged
                {
                    KeySize = KeyBitSize,
                    BlockSize = BlockBitSize,
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                })
                {
                    //Use random IV
                    aes.GenerateIV();
                    iv = aes.IV;

                    using (var encrypter = aes.CreateEncryptor(cryptKey, iv))
                    using (var cipherStream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(cipherStream, encrypter, CryptoStreamMode.Write))
                        using (var binaryWriter = new BinaryWriter(cryptoStream))
                        {
                            //Encrypt Data
                            binaryWriter.Write(secretMessage);
                        }
                        cipherText = cipherStream.ToArray();
                    }
                }

                //Assemble encrypted message and add authentication
                using (var hmac = new HMACSHA256(authKey))
                using (encryptedStream = new MemoryStream())
                {
                    using (var binaryWriter = new BinaryWriter(encryptedStream))
                    {
                        //Prepend non-secret payload if any
                        binaryWriter.Write(nonSecretPayload);
                        //Prepend IV
                        binaryWriter.Write(iv);
                        //Write Ciphertext
                        binaryWriter.Write(cipherText);
                        binaryWriter.Flush();

                        //Authenticate all data
                        var tag = hmac.ComputeHash(encryptedStream.ToArray());
                        //Postpend tag
                        binaryWriter.Write(tag);
                    }
                }
            }
            catch(Exception ex)
            { SetError(ex.Message); }
            return encryptedStream.ToArray();
        }

        public byte[] SimpleDecrypt(byte[] encryptedMessage, byte[] cryptKey, byte[] authKey, int nonSecretPayloadLength = 0)
        {
            Byte[] sRtnVal = null;
            try
            {
                //Basic Usage Error Checks
                if (cryptKey == null || cryptKey.Length != KeyBitSize / 8)
                    throw new ArgumentException(String.Format("CryptKey needs to be {0} bit!", KeyBitSize), "cryptKey");

                if (authKey == null || authKey.Length != KeyBitSize / 8)
                    throw new ArgumentException(String.Format("AuthKey needs to be {0} bit!", KeyBitSize), "authKey");

                if (encryptedMessage == null || encryptedMessage.Length == 0)
                    throw new ArgumentException("Encrypted Message Required!", "encryptedMessage");

                using (var hmac = new HMACSHA256(authKey))
                {
                    var sentTag = new byte[hmac.HashSize / 8];
                    //Calculate Tag
                    var calcTag = hmac.ComputeHash(encryptedMessage, 0, encryptedMessage.Length - sentTag.Length);
                    var ivLength = (BlockBitSize / 8);

                    //if message length is to small just return null
                    if (encryptedMessage.Length < sentTag.Length + nonSecretPayloadLength + ivLength)
                        return null;

                    //Grab Sent Tag
                    Array.Copy(encryptedMessage, encryptedMessage.Length - sentTag.Length, sentTag, 0, sentTag.Length);

                    //Compare Tag with constant time comparison
                    var compare = 0;
                    for (var i = 0; i < sentTag.Length; i++)
                        compare |= sentTag[i] ^ calcTag[i];

                    //if message doesn't authenticate return null
                    if (compare != 0)
                        return null;

                    using (var aes = new AesManaged
                    {
                        KeySize = KeyBitSize,
                        BlockSize = BlockBitSize,
                        Mode = CipherMode.CBC,
                        Padding = PaddingMode.PKCS7
                    })
                    {
                        //Grab IV from message
                        var iv = new byte[ivLength];
                        Array.Copy(encryptedMessage, nonSecretPayloadLength, iv, 0, iv.Length);

                        using (var decrypter = aes.CreateDecryptor(cryptKey, iv))
                        using (var plainTextStream = new MemoryStream())
                        {
                            using (var decrypterStream = new CryptoStream(plainTextStream, decrypter, CryptoStreamMode.Write))
                            using (var binaryWriter = new BinaryWriter(decrypterStream))
                            {
                                //Decrypt Cipher Text from Message
                                binaryWriter.Write(
                                  encryptedMessage,
                                  nonSecretPayloadLength + iv.Length,
                                  encryptedMessage.Length - nonSecretPayloadLength - iv.Length - sentTag.Length
                                );
                            }
                            //Return Plain Text
                            sRtnVal = plainTextStream.ToArray();
                        }
                    }
                }
            }
            catch(Exception ex)
            { SetError(ex.Message); }

            return sRtnVal;
        }

        public byte[] SimpleEncryptWithPassword(byte[] secretMessage, string password, byte[] nonSecretPayload = null)
        {
            Byte[] sRtnVal = null;
            try
            {
                nonSecretPayload = nonSecretPayload ?? new byte[] { };

                //User Error Checks
                if (string.IsNullOrWhiteSpace(password) || password.Length < MinPasswordLength)
                    throw new ArgumentException(String.Format("Must have a password of at least {0} characters!", MinPasswordLength), "password");

                if (secretMessage == null || secretMessage.Length == 0)
                    throw new ArgumentException("Secret Message Required!", "secretMessage");

                var payload = new byte[((SaltBitSize / 8) * 2) + nonSecretPayload.Length];

                Array.Copy(nonSecretPayload, payload, nonSecretPayload.Length);
                int payloadIndex = nonSecretPayload.Length;

                byte[] cryptKey;
                byte[] authKey;
                //Use Random Salt to prevent pre-generated weak password attacks.
                using (var generator = new Rfc2898DeriveBytes(password, SaltBitSize / 8, Iterations))
                {
                    var salt = generator.Salt;

                    //Generate Keys
                    cryptKey = generator.GetBytes(KeyBitSize / 8);

                    //Create Non Secret Payload
                    Array.Copy(salt, 0, payload, payloadIndex, salt.Length);
                    payloadIndex += salt.Length;
                }

                //Deriving separate key, might be less efficient than using HKDF, 
                //but now compatible with RNEncryptor which had a very similar wireformat and requires less code than HKDF.
                using (var generator = new Rfc2898DeriveBytes(password, SaltBitSize / 8, Iterations))
                {
                    var salt = generator.Salt;

                    //Generate Keys
                    authKey = generator.GetBytes(KeyBitSize / 8);

                    //Create Rest of Non Secret Payload
                    Array.Copy(salt, 0, payload, payloadIndex, salt.Length);
                }
                sRtnVal = SimpleEncrypt(secretMessage, cryptKey, authKey, payload);
            }
            catch(Exception ex)
            { SetError(ex.Message); }
            return sRtnVal;
        }

        public byte[] SimpleDecryptWithPassword(byte[] encryptedMessage, string password, int nonSecretPayloadLength = 0)
        {
            Byte[] sRtnVal = null;
            try
            {
                //User Error Checks
                if (string.IsNullOrWhiteSpace(password) || password.Length < MinPasswordLength)
                    throw new ArgumentException(String.Format("Must have a password of at least {0} characters!", MinPasswordLength), "password");

                if (encryptedMessage == null || encryptedMessage.Length == 0)
                    throw new ArgumentException("Encrypted Message Required!", "encryptedMessage");

                var cryptSalt = new byte[SaltBitSize / 8];
                var authSalt = new byte[SaltBitSize / 8];

                //Grab Salt from Non-Secret Payload
                Array.Copy(encryptedMessage, nonSecretPayloadLength, cryptSalt, 0, cryptSalt.Length);
                Array.Copy(encryptedMessage, nonSecretPayloadLength + cryptSalt.Length, authSalt, 0, authSalt.Length);

                byte[] cryptKey;
                byte[] authKey;

                //Generate crypt key
                using (var generator = new Rfc2898DeriveBytes(password, cryptSalt, Iterations))
                {
                    cryptKey = generator.GetBytes(KeyBitSize / 8);
                }
                //Generate auth key
                using (var generator = new Rfc2898DeriveBytes(password, authSalt, Iterations))
                {
                    authKey = generator.GetBytes(KeyBitSize / 8);
                }

                sRtnVal = SimpleDecrypt(encryptedMessage, cryptKey, authKey, cryptSalt.Length + authSalt.Length + nonSecretPayloadLength);
            }
            catch(Exception ex)
            { SetError(ex.Message); }
            return sRtnVal;
        }
    }
}
