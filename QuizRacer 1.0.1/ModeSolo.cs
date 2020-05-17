using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

namespace QuizRacer
{
    class ModeSolo
    {


        public static void SoloGame(Player player, GameSettings gS)
        {
            Boolean waitingForInput = false;
            Boolean insideQuestion = false;

            String[] questionAnswersBoolean = { "True", "False" };

            QuestionSeperater qS = new QuestionSeperater();
            QuestionDisplay qD = new QuestionDisplay();
            ProfileUpdater updater = new ProfileUpdater();
            PointCalculater pCalculater = new PointCalculater();
            ModeGameSettings mgs = new ModeGameSettings();
            //Fetches the question string from the website (edit the last number to how many questions you want.
            WebClient client = new WebClient();
            string sb = client.DownloadString(mgs.GameSettingURL(gS));

            //Places the questions into an array of questions
            Questions[] questions = qS.QSeperate(sb);

            qD.displayStart(15, "Press Enter To Start The Game");

            waitingForInput = true;
            while (waitingForInput)
            {
                if (string.IsNullOrEmpty(Console.ReadLine()))
                {
                    Thread.Sleep(1000);
                    qD.displayStart(8, "Use the A,B,C,D keys to indicate your answer");
                    Thread.Sleep(2000);
                    qD.displayStart(8, "You have 15 secounds to answer each question");
                    Thread.Sleep(2000);
                    waitingForInput = false;
                }
                else
                {
                    qD.displayStart(15, "Invalid input, please press enter");
                }
            }

            for (int i = 0; i < questions.Length - 2; i++)
            {

                if (questions[i].Type.Equals("multiple"))
                {
                    String[] questionAnswersMultiple = MixerBag.OptionMixer(questions[i].CorrectAnswer, questions[i].IncorrectAnswer);

                    //Displays the question, with the options.
                    qD.gameDisplayMultiple(player.Name, player.Score, questions[i].Question,
                            questionAnswersMultiple[0], questionAnswersMultiple[1], questionAnswersMultiple[2], questionAnswersMultiple[3]);

                    waitingForInput = true;
                    insideQuestion = true;

                    while (insideQuestion)
                    {
                        Thread t = new Thread(pCalculater.Count);
                        t.Start();

                        while (waitingForInput)
                        {
                            //await answer input
                            char answer = Answer();

                            if (qS.IsValidAnswerMultiple(answer))
                            {
                                if (qS.IsCorrectAnswerMultiple(answer, questionAnswersMultiple, questions[i]))
                                {
                                    qD.displayStart(15, "That's correct! ");
                                    updater.UpdateProfileCorrectAnswer(player, pCalculater.GetPoints());

                                    Thread.Sleep(1000);
                                    pCalculater.ResetPointCounter();
                                    waitingForInput = false;
                                } 
                                else
                                {
                                    qD.displayStart(15, "The correct answer was: " + questions[i].CorrectAnswer);
                                    updater.UpdateProfileIncorrectAnswer(player);

                                    Thread.Sleep(2000);
                                    waitingForInput = false;
                                }
                            }
                            else
                            {
                                qD.displayStart(8, "Invalid input, please use A, B, C or D.");
                                Thread.Sleep(2000);
                                qD.gameDisplayMultiple(player.Name, player.Score, questions[i].Question,
                                questionAnswersMultiple[0], questionAnswersMultiple[1], questionAnswersMultiple[2], questionAnswersMultiple[3]);
                            }
                        }
                        insideQuestion = false;
                    }


                }

                else if (questions[i].Type.Equals("boolean"))
                {
                    //Displays the question with True or False.
                    qD.gameDisplayBoolean(player.Name, player.Score, questions[i].Question);

                    waitingForInput = true;
                    insideQuestion = true;

                    while (insideQuestion)
                    {
                        Thread t = new Thread(pCalculater.Count);
                        t.Start();

                        while (waitingForInput)
                        {
                            //await answer input
                            char answer = Answer();
                      
                            if (qS.IsValidAnswerBool(answer))
                            {
                                if (qS.IsCorrectAnswerBoolean(answer, questionAnswersBoolean, questions[i]))
                                {
                                    qD.displayStart(15, "That's correct! ");
                                    updater.UpdateProfileCorrectAnswer(player, pCalculater.GetPoints());

                                    Thread.Sleep(1000);
                                    pCalculater.ResetPointCounter();
                                    waitingForInput = false;
                                }
                                else
                                {
                                    qD.displayStart(15, "The correct answer was: " + questions[i].CorrectAnswer);
                                    updater.UpdateProfileIncorrectAnswer(player);

                                    Thread.Sleep(2000);
                                    waitingForInput = false;
                                }
                            }
                            else
                            {
                                qD.displayStart(8, "Invalid input, please use A, B.");
                                Thread.Sleep(2000);
                                qD.gameDisplayBoolean(player.Name, player.Score, questions[i].Question);
                            }
                        }
                        insideQuestion = false;
                    }
                }
            }

            if (player.Score > player.Gethighscore(player.Name))
            {
                player.Highscore = player.Score;
            }

            player.UpdatePlayerStats(player);

            qD.gameDisplayMultiple(player.Name, player.Score, "Thanks for playing! Here are your stats:",
                                                                        "Correct answers: " + player.CorrectAnswers,
                                                                        "Total answered questions: " + player.AnsweredQuestions,
                                                                        "Highscore: " + player.Highscore,
                                                                        ""//insert won games
                                                                        );
        }

        private static char Answer()
        {
            char answer = Console.ReadLine()[0];
            char.ToLower(answer);

            return answer;
        }
    }
}
