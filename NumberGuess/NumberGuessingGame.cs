using System;
using System.Collections.Generic;
using System.Text;

namespace NumberGuess
{
    public class NumberGuessingGame
    {
        private const int MinNumber = 1, MaxNumber = 101;
        private const string RestartKey = "1";
        private readonly GuessNumber _guessNumber;

        public NumberGuessingGame()
        {
            _guessNumber = new GuessNumber(MinNumber, MaxNumber);
        }
        public NumberGuessingGame(GuessNumber number)
        {
            if (number == null)
            {
                throw new ArgumentNullException(nameof(number), $"{number} cannot be null");
            }

            _guessNumber = number;
        }

        public void Play()
        {
            do
            {
                _guessNumber.GenerateNewNumber();
                GuessResult currentResult = GuessResult.None;
                while (currentResult != GuessResult.Correct)
                {
                    Console.WriteLine($"Please enter a number between {MinNumber} and {MaxNumber}: ");
                    currentResult = MakeGuess();
                    PrintResponse(currentResult);
                }
            }
            while (PromptPlayAgain());
        }

        private GuessResult MakeGuess()
        {
            return _guessNumber.GetGuessResult(GetUserInput());
        }

        private int GetUserInput()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || result < MinNumber || result > MaxNumber)
            {
                Console.WriteLine($"Please enter a valid number between {MinNumber} and {MaxNumber} or press ctrl+c to exit: ");
            }
            return result;
        }

        private bool PromptPlayAgain()
        {
            Console.WriteLine($"Would you like to play again? type {RestartKey} to make a new game or press ctrl+c to exit:");
            return Console.ReadLine() == RestartKey;
        }

        private void PrintResponse(GuessResult currentResult)
        {
            switch (currentResult)
            {
                case GuessResult.Higher:
                    Console.WriteLine("Your guess was too low, try guessing again.");
                    break;
                case GuessResult.Lower:
                    Console.WriteLine("Your guess was too high, try guessing again.");
                    break;
                case GuessResult.Correct:
                    Console.WriteLine("You guessed correctly!");
                    break;
                default:
                    break;
            }
        }
    }
}
