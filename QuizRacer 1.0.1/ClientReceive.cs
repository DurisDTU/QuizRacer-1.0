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

        
        //Trigger the method PrintIncomingMessage when a packet of type 'Message' is received
        //We expect the incoming object to be a string which we state explicitly by using <string>
       NetworkComms.AppendGlobalIncomingPacketHandler<string>("Message", ProcessReceivedMessage);
            //Start listening for incoming connections
            Connection.StartListening(ConnectionType.TCP, new System.Net.IPEndPoint(System.Net.IPAddress.Any, 8084));

            //Print out the IPs and ports we are now listening on
            //Console.WriteLine("Server listening for TCP connection on:");
            //foreach (System.Net.IPEndPoint localEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.TCP))
                //Console.WriteLine("{0}:{1}", localEndPoint.Address, localEndPoint.Port);

            //Let the user close the server
           // Console.WriteLine("\nPress any key to close server.");
            //Console.ReadKey(true);
            
            //We have used NetworkComms so we should ensure that we correctly call shutdown
            NetworkComms.Shutdown();

            return serverMessage;
        }
        public static void ProcessReceivedMessage(PacketHeader header, Connection connection, string message)
        {
            serverMessage = message;
        }
    }
}
