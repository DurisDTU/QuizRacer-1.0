using System;
using System.Collections.Generic;
using System.Text;

namespace QuizRacer
{
    class QuestionDisplay
    {
        //points, question option a-d, question line 1 and 2 (q, q1), 'e' is used for the 5th field needed for menuMode.
        int k, p, a, b, c, d, e, q, q1= 0;
        static int rowSize = 60;
        static int collumSize = 20;

        //creates 2d array
        char[,]  display = new char[collumSize, rowSize];


        public void resetFields()
        {
            for (int i = 0; i < collumSize; i++)
            {
                for (int j = 0; j < rowSize; j++)
                {
                    if (i == 0 || i == collumSize - 1 || j == 0 || j == rowSize - 1)
                    {
                        display[i, j] = '#';
                    }
                    else display[i, j] = ' ';

                }
            }
        }

        public void displayStart(int start, String message)
        {

            String startString = message;

            for (int i = 0; i < collumSize; i++)
            {
                for (int j = 0; j < rowSize; j++)
                {
                    if (i == 0 || i == collumSize - 1 || j == 0 || j == rowSize - 1)
                    {
                        display[i,j] = '#';
                    }
                    else if (i == 3 && j >= start && (k <= startString.ToCharArray().Length - 1))
                    {
                        display[i,j] = startString.ToCharArray()[k];
                        k++;
                    }
                    else display[i,j] = ' ';

                }
            }

            for (int i = 0; i < collumSize; i++)
            {
                for (int j = 0; j < rowSize; j++)
                {
                    Console.Write(display[i,j]);
                }
                Console.WriteLine();
            }
            k = 0;
            resetFields();
        }

        public void gameDisplayMultiple(String name, int points, String question, String optionA, String optionB, String optionC, String optionD)
        {
            String point = "Antal Points:" + points.ToString();
            String option1 = "A: " + optionA;
            String option2 = "B: " + optionB;
            String option3 = "C: " + optionC;
            String option4 = "D: " + optionD;


            for (int i = 0; i < collumSize; i++)
            {
                for (int j = 0; j < rowSize; j++)
                {
                    if (i == 0 || i == collumSize - 1 || j == 0 || j == rowSize - 1)
                    {
                        display[i,j] = '#';
                    }
                    else if (i == 1)
                    {
                        //prints the name to the top left of the display
                        if (j < 20 && j >= 1 && k <= name.Length - 1)
                        {
                            display[i,j] = name.ToCharArray()[k];
                            k++;
                            //prints the score to the top right on the display
                        }
                        else if (j >= 41 && j < rowSize - 1 && p <= point.ToCharArray().Length - 1)
                        {
                            display[i,j] = point.ToCharArray()[p];
                            p++;
                        }

                        // Puts in the different question options
                    }
                    else if (i > 7 && i < 10)
                    {
                        switch (i)
                        {
                            case 8:
                                if (q < (questionSplit(question)[0].ToCharArray().Length))
                                    display[i,j] = questionSplit(question)[0].ToCharArray()[q];
                                q++;
                                break;
                            case 9:
                                if (questionSplit(question)[1] != null)
                                {
                                    if (q1 < (questionSplit(question)[1].ToCharArray().Length))
                                        display[i,j] = questionSplit(question)[1].ToCharArray()[q1];
                                    q1++;
                                }
                                break;
                        }

                    }
                    else if (i == 14 && j >= 2 && a < option1.ToCharArray().Length)
                    {
                        display[i,j] = option1.ToCharArray()[a];
                        a++;
                    }
                    else if (i == 15 && j >= 2 && b < option2.ToCharArray().Length)
                    {
                        display[i,j] = option2.ToCharArray()[b];
                        b++;
                    }
                    else if (i == 16 && j >= 2 && c < option3.ToCharArray().Length)
                    {
                        display[i,j] = option3.ToCharArray()[c];
                        c++;
                    }
                    else if (i == 17 && j >= 2 && d < option4.ToCharArray().Length)
                    {
                        display[i,j] = option4.ToCharArray()[d];
                        d++;
                    }
                    else display[i,j] = ' ';
                }
                reset();
            }


            //prints out the display
            for (int i = 0; i < collumSize; i++)
            {
                for (int j = 0; j < rowSize; j++)
                {
                    Console.Write(display[i,j]);
                }
                Console.WriteLine();
            }
            //resets the global variable.
            k = 0;
            resetFields();
        }

