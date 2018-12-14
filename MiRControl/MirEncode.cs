using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MiRControl
{
    class MirEncode
    {
        public static string GerSHA256HashFromString(string strData)
        {
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(strData);
            try
            {
                SHA256 sha256 = new SHA256CryptoServiceProvider();
                byte[] retVal = sha256.ComputeHash(bytValue);
                StringBuilder sb = new StringBuilder();
                for(int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch(Exception ex)
            {
                throw new Exception("GetSHA256HashFormString() fail, error:"+ex.Message);
            }
        }
        public static string ToBase64String(string value)
        {
            if( value==null || value=="")
            {
                return "";
            }
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }
        public static string Encode(string name,string passwd)
        {
            string convert = name + ":" + GerSHA256HashFromString(passwd);
            return ToBase64String(convert);
        }
    }
}
