using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace decrypt
{
    class Decryptor
    {
        AesCryptoServiceProvider crypt = new AesCryptoServiceProvider();

        public Decryptor()
        {
            crypt.BlockSize = 128;
            crypt.KeySize = 256;
            crypt.GenerateIV();
            crypt.GenerateKey();
            crypt.Mode = CipherMode.CBC;
            crypt.Padding = PaddingMode.PKCS7;

            MessageBox.Show(crypt.Key.ToString());

        }

        public String encrypt(string szyfruj)
        {
            ICryptoTransform transform = crypt.CreateEncryptor();

            byte[] encrypted_bytes = transform.TransformFinalBlock(ASCIIEncoding.ASCII.GetBytes(szyfruj), 0, szyfruj.Length);



            string str = Convert.ToBase64String(encrypted_bytes);

            return str;
        }

        public string decrypt(string odszyfruj)
        {
            ICryptoTransform transform = crypt.CreateDecryptor();

            byte[] encode_byt = Convert.FromBase64String(odszyfruj);

            byte[] decrypt_byt = transform.TransformFinalBlock(encode_byt, 0, encode_byt.Length);

            string str = ASCIIEncoding.ASCII.GetString(decrypt_byt);

            return str;
        }




    }



}
