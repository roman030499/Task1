using System;
using System.Data.SQLite;

namespace Task1
{
    public class Database
    {
        private const string ConnectionString = "Data Source=DataBase.db;Version=3;";

        public static void CreateDatabase()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Humans (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Firstname TEXT,
                        Lastname TEXT
                    )";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void InsertHuman(Human human)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Humans (Firstname, Lastname) VALUES (@Firstname, @Lastname)";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Firstname", human.Firstname);
                    command.Parameters.AddWithValue("@Lastname", human.Lastname);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DisplayHumans()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Humans";

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Id: {reader["Id"]}, Firstname: {reader["Firstname"]}, Lastname: {reader["Lastname"]}");
                        }
                    }
                }
            }
        }
    }
}