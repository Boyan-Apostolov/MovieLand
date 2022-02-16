using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace MovieLand.Services.UserINF
{
    class HashPassword
    {
        private string username;
        public string Username
        {
            get { return username; }

            set
            {
                this.Username = this.username;
                if (value != "'" || value != "/" || value != "*" || value == "!")
                {
                    username = value;
                }
                else
                {
                    string ToTyepe = "//INVALID USERNAME!//";
                    Console.WriteLine(String.Format("{0,"
                        + ((Console.WindowWidth / 2)
                        + (ToTyepe.Length / 2))
                        + "}", ToTyepe));

                    RequestUsername();
                }
            }
        }

        private string hPassword;
        public string HPassword
        {
            get { return hPassword; }

            set
            {
                this.HPassword = this.hPassword;
                if (value != "'" || value != "/" || value != "*" || value == "!")
                {
                    hPassword = value;
                }
                else
                {
                    string ToType = "//INVALID PASSWORD!//";
                    Console.WriteLine(String.Format("{0,"
                        + ((Console.WindowWidth / 2)
                        + (ToType.Length / 2))
                        + "}", ToType));

                    ConvertPassword();
                }
            }
        }

        public static string RequestUsername()
        {
            string Username;
            Console.WriteLine("Username:");
            Username = Console.ReadLine();
            return Username;
        }

        public static string ConvertPassword()
        {
            string Password;
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            Console.Write("Password:");
            Password = Console.ReadLine();

            byte[] password_bytes = Encoding.ASCII.GetBytes(Password);
            byte[] encrypted_bytes = sha1.ComputeHash(password_bytes);

            return Convert.ToBase64String(encrypted_bytes);
            //ADD TO DB
        }
    }
}

