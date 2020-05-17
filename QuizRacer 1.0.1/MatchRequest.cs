
using System.Net;

namespace QuizRacer
{
    class MatchRequest
    {
        public string IP { get; set; }
        public int AmountOfQuestions { get; set; }

        public MatchRequest(GameSettings setting)
        {
            IP = MyIP();
            AmountOfQuestions = setting.AmountOfQuestions;
        }



        public static string MyIP()
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  

            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString() + "+";

            return myIP;
        }
    }
}