using System;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;

namespace c_dice_roller
{
    internal class Program
    {
        static void Main(string[] args)
        /*
Dice Roller

Objective:
Simulate dice rolling with random numbers.

Task:
Create an application that simulates dice rolling with user-defined dice sizes.
*/

        /*
        What the Application Will Do:
        1. The application prompts the user to enter the number of sides for a pair of dice.
           - If you've learned about exception handling, ensure that the user can only enter valid numbers.
        2. The application prompts the user to roll the dice.
        3. The application "rolls" two n-sided dice and displays the results of each along with the total.
        4. For 6-sided dice, the application recognizes the following combinations and displays corresponding messages:
           - Snake Eyes: Two 1s
           - Ace Deuce: A 1 and 2
           - Box Cars: Two 6s
           - Win: A total of 7 or 11
           - Craps: A total of 2, 3, or 12
        5. The application asks the user if they would like to roll the dice again.
        */

        /*
        Build Specifications:
        - Random Number Generation:
          - Create a static method to generate random numbers.
          - Ensure the method header is correct and that the method returns a meaningful value within the user-specified range.
        - Dice Combination Checks:
          - Create a static method for six-sided dice that takes two dice values as parameters.
          - This method should return a string for one of the valid combinations (e.g., Snake Eyes) or an empty string if there’s no match.
        - Dice Total Checks:
          - Create another static method for six-sided dice that also takes two dice values as parameters.
          - This method should return a string for one of the valid totals (e.g., Win) or an empty string if there’s no match.
        - Ensure the application correctly handles all user input and loops properly.
        */

        /*
        Hints:
        Use the Random class to generate random numbers.
        */

        /*
        Extra Challenges:
        Design a set of winning combinations for other dice sizes beyond 6-sided dice.
        */

        {
            Console.WriteLine("Welcome to the Dice Roller!");
            Console.WriteLine("Reach into my magical dice box and grab a die, any die! How many sides does it have? (Standard Dice have 4 6, 8, 10, 12, 20 sides)");
            int dieSides = int.Parse(Console.ReadLine());

            //Verify user entered a valid number
            //According to internet There’s really no upper limit to the number of faces you can have on a die (as long as it’s even), but the most common are 4, 6, 8, 10, 12, and 20.
            while (dieSides % 2 != 0 || dieSides < 3 || dieSides > 21)
            {
                //Instructs user to enter a valid number of sides for the die
                Console.WriteLine("Please enter a valid number of sides for the die (4, 6, 8, 10, 12, or 20).");
                dieSides = int.Parse(Console.ReadLine());
            }
            //User can roll the dice multiple times, variable set up for while loop
            bool rollAgain = true;
            //While loop for rolling the dice multiple times
            while (rollAgain)//while true, roll again!
            {

                //Repeats the user input for the die sides and rolls the dice
                Console.WriteLine($"Great! You have a {dieSides}-sided die. Let's roll it!");
                RollDice(dieSides);
                //Ask user if they would like to roll again
                Console.WriteLine("Would you like to roll again? (y/n)");
                //Verify user entered a valid response
                string rollAgainInput = Console.ReadLine().ToLower();
                //Extra Credit - Verify user entered a valid response
                while (rollAgainInput != "y" && rollAgainInput != "n")
                {
                    //Instructs user to enter a valid repsonse
                    Console.WriteLine("Please enter a valid response (y/n).");
                    rollAgainInput = Console.ReadLine().ToLower();
                }
                //If user enters "n" the loop will end
                if (rollAgainInput == "n")
                {
                    rollAgain = false;
                }
                //If user enters "y" the loop will continue
                else
                {
                    //Instructs user to press enter to roll again
                    Console.WriteLine("Press Enter to roll again!");
                    rollAgain = true;
                }
                //Stops the console from closing after the user enters "n"
                Console.ReadLine();
            }

        }

        //Method for Rolling Dice
        static void RollDice(int dieSides)
        {
            Random random = new Random();
            int roll1 = random.Next(1, dieSides + 1);
            int roll2 = random.Next(1, dieSides + 1);


            Console.WriteLine($"You rolled a {roll1 + roll2} !");
            String result = CheckDiceCombo(roll1, roll2, dieSides);

            Console.WriteLine($"That's a {result} result!");
        }



        //Method for Dice Combinations and Dice Totals
        static string CheckDiceCombo(int roll1, int roll2, int dieSides)
        {
            int diceTotal = roll1 + roll2;
            string diceResult = "";

            //If Statements for Dice Combinations - Instead of Creating 2 Methods for Dice Combinations and Dice Totals, I combined them into one method for code efficiency
            //Extra Credit - Snake Eyes/ Low Blow: Two 1s

            if (roll1 == 1 && roll2 == 1)
            {
                diceResult = "Snake Eyes";
            }

            //Ace Deuce: A 1 and 2

            else if (roll1 == 1 && roll2 == 2 || roll1 == 2 && roll2 == 1)
            {
                diceResult = "Ace Deuce";
            }

            //Win: A total of 7 or 11

            else if (diceTotal == 7 || diceTotal == 11)
            {
                diceResult = "Win";
            }

            //Craps: A total of 2, 3, or 12

            else if (diceTotal == 2 || diceTotal == 3 || diceTotal == 12)
            {
                diceResult = "Craps";
            }

            //Hard 8 : A total of 8

            else if (diceTotal == 8)
            {
                diceResult = "Hard 8";
            }

            //Dirty Dozen: A total of 12 unless it's a 6 on both dice

            else if (diceTotal == 12 && roll1 != 6 && roll2 != 6)
            {
                diceResult = "Dirty Dozen";
            }

            //Doubles: Two of the same number

            else if (roll1 == roll2)
            {
                diceResult = "Doubles";
            }

            //Box Cars: Two 6s

            else if (roll1 == 6 && roll2 == 6)
            {
                diceResult = "Box Cars";
            }

            // Extra Credit - Max Out: Rolling the 2 highest numbers on a given die (e.g., 20 on a 20-sided die) unless its a 6 on both dice

            else if (roll1 == dieSides && roll2 == dieSides && roll1 != 6 && roll2 != 6 )
            {
                diceResult = "Max Out, In Dungeons and Dragons this is also knows as a Critical Hit";
            }

            //Empty string if there’s no match

            return string.IsNullOrEmpty(diceResult) ? "No Match" : diceResult;
        }  

    }
}
