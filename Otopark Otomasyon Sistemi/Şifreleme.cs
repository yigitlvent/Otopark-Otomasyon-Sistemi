using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Otopark_Otomasyon_Sistemi
{
    public class Şifreleme
    {
        public static string Hashing(string Metin)
        {
            SHA256CryptoServiceProvider Sha256 = new SHA256CryptoServiceProvider();
            byte[] byte1 = Encoding.UTF8.GetBytes(Metin);
            byte1 = Sha256.ComputeHash(byte1);

            StringBuilder Stringbuilder = new StringBuilder();

            foreach (byte byte2 in byte1)
            {
                Stringbuilder.Append(byte2.ToString("x2").ToLower());
            }
            return Stringbuilder.ToString();
        }
    }
}
