using QuizRacer_1._0._1;
using System;
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
            ModeSolo.SoloGame(player, gs);

            ClientSend.Servercall(request.IP + matchID + player.Score);

            int opponentScore = Int32.Parse(ClientReceive.ReceiveMessage());
            while (opponentScore == 0)
            {
                opponentScore = Int32.Parse(ClientReceive.ReceiveMessage());
                Thread.Sleep(3000);
            }


        }
    }
}
