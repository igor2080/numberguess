using System;
using System.Collections.Generic;
using System.Text;

namespace NumberGuess
{
    public class GuessNumber
    {
        private int Number = -1;

        public void GenerateNewNumber()
        {
            Number = new Random().Next(0, 101);
        }

        public GuessResult GetGuessResult(int userGuessNumber)
        {
            if (Number == -1)
                throw new InvalidOperationException("A game has not been started.");
            if (userGuessNumber < 0 || userGuessNumber > 100)
                throw new ArgumentOutOfRangeException("A number has to be between 0 and 100");

            if (userGuessNumber > Number)
            {
                return GuessResult.Lower;
            }
            else if (userGuessNumber < Number)
            {
                return GuessResult.Higher;
            }
            else
            {
                Number = -1;
                return GuessResult.Correct;
            }
        }
    }
}
