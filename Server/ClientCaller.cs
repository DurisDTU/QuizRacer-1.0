using NetworkCommsDotNet;

namespace Server
{
    public class ClientNotifier
    {

        public static void ClientCall(ClientObject client, string message)
        {
            NetworkComms.SendObject("Message", client.IP, 8084, message);
        }
    }
}