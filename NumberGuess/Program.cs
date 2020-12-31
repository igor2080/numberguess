using System;

namespace NumberGuess
{
    public class Program
    {
        private readonly Game _guessGame = new Game();
        private int _userGuess = -1;
        const string RestartKey = "1";
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        private void Start()
        {            
            do
            {
                _guessGame.StartNewGame();
                GuessResult currentResult = GuessResult.None;
                while (currentResult != GuessResult.Correct)
                {
                    
                    Console.WriteLine("Please enter a number between 0 and 100: ");
                    _userGuess = GetUserInput();
                    currentResult = _guessGame.MakeGuess(_userGuess);
                    PrintResponse(currentResult);
                }
            }
            while (PromptPlayAgain());
        }

        private bool PromptPlayAgain()
        {
            Console.WriteLine("Would you like to play again? type 1 to make a new game or press ctrl+c to exit:");
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

        private int GetUserInput()
        {
            string input = Console.ReadLine();
            int result = -1;
            while (!int.TryParse(input, out result) || result < 0 || result > 100)
            {
                Console.WriteLine("Please enter a valid number between 0 and 100 or press ctrl+c to exit: ");
                input = Console.ReadLine();
            }
            return result;
        }
    }
}
