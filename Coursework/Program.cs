using System;
using System.Text;

namespace CSharpTutorials
{
    class Program
    {
        public static void returnToMainMenu()
        {
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
            Console.Clear();
            Main();
        }

        public static void Main()
        {
            Console.WriteLine("1: Arithmetic Challenge\n2: Square Root calcualtor\n3: Ceaser Cipher Encrypter\n4: Ceaser Decrypter\n5: Exit");
            Console.WriteLine("What is the option you wish to access: ");
            int option = integerValidation();
            while (option <= 0 || option > 5)
            {
                Console.WriteLine("Write a suitable menu option!");
                option = integerValidation();
            }

            switch (option) //number that is written by user will dictate which miniapp is called
            {
                case 1:
                    Arithmetic();
                    break;

                case 2:
                    SquareRootCalculator();
                    break;

                case 3:
                    CeaserEncrypt("encrypted");
                    break;

                case 4:
                    CeaserEncrypt("decrypted"); //the decrypt program is actually within the Ceaser encrypt function however only runs when we pass the "decrypt" parameter
                    break;

                case 5:
                    return; //by using return on a functuon that is "void", it will terminate the main method thus terminating the program
            }

        }

        public static int integerValidation() //method to ensure that inputs requiring integers are satisfied with that condition
        {
            int temp;
            string input = Console.ReadLine(); //the function itself will require user put an input
            while (!Int32.TryParse(input, out temp)) //continously asks for integer data type through user input
            {
                Console.WriteLine("Enter an integer not a character(s)! ");
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
            Console.Clear();
            Random rnd = new Random();
            int problemCount = 0;
            int correctAnswer = 0;
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
                        if (integerValidation() != actualAnswer)
                        {
                            Console.WriteLine("Incorrect! Answer is {0}", actualAnswer);
                            problemCount++;
                            break;
                        }
                        else
                        {
                            problemCount++;
                            break;
                        }

                    case 1:
                        Console.WriteLine("What is " + valueOne + " - " + valueTwo);
                        actualAnswer = valueOne - valueTwo;
                        if (integerValidation() != actualAnswer)
                        {
                            Console.WriteLine("Incorrect! Answer is {0}", actualAnswer);
                            problemCount++;
                            break;
                        }
                        else
                        {
                            problemCount++;
                            correctAnswer++;
                            break;
                        }
                    default:
                        Console.WriteLine(operatorRnd);
                        break;

                }

            } while (problemCount <= 10);

            Console.WriteLine("You have gotten {0} out of 10 questions correct\n", correctAnswer);
            returnToMainMenu();
        }

        public static void SquareRootCalculator()
        {

            Console.Clear();
            Console.WriteLine("What is the number you want to square root? ");

            /*since the input validation function needs a string, to avoid repeated console.ReadLine(), 
              we can create a tempororay string variable to pass as a parameter and the value returned
              is put into both variables below */

            int squareRootNumber = integerValidation();
            while (squareRootNumber < 0)
            {
                Console.WriteLine("This is not a valid inpu, write a positive number!");
                squareRootNumber = integerValidation();
            }

            Console.WriteLine("To what precision do you want the square root to be done to? ");
            int precision = integerValidation();
            while (precision < 0 || precision > 6)
            {
                Console.WriteLine("Write an appropraite precision between 1 and 6");
                precision = integerValidation();

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
            returnToMainMenu();


        }

        public static void CeaserEncrypt(string encryptOrDecrypt)
        {
            Console.Clear();
            //a string that contains all alphabet letters and numbers 0 to 9 and space are written and then converted to a char array
            string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ";
            char[] alphaChars = Alphabet.ToCharArray();
            

            //user inputs their shift as an integer
            int shift;

            //user inputs the messsage they want encrypted. This message is then converted from a string to a char array containing each individual character
            string userMessage;
            char[] userCharacters;

            Console.WriteLine("Write your message to be {0}: ", encryptOrDecrypt); //we concatenate the write line with the value of the parameter to remind the user whether they are encrypting or decryoting

            do
            {
                userMessage = Console.ReadLine();
                userMessage = userMessage.ToUpper();
                if((userMessage.IndexOfAny(alphaChars) != 0))
                {
                    Console.WriteLine("There are invalid characters in your string!");
                }

            } while (userMessage.IndexOfAny(alphaChars) != 0);
            userCharacters = userMessage.ToCharArray();


            Console.WriteLine("What is your shift?");
            do
            {
                shift = integerValidation();
            } while (shift < 0 || shift > 36);

            for (int i = 0; i < userCharacters.Length; i++) //iterating until we reach the number of charaacters in the users input
            {
                char letter = userMessage[i];
                int letterIndex = Array.IndexOf(alphaChars, letter);
                if(encryptOrDecrypt == "encrypted")
                {
                   int newLetterPos = (((letterIndex + shift) % 37 + 37) % 37);
                   char newLetter = alphaChars[newLetterPos];
                   userCharacters[i] = newLetter;
                }
                else //if the parameter is anything else (only other possibility is "decrypt", we move towards a decryption scenario
                {
                    int newLetterPos = (((letterIndex - shift) % 37 + 37) % 37);
                    char newLetter = alphaChars[newLetterPos];
                    userCharacters[i] = newLetter;
                }

            }
            string newMessage = String.Join("", userCharacters);
            Console.WriteLine("Your encrypted text is " + newMessage);
            returnToMainMenu();
            
 
            }
            
        }


    }
