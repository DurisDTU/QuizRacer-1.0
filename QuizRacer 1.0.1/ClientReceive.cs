using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizRacer_1._0._1
{
    class ClientReceive
    {
        public static string serverMessage = "no";
        public static string ReceiveMessage()
        {

            NetworkComms.AppendGlobalIncomingPacketHandler<string>("Message", ProcessReceivedMessage);
            
            //Start listening for incoming connections
            Connection.StartListening(ConnectionType.TCP, new System.Net.IPEndPoint(System.Net.IPAddress.Any, 43987));

            NetworkComms.Shutdown();

            return serverMessage;
        }
        public static void ProcessReceivedMessage(PacketHeader header, Connection connection, string message)
        {
            serverMessage = message;
        }
    }
}
