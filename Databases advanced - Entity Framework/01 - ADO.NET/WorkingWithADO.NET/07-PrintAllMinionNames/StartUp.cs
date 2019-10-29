using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _07_PrintAllMinionNames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string conString = "Server = DESKTOP-PHQG6TO\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true;";
            List<string> MinionNames = new List<string>();

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                string selectMinionSql = "SELECT Name FROM Minions";

                using (SqlCommand command = new SqlCommand(selectMinionSql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MinionNames.Add((string)reader[0]);
                        }
                    }
                }
            }

            for (int i = 0; i < (MinionNames.Count / 2); i++)
            {
                Console.WriteLine(MinionNames[i]);
                Console.WriteLine(MinionNames[MinionNames.Count - i - 1]);
            }

            if (MinionNames.Count % 2 != 0)
            {
                Console.WriteLine(MinionNames[MinionNames.Count / 2]);
            }
        }
    }
}
