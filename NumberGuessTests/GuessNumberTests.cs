using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberGuess;

namespace NumberGuessTests
{
    [TestClass]
    public class GuessNumberTests
    {
        private readonly GuessNumber guessNumber = new GuessNumber(1, 1);

        [TestInitialize]
        public void GuessNumberInit()
        {
            guessNumber.GenerateNewNumber();
        }

        [TestMethod]
        public void GetGuessResult_Valid_Number_Guess()
        {
            int input = 1;
            GuessResult actualResult = guessNumber.GetGuessResult(input);
            Assert.IsFalse(actualResult == GuessResult.None);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetGuessResult_Invalid_Number_Guess()
        {
            guessNumber.GetGuessResult(2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetGuessResult_Guess_After_Game_Finish_Exception()
        {
            guessNumber.GetGuessResult(1);
            guessNumber.GetGuessResult(1);
        }

        [TestMethod]
        public void GenerateNewNumber_Number_In_Range()
        {
            int expectedOutput = 1;
            int actualOutput = guessNumber.GenerateNewNumber();
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
