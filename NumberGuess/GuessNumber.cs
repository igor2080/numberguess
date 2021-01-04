using System;
using System.Collections.Generic;
using System.Text;

namespace NumberGuess
{
    public class GuessNumber
    {
        private readonly int _minNumber, _maxNumber;
        private int _number = -1;

        public GuessNumber(int minimum, int maximum)
        {
            if (minimum > maximum)
            {
                throw new ArgumentException("Minimum cannot be higher than maximum.");
            }

            _minNumber = minimum;
            _maxNumber = maximum;
        }

        public int GenerateNewNumber()
        {
            return _number = new Random().Next(_minNumber, _maxNumber + 1);
        }

        public virtual GuessResult GetGuessResult(int userGuessNumber)
        {
            if (_number == -1)
                throw new InvalidOperationException("A game has not been started.");
            
            if (userGuessNumber > _number)
            {
                return GuessResult.Lower;
            }
            else if (userGuessNumber < _number)
            {
                return GuessResult.Higher;
            }

            _number = -1;
            return GuessResult.Correct;
        }
    }
}
