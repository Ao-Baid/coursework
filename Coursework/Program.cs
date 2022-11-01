using System;
using System.Text;

namespace CSharpTutorials
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("1: Arithmetic Challenge\n2: Square Root calcualtor\n3: Ceaser Cipher Encrypter");
            Console.WriteLine("What is the option you wish to access: ");
            int option = int.Parse(Console.ReadLine());

            switch (option) //number that is written by user will dictate which miniapp is called
            {
                case 1:
                    Arithmetic();
                    break;

                case 2:
                    SquareRootCalculator();
                    break;

                case 3:
                    CeaserEncrypt();
                    break;

                case 4:
                    CeaserDecrypt();
                    break;
            }

        }

        static void Wipe()
        {
            //bool exit = true;
            //while (exit)
            //{
            //    if(Console.ReadKey() = ConsoleKey.Escape)
            //    {

            //    }
            //}
        }

        static void Arithmetic()
        {
            Random rnd = new Random();
            int problemCount = 0;
            bool valid = false;
            int check;
            var userAnswer = "";

            do // Constalty produce problems for the user until a total of 10 problems are answered
            {
                int valueOne = rnd.Next(1, 11);
                int valueTwo = rnd.Next(1, 11);
                int operatorRnd = rnd.Next(0, 2);
                int actualAnswer;





                // if(int.Parse(userAnswer) != actualAnswer)
                // {
                //     Console.WriteLine("Incorrect!");
                //     problemCount++;
                //     Console.WriteLine(problemCount);
                // }
                // else
                // {
                //     problemCount++;
                //     continue;
                // }

                switch (operatorRnd)
                {
                    case 0:
                        Console.WriteLine("What is " + valueOne + " + " + valueTwo);
                        userAnswer = Console.ReadLine();
                        actualAnswer = valueOne + valueTwo;
                        if (int.Parse(userAnswer) != actualAnswer)
                        {
                            Console.WriteLine("Incorrect!");
                            problemCount++;
                            break;
                        }
                        else
                        {
                            problemCount++;
                            Console.WriteLine(operatorRnd);

                            break;
                        }

                    case 1:
                        Console.WriteLine("What is " + valueOne + " - " + valueTwo);
                        userAnswer = Console.ReadLine();
                        actualAnswer = valueOne - valueTwo;
                        if (int.Parse(userAnswer) != actualAnswer)
                        {
                            Console.WriteLine("Incorrect!");
                            Console.WriteLine(operatorRnd);
                            problemCount++;
                            break;
                        }
                        else
                        {
                            problemCount++;
                            Console.WriteLine(operatorRnd);

                            break;
                        }
                    default:
                        Console.WriteLine(operatorRnd);
                        break;

                }

            } while (problemCount <= 10);
        }

        static void SquareRootCalculator()
        {
            Console.Clear();
            Console.WriteLine("What is the number you want to square root? ");
            double squareRootNumber = double.Parse(Console.ReadLine());

            Console.WriteLine("To what precision do you want the square root to be done to? ");
            int precision = int.Parse(Console.ReadLine());


            double accuracy = Math.Pow(10.0, -precision);   //by raising the precison to the exponent with a base of 10, we can decide how many 0's

            double lowerBound = 0;
            double upperBound = squareRootNumber;
            double average = 0;


            while ((upperBound - lowerBound) > accuracy) //continously loop and change the upper and lower bound until the difference between the two is less tahn the accuracy
            {
                average = (upperBound + lowerBound) / 2;

                if ((average*average) > squareRootNumber)
                {
                    upperBound = average;
                }
                else
                {
                    lowerBound = average;
                }

                

            }

            Console.WriteLine("The square root of {0} to {1} decimal places is {2}\n", squareRootNumber, precision, Math.Round(average, precision));
            Console.WriteLine("Press any key to return to the main menu\n");
            Console.ReadKey();
            Console.Clear();
            Main();

        }

        static void CeaserEncrypt()
        {
            string Alphabet = "abcdefghijklmnopqrstuvwxyz";
            char[] alphaChars = Alphabet.ToCharArray();

            Console.WriteLine("What is your shift?");
            int shift = int.Parse(Console.ReadLine());

            Console.WriteLine("Write your message to be encrypted: ");
            string userMessage = Console.ReadLine();
            char[] userCharacters = userMessage.ToCharArray();

            StringBuilder encryptedMessage = new StringBuilder();
            for(int i = 0; i < userCharacters.Length;i++)
            {
                char letter = userMessage[i];
                letter = (char)(letter + shift);
                if (letter > 'z')
                {
                    letter = (char)(letter - 26);
                }
                else if (letter < 'a')
                {
                    letter = (char)(letter + 26);
                }

                encryptedMessage.Append(letter);

            }
            Console.WriteLine(encryptedMessage);
            Console.ReadKey();



            //for(int i = 0; i < userMessage.Length; i++)

            //{
            //    userMessage[i] =  
            //}
        }

        static void CeaserDecrypt()
        {

        }
    }
}