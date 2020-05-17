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
                        clientQueue5.Dequeue();
                        AddClientToQueue(client);
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
                        clientQueue10.Dequeue();
                        AddClientToQueue(client);
                        
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
                        clientQueue15.Dequeue();
                        AddClientToQueue(client);
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
                        clientQueue20.Dequeue();
                        AddClientToQueue(client);
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
    }
}
