using System;
using System.Collections.Generic;
using System.Text;

namespace NumberGuess
{
    public class Game
    {
        private const int MinNumber = 0, MaxNumber = 100;
        const string RestartKey = "1";
        private readonly GuessNumber _guessNumber = new GuessNumber();

        public Game()
        {

        }
        public Game(GuessNumber number)
        {
            _guessNumber = number;
        }

        public int StartNewGame()
        {
            return _guessNumber.GenerateNewNumber();
        }

        public void Play()
        {
            do
            {
                StartNewGame();
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

        public GuessResult MakeGuess()
        {
            int userNumber = GetUserInput();

            if (_guessNumber.IsGameStarted)
            {
                return _guessNumber.GetGuessResult(userNumber);
            }

            throw new InvalidOperationException("A game has not been started.");
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
                    Console.WriteLine("Your guess was too low.");
                    break;
                case GuessResult.Lower:
                    Console.WriteLine("Your guess was too high.");
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
