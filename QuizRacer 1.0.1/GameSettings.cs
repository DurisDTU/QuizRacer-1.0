using System;
using System.Collections.Generic;
using System.Text;

namespace QuizRacer
{
    class GameSettings
    {
        public string type;
        public string difficulty;
        public int amountOfQuestions;

        public GameSettings(int amountOfQuestions, string type, string difficulty)
        {
            this.amountOfQuestions = amountOfQuestions;
            this.type = type;
            this.difficulty = difficulty;
        }

        public string Type { get; set; }
        public int AmountOfQuestions { get; set; }
        public string Difficulty { get; set; }

    }
}
