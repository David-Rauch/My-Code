using System;

namespace grid
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("Enter number of aliens to create: ");
                int numAliens = int.Parse(Console.ReadLine());
                Console.Clear();
                Display.DrawScreen();
                int locationX = 35;
                int locationY = 15;
                Console.SetCursorPosition(locationX, locationY);
                Console.Write("<*>");
                bool gameRunning = true;
                ConsoleKeyInfo userKey;
                int xVal = 22;
                int yVal = 12;
                while (gameRunning)
                {
                    bool dead = false;
                    Display.DrawScreen();
                    if (((xVal-1)==locationX) && (yVal==locationY))
                    {
                        dead = true;
                        numAliens -= 1;
                        if (numAliens == 0)
                        {
                            Console.Clear();
                            Console.Write("\n\n\nLooks like you got them all.  Do you want to try again? ");
                            string answer = Console.ReadLine();
                            if (answer == "Y")
                            {
                                Console.Write("\n\nEnter number of aliens to create: ");
                                int newNumAliens = int.Parse(Console.ReadLine());
                                numAliens = newNumAliens;
                                Console.Clear();
                                Display.DrawScreen();
                            }
                            else
                            {
                                gameRunning = false;
                                Console.Clear();
                                break;
                            }
                        }
                    }
                    if (xVal != 77)
                    { xVal += 1; }
                    if (dead==true)
                    {
                        Random xRandom = new Random();
                        xVal = xRandom.Next(1, 78);
                        Random yRandom = new Random();
                        yVal = yRandom.Next(1, 21);
                        Console.SetCursorPosition(xVal, yVal);
                        Console.Write("x");
                        dead = false;
                    }
                    Console.SetCursorPosition(xVal, yVal);
                    Console.Write("x");
                    Console.SetCursorPosition(25, 25);
                    Console.WriteLine($"\nyou have {numAliens} aliens left to get");        
                    Console.SetCursorPosition(locationX, locationY);
                    Console.Write("<*>");
                    if (dead == false)
                    {
                        userKey = Console.ReadKey(true);

                        switch (userKey.Key)
                        {
                            case (ConsoleKey.NumPad4):
                                if (locationX > 1)
                                {
                                    locationX -= 1;
                                }
                                break;
                            case ConsoleKey.NumPad7:
                                if (locationX > 1)
                                {
                                    if (locationY > 1)
                                    {
                                        locationY -= 1;
                                    }
                                    locationX -= 1;
                                }
                                break;
                            case ConsoleKey.NumPad8:
                                if (locationY > 1)
                                {
                                    locationY -= 1;
                                }
                                break;
                            case ConsoleKey.NumPad9:
                                if (locationX < 76)
                                {
                                    if (locationY > 1)
                                    {
                                        locationY -= 1;
                                    }
                                    locationX += 1;
                                }
                                break;
                            case ConsoleKey.NumPad6:
                                if (locationX < 76)
                                {
                                    locationX += 1;
                                }
                                break;
                            case ConsoleKey.NumPad3:
                                if (locationX < 76)
                                {
                                    if (locationY < 20)
                                    {
                                        locationY += 1;
                                    }
                                    locationX += 1;
                                }
                                break;
                            case ConsoleKey.NumPad2:
                                if (locationY < 20)
                                {
                                    locationY += 1;
                                }
                                break;
                            case ConsoleKey.NumPad1:
                                if (locationX > 1)
                                {
                                    if (locationY < 20)
                                    {
                                        locationY += 1;
                                    }
                                    locationX -= 1;
                                }
                                break;
                            case ConsoleKey.NumPad5:
                                {
                                    Random xRandom = new Random();
                                    locationX = xRandom.Next(1, 78);
                                    Random yRandom = new Random();
                                    locationY = yRandom.Next(1, 21);
                                }
                                break;
                            case ConsoleKey.Escape:
                                {
                                    gameRunning = false;
                                    Console.Clear();
                                }
                                break;
                        }
                    }
                }
            }
        }
    }
}

   