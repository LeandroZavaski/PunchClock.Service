using System;
using System.Security.Cryptography;
using System.Text;

namespace DelMazo.PointRecord.Service.Application.Helpers
{
    public class PointRecordHasshPass
    {
        public static string Encrypt(string pass)
        {
            if (pass == null) throw new ArgumentNullException("pass");

            //encrypt data
            var data = Encoding.Unicode.GetBytes(pass);
            byte[] encrypted = ProtectedData.Protect(data, null, 0);

            //return as base64 string
            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string pass)
        {
            if (pass == null) throw new ArgumentNullException("cipher");

            //parse base64 string
            byte[] data = Convert.FromBase64String(pass);

            //decrypt data
            byte[] decrypted = ProtectedData.Unprotect(data, null, 0);
            return Encoding.Unicode.GetString(decrypted);
        }
    }
}
