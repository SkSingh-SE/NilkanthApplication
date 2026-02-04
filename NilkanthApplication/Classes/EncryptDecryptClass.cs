using System.Configuration;
using System;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// Summary description for EncryptDecryptClass
/// </summary>
public class EncryptDecryptClass
{
    private string m_strPassPhrase = "MyPriv@Password!$$";      //--- any text string is good here
    // private string m_strHashAlgorithm = "MD5";                  //--- we are doing MD5 encryption - can be "SHA1"
    private int m_strPasswordIterations = 2;                    //--- can be any number
    private string m_strInitVector = "@1B2c3D4e5F6g7H8";        //--- must be 16 bytes
    private int m_intKeySize = 256;                             //--- can be 192 or 128

    public String EncryptPasswordMD5(String plainText, String p_strSaltValue)
    {
        String strReturn = string.Empty;

        //' Convert strings into byte arrays.
        //' Let us assume that strings only contain ASCII codes.
        //' If strings include Unicode characters, use Unicode, UTF7, or UTF8 
        //' encoding.
        try
        {
            Byte[] initVectorBytes;
            initVectorBytes = System.Text.Encoding.ASCII.GetBytes(m_strInitVector);

            Byte[] saltValueBytes;
            saltValueBytes = System.Text.Encoding.ASCII.GetBytes(p_strSaltValue);

            Byte[] plainTextBytes;
            plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);

            //' First, we must create a password, from which the key will be derived.
            //' This password will be generated from the specified passphrase and 
            //' salt value. The password will be created using the specified hash 
            //' algorithm. Password creation can be done in several iterations.

            Rfc2898DeriveBytes password;
            password = new Rfc2898DeriveBytes(m_strPassPhrase, saltValueBytes, m_strPasswordIterations);

            Byte[] keyBytes;
            int intKeySize = 0;

            intKeySize = Convert.ToInt32(m_intKeySize / 8);

            keyBytes = password.GetBytes(intKeySize);

            System.Security.Cryptography.RijndaelManaged symmetricKey;
            symmetricKey = new System.Security.Cryptography.RijndaelManaged();
            //    ' It is reasonable to set encryption mode to Cipher Block Chaining
            //    ' (CBC). Use default options for other symmetric key parameters.

            symmetricKey.Mode = System.Security.Cryptography.CipherMode.CBC;
            symmetricKey.Padding = PaddingMode.Zeros;

            //    ' Generate encryptor from the existing key bytes and initialization 
            //    ' vector. Key size will be defined based on the number of the key 
            //    ' bytes.

            System.Security.Cryptography.ICryptoTransform encryptor;
            encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

            //    ' Define memory stream which will be used to hold encrypted data.
            System.IO.MemoryStream memoryStream;
            memoryStream = new System.IO.MemoryStream();

            //    ' Define cryptographic stream (always use Write mode for encryption).

            System.Security.Cryptography.CryptoStream cryptoStream;

            cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, encryptor, System.Security.Cryptography.CryptoStreamMode.Write);
            //    ' Start encrypting.
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            //    ' Finish encrypting.
            cryptoStream.FlushFinalBlock();

            //    ' Convert our encrypted data from a memory stream into a byte array.
            Byte[] cipherTextBytes;
            cipherTextBytes = memoryStream.ToArray();


            //    ' Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            //    ' Convert encrypted data into a base64-encoded string.
            String cipherText;
            cipherText = Convert.ToBase64String(cipherTextBytes);


