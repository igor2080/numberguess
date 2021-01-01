using System;
using System.Collections.Generic;
using System.Text;

namespace NumberGuess
{
    public class GuessNumber
    {
        private const int MinNumber = 0, MaxNumber = 100, InvalidNumber = -1;
        private int _number = InvalidNumber;
        public bool IsGameStarted { get { return _number != InvalidNumber; } }

        public int GenerateNewNumber()
        {
            return _number = new Random().Next(MinNumber, MaxNumber + 1);
        }

        public GuessResult GetGuessResult(int userGuessNumber)
        {
            if (_number == InvalidNumber)
                throw new InvalidOperationException("A game has not been started.");
            if (userGuessNumber < MinNumber || userGuessNumber > MaxNumber)
                throw new ArgumentOutOfRangeException($"A number has to be between {MinNumber} and {MaxNumber}");

            if (userGuessNumber > _number)
            {
                return GuessResult.Lower;
            }
            else if (userGuessNumber < _number)
            {
                return GuessResult.Higher;
            }

            _number = InvalidNumber;
            return GuessResult.Correct;
        }
    }
}
