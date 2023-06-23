using System.Security.Cryptography;
using System.Text;

namespace WebApplication3.Utils
{
    public class Utilitarios
    {
        public static string GetMd5Hash(string input)
        {
            // Convert the input string to a byte array and compute the hash.
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
    }
}
