using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using QuizRacer_1._0._1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

namespace QuizRacer
{
    class ClientSend
    {
        //public string[] WatToDoArr = [3];

        public static void Servercall(string messageToSend)
        {
            //Parse the necessary information out of the provided string
            string serverIP = "192.168.0.22";
            int serverPort = 8083;

            NetworkComms.SendObject("Message", serverIP, serverPort, messageToSend);

            //NetworkComms.AppendGlobalIncomingPacketHandler<string>("Message", ProcessReceivedMessage);
            //Connection.StartListening(ConnectionType.TCP, new System.Net.IPEndPoint(System.Net.IPAddress.Any, 8084));


            //We have used comms so we make sure to call shutdown
            NetworkComms.Shutdown();
        }

        public static void ProcessReceivedMessage(PacketHeader header, Connection connection, string message)
        {
           
            

            //Console.WriteLine("\nA message was received from " + connection.ToString() + " which said '" + message + "'.");
            //string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True";
            //string[] strSplit = message.Split('+');
            //string MatchID = strSplit[1];
            //string IP = strSplit[2];
            //string getPlayerObj = "SELECT * FROM Users WHERE IP = '"+IP+"'";

            //using (SqlConnection connection1 = new SqlConnection(connString))
            //{
            //    connection1.Open();
            //    SqlCommand createTable = new SqlCommand(getPlayerObj, connection1);
            //    SqlDataReader reader = createTable.ExecuteReader();
            //    while (reader.Read())
            //    {

            //    }

            //}
        }
    }
}
