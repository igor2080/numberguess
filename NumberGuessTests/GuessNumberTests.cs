using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberGuess;

namespace NumberGuessTests
{
    [TestClass]
    public class GuessNumberTests
    {
        private readonly GuessNumber guessNumber = new GuessNumber();

        [TestInitialize]
        public void GuessNumberInit()
        {
            guessNumber.GenerateNewNumber();
        }

        [TestMethod]
        public void GetGuessResult_Valid_Number_Guess()
        {
            int input = 5;
            GuessResult actualResult = guessNumber.GetGuessResult(input);
            Assert.IsFalse(actualResult == GuessResult.None);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetGuessResult_Invalid_Number_Guess()
        {
            int input = 120;
            guessNumber.GetGuessResult(input);
        }
    }
}
