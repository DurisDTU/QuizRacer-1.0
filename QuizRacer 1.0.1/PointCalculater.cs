using System;
using System.Threading;

namespace QuizRacer
{
    class PointCalculater
    {
        int points;
        public void Count()
        {
            for (int i = 150; i > 0; i--)
            {
                Thread.Sleep(100);
                points = i;
            }
        }

        public int GetPoints()
        {
            return points;
        }

        public void ResetPointCounter()
        {
            points = 150;
        }
    }
}
