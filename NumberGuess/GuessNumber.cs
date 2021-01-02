﻿using System;
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
            _minNumber = minimum;
            _maxNumber = maximum;
        }

        public int GenerateNewNumber()
        {
            return _number = new Random().Next(_minNumber, _maxNumber + 1);
        }

        public GuessResult GetGuessResult(int userGuessNumber)
        {
            if (_number == -1)
                throw new InvalidOperationException("A game has not been started.");
            if (userGuessNumber < _minNumber || userGuessNumber > _maxNumber)
                throw new ArgumentOutOfRangeException($"A number has to be between {_minNumber} and {_maxNumber}");

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
