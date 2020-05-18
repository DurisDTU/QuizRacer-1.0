using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class MatchFinder
    {

        static Queue<ClientObject> clientQueue5 = new Queue<ClientObject>();
        static Queue<ClientObject> clientQueue10 = new Queue<ClientObject>();
        static Queue<ClientObject> clientQueue15 = new Queue<ClientObject>();
        static Queue<ClientObject> clientQueue20 = new Queue<ClientObject>();

        public static void AddClientToQueue(ClientObject client)
        {
            switch (client.NumberofQuestions)
            {
                case "5":
                    string matchType = "5";
                    clientQueue5.Enqueue(client);
                    if (clientQueue5.Count >= 2)
                    {
                        ClientObject client1 = clientQueue5.Dequeue();
                        ClientObject client2 = clientQueue5.Dequeue();
                        CreateMatch(client1, client2, matchType);
                    }
                    else
                    {
                        try
                        {
                            clientQueue5.Dequeue();
                            AddClientToQueue(client);
                        }
                        catch
                        {
                            break;
                        }


                    }

                    break;
                case "10":
                     matchType = "10";
                    clientQueue10.Enqueue(client);
                    Thread.Sleep(10000);
                    if (clientQueue10.Count >= 2)
                    {
                        ClientObject client1 = clientQueue10.Dequeue();
                        ClientObject client2 = clientQueue10.Dequeue();
                        CreateMatch(client1, client2, matchType);
                    }
                    else
                    {
                        try
                        {
                            clientQueue10.Dequeue();
                            AddClientToQueue(client);
                        }
                        catch
                        {
                            break;
                        }                        
                        
                        
                    }
                    break;
                case "15":
                     matchType = "15";
                    clientQueue15.Enqueue(client);
                    if (clientQueue15.Count >= 2)
                    {
                        ClientObject client1 = clientQueue15.Dequeue();
                        ClientObject client2 = clientQueue15.Dequeue();
                        CreateMatch(client1, client2, matchType);
                    }
                    else
                    {
                        try
                        {
                            clientQueue15.Dequeue();
                            AddClientToQueue(client);
                        }
                        catch
                        {
                            break;
                        }


                    }
                    break;
                case "20":
                     matchType = "20";
                    clientQueue20.Enqueue(client);
                    if (clientQueue20.Count >= 2)
                    {
                        ClientObject client1 = clientQueue20.Dequeue();
                        ClientObject client2 = clientQueue20.Dequeue();
                        CreateMatch(client1, client2, matchType);
                    }
                    else
                    {
                        try
                        {
                            clientQueue20.Dequeue();
                            AddClientToQueue(client);
                        }
                        catch
                        {
                            break;
                        }


                    }
                    break;
            }
            
        }

        public static void CreateMatch(ClientObject client1, ClientObject client2, string MatchType)
        {
            string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True";
            string createMatchEntry = "INSERT INTO UserMatch(IP1, IP2, Score1, Score2, MatchType) VALUES ('" + client1.IP + "', '" + client2.IP + "', 0, 0, " + MatchType + ")";
            string getMatchId = "SELECT MatchID FROM UserMatch WHERE IP1 = '" + client1.IP + "' AND IP2 = '" + client2.IP + "'";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand createTable = new SqlCommand(createMatchEntry, connection);
                createTable.ExecuteReader();

            }
            using(SqlConnection connection1 = new SqlConnection(connString))
            {
                connection1.Open();
                SqlCommand findMatchId = new SqlCommand(getMatchId, connection1);

                SqlDataReader reader = findMatchId.ExecuteReader();
                
                    while (reader.Read())
                    {
                    string matchID = Convert.ToString(reader.GetInt32(0));
                    ClientNotifier.ClientCall(client1, matchID);
                    ClientNotifier.ClientCall(client2, matchID);
                }
            }
        }

        public static void SetMatchScore(ClientObject client)
        {
            string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True";
            string setScore1 = "UPDATE UserMatch SET Score1 = '" + client.Score + "' WHERE MatchID = " + client.MatchID;
            string setScore2 = "UPDATE UserMatch SET Score2 = '" + client.Score + "' WHERE MatchID = " + client.MatchID;
            string getClientIP1 = "SELECT IP1 FROM UserMatch WHERE MatchID = " + client.MatchID;

            using(SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                
                SqlCommand findClientIP1 = new SqlCommand(getClientIP1, connection);

                SqlCommand updateScore1 = new SqlCommand(setScore1, connection);
                SqlCommand updateScore2 = new SqlCommand(setScore2, connection);

                SqlDataReader reader = findClientIP1.ExecuteReader();
                
                while (reader.Read())
                {
                    if (client.IP.Equals(reader.GetString(0)))
                    {
                        updateScore1.ExecuteNonQuery();
                    }
                    else
                    {
                        updateScore2.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void GetMatchScores (ClientObject client)
        {
            string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True";

            string getScores = "SELECT Score1, Score2, IP1, IP2 FROM UserMatch WHERE MatchID = '" + client.MatchID;

            ClientObject client2 = new ClientObject();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                
                SqlCommand getScoreCommand = new SqlCommand(getScores, connection);

                SqlDataReader reader = getScoreCommand.ExecuteReader;

                while (reader.Read())
                {
                    string score1 = Convert.ToString(reader.GetInt32(0));
                    string score2 = Convert.ToString(reader.GetInt32(1));
                    string IP1 = reader.GetString(2);
                    string IP2 = reader.GetString(3);
                }

               

                if (score1 == 0 || score2 == 0)
                {
                    Thread.Sleep(5000);
                    GetMatchScores(client);
                } 
                else 
                {   //Client1 IP: 1234 Score: 30     
                    //Client2 IP: 5678 Score: 80
                    if (client.IP.Equals(IP1)) //1234 = 1234
                    {
                        client2.IP = IP2; //5678
                        client2.Score = score2; //80

                        ClientNotifier.ClientCall(client2, client.Score); //5678, 30
                        ClientNotifier.ClientCall(client, client2.Score); //1234, 80
                    }
                    else
                    //Client2 IP: 1234 Score: 30
                    //Client1 IP: 5678 Score: 80
                    {
                        client2.IP = IP1;           //1234
                        client2.Score = score1;     //30

                        ClientNotifier.ClientCall(client2, client.Score); //1234, 80
                        ClientNotifier.ClientCall(client, client2.Score); //5678, 30
                    }
                }
            }
        }
    }   
}

