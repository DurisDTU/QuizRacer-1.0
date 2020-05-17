using System;
using System.Collections.Generic;
using System.Text;

namespace QuizRacer
{
    class ModeGameSettings
    {
        QuestionDisplay qD = new QuestionDisplay();
        QuestionSeperater qS = new QuestionSeperater();

        public string GameSettingURL(GameSettings gS)
        {
            string type, difficulty;
            string url = "https://opentdb.com/api.php?amount=" + gS.amountOfQuestions;

            if (gS.type != "any")
            {
                type = "&type=" + gS.type;
                url = string.Concat(url, type);
            }

            if (gS.difficulty != "any")
            {
                difficulty = "&difficulty=" + gS.difficulty;
                url = string.Concat(url, difficulty);
            }


            return url;
        }

        public void GameSettings(Player player, GameSettings gS)
        {
            qD.gameDisplayMultiple(player.Name, 
                                   player.Score, 
                                   "What settings do you want to change?", 
                                   "Amount of questions: " + gS.amountOfQuestions, 
                                   "Question difficulty: " + gS.difficulty, 
                                   "Question Type: " + gS.type, "Go back");

            //await answer input
            char answer = char.ToLower(Console.ReadKey().KeyChar);

            if (qS.IsValidAnswerMultiple(answer))
            {
                switch (answer)
                {
                    case 'a':
                        ChangeAmount(player, gS);
                        break;
                    case 'b':
                        ChangeDifficulty(player, gS);
                        break;
                    case 'c':
                        ChangeType(player, gS);
                        break;
                    case 'd':
                        
                        break;
                    case 'x':
                        break;

                }
            }
        }

        public void ChangeDifficulty(Player player, GameSettings gS)
        {
            qD.GameDisplayMode(" ", "What difficulty do you want for the questions", "Easy", "Medium", "Hard", "Any", "Cancel");

            char answer = char.ToLower(Console.ReadKey().KeyChar);

            switch (answer)
            {
                case 'a':
                    gS.difficulty = "easy";
                    GameSettings(player, gS);
                    break;
                case 'b':
                    gS.difficulty = "medium";
                    GameSettings(player, gS);
                    break;
                case 'c':
                    gS.difficulty = "hard";
                    GameSettings(player, gS);
                    break;
                case 'd':
                    gS.difficulty = "any";
                    GameSettings(player, gS);
                    break;
                case 'x':
                    GameSettings(player, gS);
                    break;
            }

        }

        public void ChangeType(Player player, GameSettings gS)
        {
            qD.GameDisplayMode(player.Name, "What Type of questions do you want?", "Multiple choice", "True/False", "Any", "", "Cancel");

            char answer = char.ToLower(Console.ReadKey().KeyChar);

            switch (answer)
            {
                case 'a':
                    gS.type = "multiple";
                    GameSettings(player, gS);
                    break;
                case 'b':
                    gS.type = "boolean";
                    GameSettings(player, gS);
                    break;
                case 'c':
                    gS.type = "any";
                    GameSettings(player, gS);
                    break;
                case 'd':
                    GameSettings(player, gS);
                    break;
                case 'x':
                    GameSettings(player, gS);
                    break;
            }

        }

        public void ChangeAmount(Player player, GameSettings gS)
        {
            qD.GameDisplayMode(player.Name, "How many questions do you want?", "5", "10", "15", "20", "Press X to cancel");

            char answer = char.ToLower(Console.ReadKey().KeyChar);

            switch (answer)
            {
                case 'a':
                    gS.amountOfQuestions = 5;
                    GameSettings(player, gS);
                    break;
                case 'b':
                    gS.amountOfQuestions = 10;
                    GameSettings(player, gS);
                    break;
                case 'c':
                    gS.amountOfQuestions = 15;
                    GameSettings(player, gS);
                    break;
                case 'd':
                    gS.amountOfQuestions = 20;
                    GameSettings(player, gS);
                    break;
                case 'x':
                    GameSettings(player, gS);
                    break;
            }

            GameSettings(player, gS);
        }

    }

}
//https://opentdb.com/api.php?amount=10&difficulty=easy&type=multiple