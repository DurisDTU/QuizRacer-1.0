using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Text;

namespace QuizRacer
{
    public class Player
    {

        public string Name { get; set; }
        public int Score { get; set; }
        public int Highscore { get; set; }
        public int AnsweredQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public int WonGames { get; set; }
        public string IP { get; set; }

        public Player()
        {
            IP = MyIP();
        }

        public int Gethighscore(string name)
        {
            string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True";
            string query = "SELECT Highscore FROM [Users] WHERE [Name] = '" + name + "'";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand getHighscore = new SqlCommand(query, connection);

                SqlDataReader reader = getHighscore.ExecuteReader();

                while (reader.Read())
                {
                    Highscore = reader.GetInt32(0);
                }
            }
            return Highscore;
        }
        public static void GetPlayerStats(Player player)
        {
            string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True";
            string selectQuery = "SELECT * FROM [Users] WHERE [Name] = '" + player.Name + "'";
            string createQuery = "INSERT INTO [Users] ([Name], Highscore, AnsweredQuestions, CorrectAnswers, WonMatches, IP) VALUES ('" + player.Name + "', 0, 0, 0, 0, '"+MyIP()+"')";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand playerInit = new SqlCommand(selectQuery, connection);
                SqlDataReader reader = playerInit.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        player.Name = reader.GetString(1);
                        player.Highscore = reader.GetInt32(2);
                        player.AnsweredQuestions = reader.GetInt32(3);
                        player.CorrectAnswers = reader.GetInt32(4);
                        player.WonGames = reader.GetInt32(5);
                        player.IP = reader.GetString(6);
                    }
                }
                else
                {
                    reader.Close();
                    SqlCommand playerCreate = new SqlCommand(createQuery, connection);
                    SqlCommand updatePlayerObj = new SqlCommand(selectQuery, connection);
                    playerCreate.ExecuteNonQuery();
                    SqlDataReader reader2 = updatePlayerObj.ExecuteReader();
                    while (reader2.Read())
                    {
                        player.Name = reader2.GetString(1);
                        player.Highscore = reader2.GetInt32(2);
                        player.AnsweredQuestions = reader2.GetInt32(3);
                        player.CorrectAnswers = reader2.GetInt32(4);
                        player.WonGames = reader2.GetInt32(5);
                        player.IP = reader2.GetString(6);
                    }
                } 
            }
        }
        public void UpdatePlayerStats(Player player)
        {
            string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True";
            string query = "UPDATE [Users] SET Highscore = " + player.Highscore + ", AnsweredQuestions = " + player.AnsweredQuestions + ", CorrectAnswers = " + player.CorrectAnswers + ", WonMatches= " + player.WonGames + " WHERE [Name] = '" + player.Name + "'";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand updatePlayer = new SqlCommand(query, connection);

                SqlDataReader reader = updatePlayer.ExecuteReader();
            }
        }
        public static string MyIP()
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  

            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();

            return myIP;
        }
    }
}
