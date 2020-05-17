using System;
using System.Net;
using System.Web;
using System.Threading;

namespace QuizRacer
{
    class Program
    {
        static void Main()
        {
            QuestionSeperater qS = new QuestionSeperater();
            QuestionDisplay qD = new QuestionDisplay();
            ModeProfile profil = new ModeProfile();
            ModeGameSettings mgs = new ModeGameSettings();

            Boolean menuMode = true;
            Boolean gameOn = false;
            char answer;

            qD.displayStart(15, "Please enter you name.");
            String username = Console.ReadLine();

            //Creates a player object
            Player player = new Player
            {
                Name = username
            };

            //creates a player in the database with username
            Player.GetPlayerStats(player);

            //Creates the default game settings
            GameSettings gS = new GameSettings(10, "any", "any");


            qD.displayStart(8, "Welcome");
            Thread.Sleep(1500);

            while (menuMode)
            {
                qD.GameDisplayMode(player.Name, "What do you want to do?", "Play solo.", "Find match", "Go to Profile", "Edit game settings", "Press X to exit");

                //await answer input
                answer = char.ToLower(Console.ReadKey().KeyChar);

                if (qS.IsValidAnswerMultiple(answer)) { 
                    switch (answer)
                    {
                        case 'a':
                            ModeSolo.SoloGame(player, gS);
                            player.Score = 0;
                            break;
                        case 'b':
                            ModeMulti.MultiplayerGame(player, gS);
                            break;
                        case 'c':
                            profil.ProfilePage(player);
                            break;
                        case 'd':
                            mgs.GameSettings(player, gS);
                            break;
                        case 'x':
                            menuMode = false;
                            break;

                    }
                }

                while (gameOn)
                {

                    

                    gameOn = false;
                }
            }
        }        
    }
}
