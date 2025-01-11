using System.Security.Cryptography;
using System.Text;

namespace WebTravel.Utilities
{
    public class Function
    {
        public static int _UserID = 0;
        public static string _Username = string.Empty;
        public static string _Email = string.Empty;
        public static string _Message = string.Empty;
        public static string _MessageEmail = string.Empty;
        
        public static string TitleSlugGenerationAlias(string title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(title);
        }
   

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }

        public static string MD5Password(string? text)
        {
            string str = MD5Hash(text);
            for (int i = 0;i<=5;i++) 
                str = MD5Hash(str + "_" + str); 
            return str;
        }
        public static bool IsLogin()
        {
            if (string.IsNullOrEmpty(Function._Username) || string.IsNullOrEmpty(Function._Email) || (Function._UserID <= 0))
                return false;
            return true;
        }

    }
}
