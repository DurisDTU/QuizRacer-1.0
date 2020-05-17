using System;
using System.Threading;

namespace QuizRacer
{
    class ModeProfile
    {
        QuestionDisplay qD = new QuestionDisplay();
        QuestionSeperater qS = new QuestionSeperater();

        public void ProfilePage(Player player)
        {
            qD.GameDisplayMode(player.Name, "This is your profile, what do you want to do?", "Show stats", "Change username", "Change Password", "Reset stats", "Go back");

            //await answer input
            char answer = char.ToLower(Console.ReadKey().KeyChar);

            if (qS.IsValidAnswerMultiple(answer))
            {
                switch (answer)
                {
                    case 'a':
                        ShowStats(player);
                        break;
                    case 'b':
                        ChangeUsername(player);
                        break;
                    case 'c':
                        ChangePassword(player);
                        break;
                    case 'd':
                        ResetStats(player);
                        break;
                    case 'x':
                        break;

                }
            }
        }

        public void ShowStats(Player player)
        {
            qD.GameDisplayMode(player.Name, "Here are your stats:",
                                                                               "Correct answers: " + player.CorrectAnswers,
                                                                               "Total answered questions: " + player.AnsweredQuestions,
                                                                               "Highscore: " + player.Highscore,
                                                                               "",
                                                                               "Press X to go back.");

            char answer = char.ToLower(Console.ReadKey().KeyChar);

            if (answer == 'x')
            {
                ProfilePage(player);
            }
            else
            {
                ShowStats(player);
            }
        }

        public void ChangeUsername(Player player)
        {
            qD.displayStart(8, "Type your new username");

            String username = Console.ReadLine();
            player.Name = username;

            qD.displayStart(8, "Your new username is: " + player.Name);
            Thread.Sleep(1000);
            ProfilePage(player);
        }

        public void ResetStats(Player player)
        {
            qD.gameDisplayBoolean(player.Name, 0, "Are you sure you want to reset the stats?");

            char answer = char.ToLower(Console.ReadKey().KeyChar);

            if (qS.IsValidAnswerBool(answer))
            {
                if (answer == 'a')
                {
                    player.CorrectAnswers = 0;
                    player.AnsweredQuestions = 0;
                    player.Highscore = 0;
                    player.Score = 0;

                    ProfilePage(player);

                } else if (answer == 'b')
                {
                    ProfilePage(player);
                } else
                {
                    qD.displayStart(8, "Invalid input, please use A, B.");
                    Thread.Sleep(2000);
                    ResetStats(player);
                }
            }
        }

        //TODO: Password
        public void ChangePassword(Player player)
        {
            qD.displayStart(8, "Type your new password");

            String password = Console.ReadLine();

            //player.Password = password;

            qD.displayStart(8, "Your password has been changed succesfully!");
            Thread.Sleep(1000);
            ProfilePage(player);
        }
    }
}
