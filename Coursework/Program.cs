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

        public static int integerValidation(string input) //method to ensure that inputs requiring integers are satisfied with that condition
        {
            int temp;
            input = Console.ReadLine(); //the function itself will require user put an input
            while (!Int32.TryParse(input, out temp))
            {
                Console.WriteLine("Bad integer");
                input = Console.ReadLine();
                if (Int32.TryParse(input, out temp))
                {
                    temp = int.Parse(input);
                }
            }
            return temp; //if the input is an integer, temp is returned into the variable or condition it was called in




        }

        public static void Arithmetic()
        {
            Random rnd = new Random();
            int problemCount = 0;
            int correctAnswer = 0;
            string userAnswer = "";
            int actualAnswer;

            do // Constalty produce problems for the user until a total of 10 problems are answered
            {
                int valueOne = rnd.Next(1, 11);
                int valueTwo = rnd.Next(1, 11);
                int operatorRnd = rnd.Next(0, 2);

                switch (operatorRnd) //switch statement will result in different actualAnswers and outputs to user for if the arithmetic operation is + or -
                {
                    case 0:
                        Console.WriteLine("What is " + valueOne + " + " + valueTwo);
                        actualAnswer = valueOne + valueTwo;
                        if (integerValidation(userAnswer) != actualAnswer)
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
                        actualAnswer = valueOne - valueTwo;
                        if (integerValidation(userAnswer) != actualAnswer)
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
                            correctAnswer++;


                            break;
                        }
                    default:
                        Console.WriteLine(operatorRnd);
                        break;

                }

            } while (problemCount <= 10);

            Console.WriteLine("You have gotten {0} out of 10 questions correct\n", correctAnswer);
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
            Console.Clear();
            Main();
        }

        static void SquareRootCalculator()
        {

            Console.Clear();
            Console.WriteLine("What is the number you want to square root? ");
            string tempeorary = "";

            /*since the input validation function needs a string, to avoid repeated console.ReadLine(), 
              we can create a tempororay string variable to pass as a parameter and the value returned
              is put into both variables below */



            int squareRootNumber = integerValidation(tempeorary);
            while(squareRootNumber < 0)
            {
                Console.WriteLine("This is not a valid inpu, write a positive number!");
                squareRootNumber = integerValidation(tempeorary);
            }

            Console.WriteLine("To what precision do you want the square root to be done to? ");
            int precision = integerValidation(tempeorary);
            while(precision < 0 || precision > 6)
            {
                Console.WriteLine("Write an appropraite precision between 1 and 6");
                precision = integerValidation(tempeorary);

            }


            double accuracy = Math.Pow(10.0, -precision);   //by raising the precison to the exponent with a base of 10, we can decide how many 0's

            double lowerBound = 0;
            double upperBound = squareRootNumber;
            double average = 0;


            while ((upperBound - lowerBound) > accuracy) //continously loop and change the upper and lower bound until the difference between the two is less tahn the accuracy
            {
                average = (upperBound + lowerBound) / 2;

                if ((average * average) > squareRootNumber)
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
            //a string that contains all alphabet letters and numbers 0 to 9 and space are written and then converted to a char array
            string Alphabet = "abcdefghijklmnopqrstuvwxyz123456789 ";
            char[] alphaChars = Alphabet.ToCharArray();

            //user inputs their shift as an integer
            Console.WriteLine("What is your shift?");
            int shift = int.Parse(Console.ReadLine());


            //user inputs the messsage they want encrypted. This message is then converted from a string to a char array containing each individual character
            Console.WriteLine("Write your message to be encrypted: ");
            string userMessage = Console.ReadLine();
            char[] userCharacters = userMessage.ToCharArray();

            StringBuilder encryptedMessage = new StringBuilder(); //This is an object included in c# that allows for the manipulation of strings which involves the creation of them as seen below

            for (int i = 0; i < userCharacters.Length; i++) //iterating until we reach the number of charaacters in the users input
            {
                //char letter = userMessage[i];
                //letter = (char)(letter + shift);
                //if (letter > 'z')
                //{
                //    letter = (char)(letter - 26);
                //}
                //else if (letter < 'a')
                //{
                //    letter = (char)(letter + 26);
                //}

                //encryptedMessage.Append(letter);

                char letter = userMessage[i];
                int letterIndex = Array.IndexOf(alphaChars, letter);
                int newLetterPos = (((letterIndex + shift) % alphaChars.Length + alphaChars.Length) % alphaChars.Length);
                char newLetter = alphaChars[newLetterPos];
                userCharacters[i] = newLetter;



            }
            encryptedMessage.Append(userCharacters);
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