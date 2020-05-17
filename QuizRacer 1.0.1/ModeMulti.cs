using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
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

            Client.Servercall(request.IP+gs.amountOfQuestions);

            Console.WriteLine("ready for game start");

            






        }

        public void StartGame(Player player, GameSettings gs)
        {
            ModeSolo.SoloGame(player, gs);
        }

    }
}
