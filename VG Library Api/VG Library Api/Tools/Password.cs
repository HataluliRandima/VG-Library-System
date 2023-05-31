using System.Security.Cryptography;
using System.Text;

namespace VG_Library_Api.Tools
{
    public class Password
    {
        //fotr hashing the password 
        public static string hashPassword(string password)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(password);


            var hashedpassword = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashedpassword);
        }
    }
}
