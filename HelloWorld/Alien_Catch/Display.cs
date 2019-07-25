using System;


namespace grid
{
    class Display
    {
        public static void DrawScreen()
        {
            Console.Clear();
            for (int i = 0; i < 80; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine();
            for (int i = 0; i < 20; i++)
            {
                Console.Write("|");
                for (int j = 0; j < 78; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("|\n");
            }
            for (int k = 0; k < 80; k++)
            {
                Console.Write("_");
            }
            return;
        }
    }
}
