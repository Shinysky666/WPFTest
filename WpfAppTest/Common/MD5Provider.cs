using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTest.Common
{
    public class MD5Provider
    {
        public static string GetMD5String(string str)
        {
            string pwd = "";
            MD5 md5 = MD5.Create();
            byte[] pws = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            foreach (var item in pws)
            {
                pwd += item.ToString("X2");
            }
            return pwd;
        }
    }
}
