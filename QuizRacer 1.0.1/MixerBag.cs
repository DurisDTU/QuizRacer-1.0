using System;
using System.Collections.Generic;
using System.Text;

namespace QuizRacer

{
    public static class MixerBag
    {
        public static string[] OptionMixer(string correctAnswer, string incorrectAnswer)
        {
            string [] incorrectAnswers = incorrectAnswer.Split('\"');
            string [] options = new string[4];

            for (int i = 0; i < incorrectAnswers.Length; i++)
            {
                if (i == 3)
                {
                    options[i] = correctAnswer;
                    break;
                }
                options[i] = incorrectAnswers[i + 1];
            }

            Shuffle(options);

            return options;
        }

        public static void Shuffle<T>(this T[] array)
        {
            System.Random rng = new System.Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
        }
    }
}
