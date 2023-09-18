using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2Day1_4.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Week2Day1_4.Managers
{
    public class PlayerManager
    {
        private List<Player> unsoldPlayers = new List<Player>();
        private string connectionString = ConfigurationManager.ConnectionStrings["IPLBiddingDB"].ConnectionString;


        public void AddPlayerToDatabase(Player player)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Players (Name, Age, Category, BiddingPrice) VALUES (@Name, @Age, @Category, @BiddingPrice)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", player.Name);
                        command.Parameters.AddWithValue("@Age", player.Age);
                        command.Parameters.AddWithValue("@Category", player.Category);
                        command.Parameters.AddWithValue("@BiddingPrice", player.BiddingPrice);

                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("Player added to the database successfully!");
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public void DisplayAllPlayers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM Players";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Console.WriteLine($"Player ID: {reader["Id"]}");
                            Console.WriteLine($"Name: {reader["Name"]}");
                            Console.WriteLine($"Age: {reader["Age"]}");
                            Console.WriteLine($"Category: {reader["Category"]}");
                            Console.WriteLine($"Bidding Price: {reader["BiddingPrice"]}");
                            Console.WriteLine();
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public void DeletePlayer(int playerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("asdasdasdasd"+playerId);
                    string deleteQuery = "DELETE FROM Players WHERE Id = @PlayerID";

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@PlayerID", playerId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Player deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Player not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }



        public void AddPlayer()
        {
            Console.Write("Enter Player Name: ");
            string playerName = Console.ReadLine();

            Console.Write("Enter Player Age: ");
            int playerAge = int.Parse(Console.ReadLine());

            Console.Write("Enter Player Category: ");
            string playerCategory = Console.ReadLine();

            Console.Write("Enter Bidding Price: ");
            decimal biddingPrice = decimal.Parse(Console.ReadLine());

            Player newPlayer = new Player
            {
                Name = playerName,
                Age = playerAge,
                Category = playerCategory,
                BiddingPrice = biddingPrice
            };

            unsoldPlayers.Add(newPlayer);
            AddPlayerToDatabase(newPlayer);
            Console.WriteLine("Player added successfully!");
        }

        public void EditPlayer()
        {
            Console.Write("Enter Player ID to edit: ");
            int playerId = int.Parse(Console.ReadLine());

            Player playerToEdit = unsoldPlayers.FirstOrDefault(p => p.Id == playerId);

            if (playerToEdit != null)
            {
                Console.Write("Enter new Player Name (leave empty to keep current): ");
                string newPlayerName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newPlayerName))
                {
                    playerToEdit.Name = newPlayerName;
                }

                Console.Write("Enter new Player Age (leave empty to keep current): ");
                string newAgeInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newAgeInput) && int.TryParse(newAgeInput, out int newAge))
                {
                    playerToEdit.Age = newAge;
                }

                Console.Write("Enter new Player Category (leave empty to keep current): ");
                string newCategory = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newCategory))
                {
                    playerToEdit.Category = newCategory;
                }

                Console.Write("Enter new Bidding Price (leave empty to keep current): ");
                string newPriceInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newPriceInput) && decimal.TryParse(newPriceInput, out decimal newPrice))
                {
                    playerToEdit.BiddingPrice = newPrice;
                }

                Console.WriteLine("Player information updated successfully!");
            }
            else
            {
                Console.WriteLine($"Player with ID {playerId} not found.");
            }
        }

        public void DeletePlayer()
        {
            Console.Write("Enter Player ID to delete: ");
            int playerId = int.Parse(Console.ReadLine());
            DeletePlayer(playerId);
            Player playerToDelete = unsoldPlayers.FirstOrDefault(p => p.Id == playerId);

            if (playerToDelete != null)
            {
                unsoldPlayers.Remove(playerToDelete);
                
                Console.WriteLine("Player deleted successfully!");
            }
            else
            {
                Console.WriteLine($"Player with ID {playerId} not found.");
            }
        }

        public void ListPlayers()
        {
            Console.WriteLine("\nList of Players:");
            foreach (var player in unsoldPlayers)
            {
                Console.WriteLine($"Player ID: {player.Id}, Name: {player.Name}, Age: {player.Age}, Category: {player.Category}, Bidding Price: {player.BiddingPrice:C}");
            }
        }

        public Player FindPlayer(string playerName)
        {
            return unsoldPlayers.FirstOrDefault(player => player.Name.Equals(playerName, StringComparison.OrdinalIgnoreCase));
        }

        public void ListPlayers1()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Players";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable playersTable = new DataTable();

                adapter.Fill(playersTable);

                foreach (DataRow row in playersTable.Rows)
                {
                    Console.WriteLine($"Player ID: {row["Id"]}");
                    Console.WriteLine($"Naddddddddme: {row["Name"]}");
                    Console.WriteLine($"Age: {row["Age"]}");
                    Console.WriteLine($"Category: {row["Category"]}");
                    Console.WriteLine($"Bidding Price: {row["BiddingPrice"]}");
                    Console.WriteLine();
                }
            }
        }
    }
}
