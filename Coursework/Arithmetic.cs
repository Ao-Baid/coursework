using System;
namespace Coursework
{
    public class Arithmetic
    {
        public Arithmetic()
        {
            Random rnd = new Random();
            int problemCount = 10;

            while (problemCount <= 10)
            {
                int valueOne = rnd.Next(1, 10);
                int valueTwo = rnd.Next(1, 10);
                int actualAnswer = valueOne + valueTwo;



                Console.WriteLine("What is " + valueOne + " + " + valueTwo);
                int userAnswer = int.Parse(Console.ReadLine());


                if (userAnswer != actualAnswer)
                {
                    Console.WriteLine("Incorrect!");
                }
                else
                {
                    continue;
                }

             

            }

        }
    }
}

