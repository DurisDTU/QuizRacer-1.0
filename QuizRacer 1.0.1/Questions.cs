using System;
using System.Collections.Generic;
using System.Text;

namespace QuizRacer
{
    class Questions
    {
        public Questions(int questionN, string category, string type, string difficulty, string question, string correctAnswer, string incorrectAnswer)
        {
            QuestionN = questionN;
            Category = category;
            Type = type;
            Difficulty = difficulty;
            Question = question;
            CorrectAnswer = correctAnswer;
            IncorrectAnswer = incorrectAnswer;
        }

        public int QuestionN { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Difficulty { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string IncorrectAnswer { get; set; }
    }
}
