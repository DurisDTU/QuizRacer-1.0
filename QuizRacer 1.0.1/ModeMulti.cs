using QuizRacer_1._0._1;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace QuizRacer
{
    class ModeMulti
    {

        public static void MultiplayerGame(Player player, GameSettings gs)
        {
            QuestionDisplay qD = new QuestionDisplay();
            MatchRequest request = new MatchRequest(gs);

            qD.displayStart(8, "Waiting for match...");

            ClientSend.Servercall(request.IP+gs.amountOfQuestions);

            string matchID = ClientReceive.ReceiveMessage();
            while (matchID.Equals("no"))
            {
                matchID = ClientReceive.ReceiveMessage();
                Thread.Sleep(3000);

            }
            Console.WriteLine(matchID, "ready for game start");
        }

        public void StartGame(Player player, GameSettings gs)
        {
            ModeSolo.SoloGame(player, gs);
        }

    }
}
