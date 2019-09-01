using System;

namespace ProvingPi
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomPositionCreater.RandomPositionCreator();
            Console.WriteLine($"{RandomPositionCreater.orange} in the Orange zone\n\n{RandomPositionCreater.pink} in the Pink zone");
            Console.ReadLine();

            double answer = (3.14159 / 4) * 100;
            Console.WriteLine($"The total area covered by the 1/4 circle is: {Math.Round(answer, 2)}%");
            Console.ReadLine();
        }
    }
}
