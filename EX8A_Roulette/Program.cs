using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;

namespace EX8A_Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            Random ran = new Random();
            var r = new Random();
            string[] color = { "Red", "Black" };
            string guess;
            int exact = 0, numOne = 0, numTwo = 0, cornerOne = 0, cornerTwo = 0, cornerThree = 0, cornerFour = 0;
            int rowOne = 0, rowTwo = 0, days = 5, interest = 25;
            int bet;
            int money = 500;
            while (money != 0)
            {
                Console.WriteLine("Money:$" + money);
                Console.WriteLine("\nType in any off the following letters below:\n");
                Console.WriteLine("a.Even    b.Odd    c.1 to 18    d.19 to 36");
                Console.WriteLine("e.Red     f.Black  g.1st 12     h.2nd 12");
                Console.WriteLine("i.3rd 12  j.Exact  k.Split      l.Corner\nm.DoubleRow\n");
                guess = (Console.ReadLine());
                guess.ToLower();
                if (guess == "j")
                {
                    Console.Write("\nEnter the number: ");
                    exact = int.Parse(Console.ReadLine());
                }
                if (guess == "k")
                {
                    Console.Write("\nSPLIT: Enter the first number touching: ");
                    numOne = int.Parse(Console.ReadLine());
                    Console.Write("\nSPLIT: Enter the second number touching: ");
                    numTwo = int.Parse(Console.ReadLine());
                }
                if (guess == "l")
                {
                    Console.Write("\nCORNER: Enter the first number touching: ");
                    cornerOne = int.Parse(Console.ReadLine());
                    Console.Write("\nCORNER: Enter the second number touching: ");
                    cornerTwo = int.Parse(Console.ReadLine());
                    Console.Write("\nCORNER: Enter the third number touching: ");
                    cornerThree = int.Parse(Console.ReadLine());
                    Console.Write("\nCORNER: Enter the fourth number touching: ");
                    cornerFour = int.Parse(Console.ReadLine());
                }
                if (guess == "m")
                {
                    Console.Write("\nDOUBLE ROW: Enter first number of first row: ");
                    rowOne = int.Parse(Console.ReadLine());
                    Console.Write("\nDOUBLE ROW: Enter first number of second row: ");
                    rowTwo = int.Parse(Console.ReadLine());
                }

                bool check = guess == "a" || guess == "b" || guess == "c" || guess == "d" || guess == "e" || guess == "f" || guess == "g" || guess == "h" || guess == "i" || guess == "j" || guess == "k" || guess == "l" || guess == "m";
                if (check == false)
                {
                    Console.WriteLine("You did not enter the correct input value(even/odd)");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                else
                {
                bet:
                    Console.Write("Enter an amount to bet");
                    bet = Convert.ToInt32(Console.ReadLine());
                    //bet verifier
                    if (bet > money)
                    {
                        Console.WriteLine("You dont have enough money!");
                        Console.WriteLine("Press enter to try again.");
                        Console.ReadLine();
                        goto bet;
                    }
                    else
                    {
                        money -= bet;
                        int roll = ran.Next(0, 37);
                        string ranColor = color[r.Next(color.Length)];
                        bool even = roll % 2 == 0;
                        if ((((guess == "a") && (even == true))) || (((guess == "b") && (even == false))) || ((guess == "e") && (ranColor == "Red") || (guess == "f") && (ranColor == "Black")))
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You won! +$" + bet * 2 + "!");
                            Console.WriteLine("<Press enter to continue>");
                            money += bet * 3;
                            Console.ReadLine();
                        }
                        else if ((guess == "c") && ((roll > 0) && (roll < 19)) || (guess == "d") && ((roll > 18) && (roll < 37)))
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You won! +$" + bet * 2 + "!");
                            Console.WriteLine("<Press enter to continue>");
                            money += bet * 3;
                            Console.ReadLine();
                        }
                        else if ((guess == "g") && (roll > 0 && roll < 13) || (guess == "h") && (roll > 12 && roll < 25) || (guess == "i") && (roll > 24 && roll < 37))
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You won! +$" + bet * 2 + "!");
                            Console.WriteLine("<Press enter to continue>");
                            money += bet * 3;
                            Console.ReadLine();
                        }
                        else if ((guess == "j") && (roll == exact))
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You won! +$" + bet * 35 + "!");
                            Console.WriteLine("<Press enter to continue>");
                            money += bet * 36;
                            Console.ReadLine();
                        }
                        else if ((guess == "k") && (roll == numOne || roll == numTwo))
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You won! +$" + bet * 17 + "!");
                            Console.WriteLine("<Press enter to continue>");
                            money += bet * 18;
                            Console.ReadLine();
                        }
                        else if ((guess == "l") && (roll == cornerOne || roll == cornerTwo || roll == cornerThree || roll == cornerFour))
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You won! +$" + bet * 8 + "!");
                            Console.WriteLine("<Press enter to continue>");
                            money += bet * 9;
                            Console.ReadLine();
                        }
                        else if ((guess == "m") && (roll == rowOne || roll == rowTwo))
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You won! +$" + bet * 5 + "!");
                            Console.WriteLine("<Press enter to continue>");
                            money += bet * 6;
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You lost! -$" + bet + "!");
                            Console.WriteLine("<Press enter to continue>");
                            Console.ReadLine();
                            if (money == 0)
                            {
                                Console.WriteLine("You are out of money.");
                                Console.WriteLine("Do you want a loan from Vinny? (Y/N)");
                                string answer = Console.ReadLine();
                                answer.ToUpper();
                                if (answer == "Y")
                                {
                                    if (days > 0)
                                    {
                                        money = 500;
                                        Console.WriteLine($"\n\nVinny gives you {days} days to pay him back @ {interest}% interest - good luck!");
                                        Console.ReadLine();
                                        interest += 10;
                                        days--;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Vinny took you for a ride out to the desert and showed you his new baseball bat\n\nGAME OVER!");
                                        Console.ReadLine();
                                    }
                                }
                            }
                        }
                    }
                }
                Console.Clear();
            }
        }
    }
}