using System;
using System.Collections.Generic;
using System.Text;

namespace EX8A_Roulette
{
    class SpinWheel
    {
        public static int spinWheel()
        {
            Random r = new Random();
            int ball = r.Next(37);
            return ball;
        }

    }
}
