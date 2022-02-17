using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace MovieLand.Services.UserINF
{
    class UserData
    {
        private static MySqlConnection con;
        static void Main(string[] args)
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder()
            {
                Server = "127.0.0.1",
                Database = "movieland",
                UserID = "movieland",
                Password = "movieland",
                Port = 3306
            };
            con = new MySqlConnection(sb.GetConnectionString(true));
            con.Open();

            if (con.State != System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Not connected to database!");
            }
            else
            {
                Console.WriteLine($"Connection: {con.State}");
            }

            Console.WriteLine("Register or login (R/L)?");
            string input = Console.ReadLine();
            switch (input)
            {
                case "R":
                    {
                        Console.WriteLine("Enter new username: ");
                        string username = Console.ReadLine();
                        Console.WriteLine($"Enter password for '{username}': ");
                        string password = Console.ReadLine();
                    }
                    break;
                case "L":
                    {
                        Console.WriteLine("Enter username: ");
                        string username = Console.ReadLine();
                        Console.WriteLine($"Enter password for '{username}': ");
                        string password = Console.ReadLine();
                        if (Login(username, password))
                        {
                            Console.WriteLine("Logged in!");
                        }
                        else
                        {
                            Console.WriteLine("Wrong username/password");
                        }
                    }
                    break;
            }
        }

        static string EncryptPassword(string password)
        {
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            byte[] password_bytes = Encoding.ASCII.GetBytes(password);
            byte[] encrypted_bytes = sha256.ComputeHash(password_bytes);

            return Convert.ToBase64String(encrypted_bytes);
        }

        static bool Login(string username, string password)
        {
            string hashed_password = EncryptPassword(password);

            using (MySqlCommand command = new MySqlCommand($"SELECT * FROM users WHERE username = '{username}' AND hashed_password = '{hashed_password}';", con))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
        }

        static void Register(string username, string password)
        {
            string hashed_password = EncryptPassword(password);

            using (MySqlCommand command = new MySqlCommand($"INSERT INTO users(username, hashed_password) VALUES('{username}', '{hashed_password}');", con))
            {
                command.ExecuteNonQuery();
            }
        }


    }
}

