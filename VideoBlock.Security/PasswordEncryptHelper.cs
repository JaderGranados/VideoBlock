using System;
using System.Text;

namespace VideoBlock.Security
{
    public class PasswordEncryptHelper
    {
        public static string Encrypt(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text.Trim());
            string result = Convert.ToBase64String(bytes);
            return result;
        }

        public static string Decrypt(string text)
        {
            byte[] bytes = Convert.FromBase64String(text);
            string result = Encoding.Unicode.GetString(bytes);
            return result;
        }
    }
}
