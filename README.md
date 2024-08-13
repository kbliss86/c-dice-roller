# Dice Roller

## Objective:
Simulate dice rolling with random numbers.

## Task:
Create an application that simulates dice rolling with user-defined dice sizes.

## What the Application Will Do:
1. The application prompts the user to enter the number of sides for a pair of dice.
   - If you've learned about exception handling, ensure that the user can only enter valid numbers.
2. The application prompts the user to roll the dice.
3. The application "rolls" two n-sided dice and displays the results of each along with the total.
4. For 6-sided dice, the application recognizes the following combinations and displays corresponding messages:
   - **Snake Eyes**: Two 1s
   - **Ace Deuce**: A 1 and 2
   - **Box Cars**: Two 6s
   - **Win**: A total of 7 or 11
   - **Craps**: A total of 2, 3, or 12
5. The application asks the user if they would like to roll the dice again.

## Build Specifications:
- **Random Number Generation**:
  - Create a static method to generate random numbers.
  - Ensure the method header is correct and that the method returns a meaningful value within the user-specified range.
- **Dice Combination Checks**:
  - Create a static method for six-sided dice that takes two dice values as parameters.
  - This method should return a string for one of the valid combinations (e.g., Snake Eyes) or an empty string if there’s no match.
- **Dice Total Checks**:
  - Create another static method for six-sided dice that also takes two dice values as parameters.
  - This method should return a string for one of the valid totals (e.g., Win) or an empty string if there’s no match.
- Ensure the application correctly handles all user input and loops properly.

## Hints:
- Use the `Random` class to generate random numbers.

## Extra Challenges:
- Design a set of winning combinations for other dice sizes beyond 6-sided dice.