            //    ' Return encrypted string.
            strReturn = cipherText;
        }
        catch
        {
            strReturn = "";
        }

        return strReturn;
    }

    public string DecryptPasswordMD5(String cipherText, String p_strSaltValue)
    {
        String strReturn = string.Empty;
        //' Convert strings defining encryption key characteristics into byte
        //' arrays. Let us assume that strings only contain ASCII codes.
        //' If strings include Unicode characters, use Unicode, UTF7, or UTF8
        //' encoding.

        try
        {
            Byte[] initVectorBytes;
            initVectorBytes = System.Text.Encoding.ASCII.GetBytes(m_strInitVector);

            Byte[] saltValueBytes;
            saltValueBytes = System.Text.Encoding.ASCII.GetBytes(p_strSaltValue);

            //' Convert our ciphertext into a byte array.

            Byte[] cipherTextBytes;
            cipherTextBytes = Convert.FromBase64String(cipherText);

            //' First, we must create a password, from which the key will be 
            //' derived. This password will be generated from the specified 
            //' passphrase and salt value. The password will be created using
            //' the specified hash algorithm. Password creation can be done in
            //' several iterations.

            Rfc2898DeriveBytes password;
            password = new Rfc2898DeriveBytes(m_strPassPhrase, saltValueBytes, m_strPasswordIterations);

            //' Use the password to generate pseudo-random bytes for the encryption
            //' key. Specify the size of the key in bytes (instead of bits).

            Byte[] keyBytes;
            int intKeySize;

            intKeySize = Convert.ToInt32(m_intKeySize / 8);

            keyBytes = password.GetBytes(intKeySize);

            //' Create uninitialized Rijndael encryption object.
            System.Security.Cryptography.RijndaelManaged symmetricKey;
            symmetricKey = new System.Security.Cryptography.RijndaelManaged();

            //' It is reasonable to set encryption mode to Cipher Block Chaining
            //' (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = System.Security.Cryptography.CipherMode.CBC;

            //'symmetricKey.Padding = PaddingMode.Zeros

            //' Generate decryptor from the existing key bytes and initialization 
            //' vector. Key size will be defined based on the number of the key 
            //' bytes.
            System.Security.Cryptography.ICryptoTransform decryptor;
            decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

            //' Define memory stream which will be used to hold encrypted data.
            System.IO.MemoryStream memoryStream;
            memoryStream = new System.IO.MemoryStream(cipherTextBytes);

            //' Define memory stream which will be used to hold encrypted data.
            System.Security.Cryptography.CryptoStream cryptoStream;
            cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, decryptor, System.Security.Cryptography.CryptoStreamMode.Read);

            //' Since at this point we don't know what the size of decrypted data
            //' will be, allocate the buffer long enough to hold ciphertext;
            //' plaintext is never longer than ciphertext.
            Byte[] plainTextBytes = new Byte[cipherTextBytes.Length];
            //plainTextBytes[cipherTextBytes.Length];

            //' Start decrypting.
            int decryptedByteCount;
            decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            //' Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            //' Convert decrypted data into a string. 
            //' Let us assume that the original plaintext string was UTF8-encoded.
            String plainText;
            plainText = System.Text.Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

            //' Return decrypted string.
            strReturn = plainText;

        }
        catch
        {
            strReturn = "";
        }
        return strReturn;
    }


    /// <summary>
    /// Encrypt a string using dual encryption method. Return a encrypted cipher Text
    /// </summary>
    /// <param name="toEncrypt">string to be encrypted</param>
    /// <param name="useHashing">use hashing? send to for extra secirity</param>
    /// <returns></returns>
    public string Encrypt(string toEncrypt, bool useHashing)
    {
        byte[] keyArray;
        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

        System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
        // Get the key from config file

        //string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
        string key = "Tripearltech";
        //System.Windows.Forms.MessageBox.Show(key);
        if (useHashing)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
        }
        else
            keyArray = UTF8Encoding.UTF8.GetBytes(key);

        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = tdes.CreateEncryptor();
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        tdes.Clear();
        return Convert.ToBase64String(resultArray, 0, resultArray.Length).Replace("+", "PCK").Replace("/", "MYS");
    }
    /// <summary>
    /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
    /// </summary>
    /// <param name="cipherString">encrypted string</param>
    /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
    /// <returns></returns>
    public string Decrypt(string cipherString, bool useHashing)
    {
        byte[] keyArray;
        byte[] toEncryptArray = Convert.FromBase64String(cipherString.Replace("PCK", "+").Replace("MYS", "/"));

        System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
        //Get your key from config file to open the lock!
        //string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
        string key = "Tripearltech";
        if (useHashing)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
        }
        else
            keyArray = UTF8Encoding.UTF8.GetBytes(key);

        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        ICryptoTransform cTransform = tdes.CreateDecryptor();
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

        tdes.Clear();
        return UTF8Encoding.UTF8.GetString(resultArray);
    }
}