        public void gameDisplayBoolean(String name, int points, String question)
        {
            String point = "Antal Points:" + points.ToString();
            String option1 = "A: True";
            String option2 = "B: False";

            for (int i = 0; i < collumSize; i++)
            {
                for (int j = 0; j < rowSize; j++)
                {
                    if (i == 0 || i == collumSize - 1 || j == 0 || j == rowSize - 1)
                    {
                        display[i,j] = '#';
                    }
                    else if (i == 1)
                    {
                        //prints the name to the top left of the display
                        if (j < 20 && j >= 1 && k <= name.Length - 1)
                        {
                            display[i,j] = name.ToCharArray()[k];
                            k++;
                            //prints the score to the top right on the display
                        }
                        else if (j >= 41 && j < rowSize - 1 && p <= point.ToCharArray().Length - 1)
                        {
                            display[i,j] = point.ToCharArray()[p];
                            p++;
                        }

                        // Puts in the different question options
                    }
                    else if (i > 7 && i < 10)
                    {
                        switch (i)
                        {
                            case 8:
                                if (q < (questionSplit(question)[0].ToCharArray().Length))
                                    display[i,j] = questionSplit(question)[0].ToCharArray()[q];
                                q++;
                                break;
                            case 9:
                                if (questionSplit(question)[1] != null)
                                {
                                    if (q1 < (questionSplit(question)[1].ToCharArray().Length))
                                        display[i,j] = questionSplit(question)[1].ToCharArray()[q1];
                                    q1++;
                                }
                                break;
                        }

                    }
                    else if (i == 14 && j >= 2 && a <= option1.ToCharArray().Length - 1)
                    {
                        display[i,j] = option1.ToCharArray()[a];
                        a++;
                    }
                    else if (i == 15 && j >= 2 && b <= option1.ToCharArray().Length - 1)
                    {
                        display[i,j] = option2.ToCharArray()[b];
                        b++;
                    }
                    else display[i,j] = ' ';
                }
                reset();
            }


            //prints out the display
            for (int i = 0; i < collumSize; i++)
            {
                for (int j = 0; j < rowSize; j++)
                {
                    Console.Write(display[i,j]);
                }
                Console.WriteLine();
            }
            //resets the global variable.
            k = 0;
            resetFields();
        }

        private String[] questionSplit(String question)
        {
            String[] questionArray = new String[2];

            if (question.Length > 56)
            {
                questionArray[0] = question.Substring(0, question.LastIndexOf(" ", 55));
                questionArray[1] = question.Substring(question.LastIndexOf(" ", 55));
            }
            else questionArray[0] = question;

            return questionArray;
        }

        private void reset()
        {
            a = 0;
            b = 0;
            c = 0;
            d = 0;
            e = 0;
            p = 0;
            q = 0;
            q1 = 0;
        }

        public void GameDisplayMode(String name, String text, String optionA, String optionB, String optionC, String optionD, String optionBack)
        {
            String option1 = "A: " + optionA;
            String option2 = "B: " + optionB;
            String option3 = "C: " + optionC;
            String option4 = "D: " + optionD;
            String option5 = "X: " + optionBack;


            for (int i = 0; i < collumSize; i++)
            {
                for (int j = 0; j < rowSize; j++)
                {
                    if (i == 0 || i == collumSize - 1 || j == 0 || j == rowSize - 1)
                    {
                        display[i, j] = '#';
                    }
                    else if (i == 1)
                    {
                        //prints the name to the top left of the display
                        if (j < 20 && j >= 1 && k <= name.Length - 1)
                        {
                            display[i, j] = name.ToCharArray()[k];
                            k++;
                        }
                    }

                    else if (i > 7 && i < 10)
                    {
                        switch (i)
                        {
                            case 8:
                                if (q < (questionSplit(text)[0].ToCharArray().Length))
                                    display[i, j] = questionSplit(text)[0].ToCharArray()[q];
                                q++;
                                break;
                            case 9:
                                if (questionSplit(text)[1] != null)
                                {
                                    if (q1 < (questionSplit(text)[1].ToCharArray().Length))
                                        display[i, j] = questionSplit(text)[1].ToCharArray()[q1];
                                    q1++;
                                }
                                break;
                        }

                    }
                    else if (i == 14 && j >= 2 && a < option1.ToCharArray().Length)
                    {
                        display[i, j] = option1.ToCharArray()[a];
                        a++;
                    }
                    else if (i == 15 && j >= 2 && b < option2.ToCharArray().Length)
                    {
                        display[i, j] = option2.ToCharArray()[b];
                        b++;
                    }
                    else if (i == 16 && j >= 2 && c < option3.ToCharArray().Length)
                    {
                        display[i, j] = option3.ToCharArray()[c];
                        c++;
                    }
                    else if (i == 17 && j >= 2 && d < option4.ToCharArray().Length)
                    {
                        display[i, j] = option4.ToCharArray()[d];
                        d++;
                    }
                    else if (i == 18 && j >= 2 && e < option5.ToCharArray().Length)
                    {
                        display[i, j] = option5.ToCharArray()[e];
                        e++;
                    }
                    else display[i, j] = ' ';
                }
                reset();
            }


            //prints out the display
            for (int i = 0; i < collumSize; i++)
            {
                for (int j = 0; j < rowSize; j++)
                {
                    Console.Write(display[i, j]);
                }
                Console.WriteLine();
            }
            //resets the global variable.
            k = 0;
            resetFields();
        }
    }
}
