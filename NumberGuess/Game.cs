using System;
using System.Collections.Generic;
using System.Text;

namespace NumberGuess
{
    public enum GuessResult
    {
        None,
        Lower,
        Correct,
        Higher,        
    }
    public class Game
    {
        private GuessNumber _guessNumber = new GuessNumber();

        public GuessResult MakeGuess(int userNumber)
        {
            GuessResult result;
            try
            {
                result = _guessNumber.GetGuessResult(userNumber);
            }
            catch(ArgumentOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
                result = GuessResult.None;
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
                result = GuessResult.None;
            }
            return result;
        }

        public void StartNewGame()
        {
            _guessNumber.GenerateNewNumber();
        }
    }
}
