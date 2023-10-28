using System;
using System.Data.SQLite;

namespace Task1
{
    public class Database
    {
        private const string ConnectionString = "Data Source=DataBase.db;Version=3;";
        
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

        public static List<Human> GetHumans()
        {
            List<Human> humans = new List<Human>();
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
                            humans.Add(new Human{Id = reader.GetInt32(0), Firstname = reader.GetString(1), Lastname = reader.GetString(2)});
                        }
                    }
                }
            }
            return humans;
        }
        public static void DeleteHuman(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Humans WHERE Id = @Id";
                using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}