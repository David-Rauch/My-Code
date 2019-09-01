using System;
using System.Collections.Generic;
using System.Text;

namespace ProvingPi
{
    public class RandomPositionCreater
    {
        public static int orange;
        public static int pink;
        public static void RandomPositionCreator()
        {
            for (int i=0; i<100000; i++)
            {
                Random val = new Random();
                Dot test = new Dot(0,1);
                //Random yVal = new Random();
                test.x = val.NextDouble();
                test.y = val.NextDouble();
                double answer = Math.Sqrt(Math.Pow(test.x, 2) + Math.Pow(test.y, 2));
                if (answer>1)
                {
                    orange += 1;
                }
                else
                {
                    pink += 1;
                }
            }
        }
    }
}
