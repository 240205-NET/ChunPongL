using System;

namespace GuessingGame
{
    public class GG
    {
        public static void Main(String[] args)
        {
                        // Greet the player!
            Console.WriteLine("Welcome to the Guessing Game!");

            // randomly generated number (for the player to try to guess)
            //var rand = new Random();
            Random rand = new Random();
            // uint (unsigned int) 0 to 2 Bill
            // int (signed int) -1 Bill to 1 Bill
            int target = rand.Next(21); // generate in integer value between 0 and 20

            // remove for production!
            Console.WriteLine(target);

            // somthing to rememeber if the player has won
            // boolean value to represent the yes or no
            bool win = false;
            // create an attemption variable
            int i = 0; 

            //loop to keep guessing until the player guesses the correct number
            while(!win) // C# comparison operators: ==, > , <, >=, <= , !=
            {
                //accept player guess
                Console.WriteLine("Please guess a number between 0 and 20: ");
                // accept user input as a string , convert it , and store it in a numberical variable
                int guess = -1;
                try
                {
                    guess = Int32.Parse(Console.ReadLine());
                    // check if the guess value is still the default , or if the player guess was valid
                    if(guess >= 0 && guess <= 20)
                    {
                        // check if the player has guessed the correct nubmer
                        // if they're correct, tell them they've won!
                        if (guess == target )
                        {
                            Console.WriteLine("ayoo! Yay! Congratulations, you got it right!");
                            win  = true;
                        }
                        // if they're wrong , prompt them to guess again
                        // if too high
                        else if (guess > target)
                        {
                            Console.WriteLine("Whoops, too high!");
                        }
                        // if too low
                        else
                        {
                            Console.WriteLine("Nope, too low!");
                        }
                        i++;
                        Console.WriteLine("Attemp #: "+ i);
                        // break out of the loop
                    }
                    else
                    {
                        Console.WriteLine("Your guess was out of range, please try again.");
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("The value you entered was not valid, please try again.");
                }

            }
                
            Console.WriteLine("Congratulations, you've won! It took you " + i + " attempts!");
            // prompt to play again
                // if no ,exit the program
                // if yes, play again
        }
    }
}


