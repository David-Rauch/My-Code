using System;

namespace StringReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            string animal = "The        cat went meow";
            Console.WriteLine(animal +"\n");
            ReverseWithTabs(animal);
        }
        public static void ReverseWithTabs(string str)
        {
            char[] inputArray = str.ToCharArray();
            char[] result = new char[inputArray.Length];
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == ' ')
                {
                    result[i] = ' ';
                }
            }
            int j = result.Length - 1;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] != ' ')
                {
                    if (result[j] == ' ')
                    {
                        j--;
                        i--;
                    }
                    else 
                    {
                        result[j] = inputArray[i];
                        j--;
                    }
                }
            }
            for (int i = 0; i < result.Length; i++)
                Console.Write(result[i]);
            Console.ReadLine();
        }
    }
        
}

