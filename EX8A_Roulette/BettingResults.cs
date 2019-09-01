using System;
using System.Collections.Generic;
using System.Text;

namespace EX8A_Roulette
{
    class BettingResults
    {
        public static int bettingResults(int ball)
        {
            int ballPosition = ball;

            if (ballPosition == 37)
            {
                ballPosition = 00;
                return ballPosition;
            }



        }
    }
}
