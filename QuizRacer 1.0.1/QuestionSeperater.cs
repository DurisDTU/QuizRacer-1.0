using System;
using System.Collections.Generic;
using System.Text;

namespace QuizRacer
{
    class QuestionSeperater
    {
        public Questions[] QSeperate(String context)
        {
            String [] question = context.Split('}');

            //the first 30 chars of the string is unused.
            question[0] = question[0].Substring(29);

            Questions [] questionArray = new Questions[question.Length];

                for (int i = 0; i < question.Length - 2; i++)
                {

                //creates a question object
                Questions q = new Questions(0, "", "", "", "", "", "");
                //Sets the question number
                q.QuestionN = i;

                String [] questionSeperated = question[i].Split(new string[] { ",\"" }, StringSplitOptions.None); // ,"
                for (int j = 0; j < questionSeperated.Length; j++)
                {
                    switch (j)
                    {
                        case 0:
                            //1st Substring of the question is the category
                            q.Category = questionSeperated[j].Substring(13).Replace("\"", "");
                            break;
                        case 1:
                            //2nd Substring of the question is the type
                            q.Type = questionSeperated[j].Substring(7).Replace("\"", "");
                            break;
                        case 2:
                            //3rd Substring of the question is the difficulty
                            q.Difficulty = questionSeperated[j].Substring(13).Replace("\"", "");
                            break;
                        case 3:
                            //4th Substring of the question is the question itself
                            q.Question = questionSeperated[j].Substring(11).Replace("\"", "");
                            break;
                        case 4:
                            //5th Substring of the question is the correct answer
                            q.CorrectAnswer = questionSeperated[j].Substring(17).Replace("\"", "");
                            break;
                        case 5:
                            //6th Substring of the question is the incorrect answers.
                            q.IncorrectAnswer = questionSeperated[j].Substring(20).Replace(",", "");
                            break;
                        case 6:
                            q.IncorrectAnswer = String.Concat(q.IncorrectAnswer, questionSeperated[j].Replace(",", ""));
                            break;
                        case 7:
                            q.IncorrectAnswer = String.Concat(q.IncorrectAnswer, questionSeperated[j].Replace(",", ""));
                            break;
                    }

                }
                questionArray[i] = new Questions(q.QuestionN, q.Category, q.Type, q.Difficulty,
                                       q.Question, q.CorrectAnswer, q.IncorrectAnswer);
            }

            return questionArray;
        }

        public Boolean IsCorrectAnswerBoolean(char answer, String[] answerOptions, Questions question)
        {
            switch (answer)
            {
                case 'a':
                    if (answerOptions[0].Equals(question.CorrectAnswer))
                    {
                        return true;
                    }
                    else return false;
                case 'b':
                    if (answerOptions[1].Equals(question.CorrectAnswer))
                    {
                        return true;
                    }
                    else return false;
                default: return false;
            }
        }

        public Boolean IsCorrectAnswerMultiple(char answer, String[] answerOptions, Questions question)
        {
            switch (answer)
            {
                case 'a':
                    if (answerOptions[0].Equals(question.CorrectAnswer))
                    {
                        return true;
                    }
                    else return false;
                case 'b':
                    if (answerOptions[1].Equals(question.CorrectAnswer))
                    {
                        return true;
                    }
                    else return false;
                case 'c':
                    if (answerOptions[2].Equals(question.CorrectAnswer))
                    {
                        return true;
                    }
                    else return false;
                case 'd':
                    if (answerOptions[3].Equals(question.CorrectAnswer))
                    {
                        return true;
                    }
                    else return false;
                default: return false;
            }
        }

        public Boolean IsValidAnswerMultiple(char answer)
        {
            if (answer == 'a' || answer == 'b' || answer == 'c' || answer == 'd' || answer == 'x')
            {
                return true;
            }
            else return false;
        }

        public Boolean IsValidAnswerBool(char answer)
        {
            if (answer == 'a' || answer == 'b')
            {
                return true;
            }
            else return false;
        }
    }
}
