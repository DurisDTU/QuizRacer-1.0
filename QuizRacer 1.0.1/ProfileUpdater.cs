using System;
using System.Collections.Generic;
using System.Text;

namespace QuizRacer
{
    class ProfileUpdater
    {
        public void UpdateProfileCorrectAnswer(Player player, int points)
        {
            player.AnsweredQuestions = player.AnsweredQuestions + 1;
            player.CorrectAnswers = player.CorrectAnswers + 1;
            player.Score = player.Score + points;

            if (player.Highscore < player.Score)
            {
                player.Highscore = player.Score;
            }
                     
        }

        public void UpdateProfileIncorrectAnswer(Player player)
        {
            player.AnsweredQuestions = player.AnsweredQuestions + 1;
        }


    }
}
