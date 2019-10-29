using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _05_ChangeTownNameCasing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string conString = "Server = DESKTOP-PHQG6TO\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true;";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                string countryName = Console.ReadLine();
                string updateQuery = @"UPDATE Towns
                                       SET Name = UPPER(Name)
                                     WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
                int rowAffected = -1;

                using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@countryName", countryName);
                    rowAffected = (int)updateCommand.ExecuteNonQuery();
                }

                if (rowAffected == 0)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    string selectQuery = @"SELECT t.Name 
                                            FROM Towns as t
                                            JOIN Countries AS c ON c.Id = t.CountryCode
                                           WHERE c.Name = @countryName";

                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        List<string> cityNames = new List<string>();

                        selectCommand.Parameters.AddWithValue("@countryName", countryName);
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cityNames.Add((string)reader[0]);
                            }
                        }

                        Console.WriteLine($"{rowAffected} town names were affected.");
                        Console.WriteLine("[" + string.Join(", ", cityNames) + "]");
                    }
                }
            }
        }
    }
}
