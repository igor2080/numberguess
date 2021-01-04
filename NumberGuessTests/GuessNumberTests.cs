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
        public void GetGuessResult_ValidNumberGuess()
        {
            //arrange
            int input = 1;

            //act
            GuessResult actualResult = guessNumber.GetGuessResult(input);

            //assert
            Assert.IsFalse(actualResult == GuessResult.None);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetGuessResult_GuessAfterGameFinishException()
        {
            //act
            guessNumber.GetGuessResult(1);
            guessNumber.GetGuessResult(1);
        }

        [TestMethod]
        public void GenerateNewNumber_NumberInRange()
        {
            //arragne
            int expectedOutput = 1;

            //act
            int actualOutput = guessNumber.GenerateNewNumber();

            //assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void GetGuessResult_HigherGuessReturnsLower()
        {
            //arrange
            GuessNumber testNumber = new GuessNumber(1, 101);
            int randomNumber = testNumber.GenerateNewNumber();
            int higherGuess = new Random().Next(randomNumber, int.MaxValue);
            GuessResult expectedResult = GuessResult.Lower;

            //act
            GuessResult actualResult = testNumber.GetGuessResult(higherGuess);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetGuessResult_LowerGuessReturnsHigher()
        {
            //arrange
            GuessNumber testNumber = new GuessNumber(1, 101);
            int randomNumber = testNumber.GenerateNewNumber();
            int lowerGuess = new Random().Next(1, randomNumber);
            GuessResult expectedResult = GuessResult.Higher;

            //act
            GuessResult actualResult = testNumber.GetGuessResult(lowerGuess);

            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
