using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApiCloud.Common
{
    public class Utility
    {

        public static string EncryptData(string text)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[text.Length];
            encode = Encoding.UTF8.GetBytes(text);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
        public static string DecryptData(string text)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(text);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }
    }
}