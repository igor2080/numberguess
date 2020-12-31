using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberGuess;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumberGuessTests
{
    [TestClass]
    public class GameTests
    {
        private readonly Game _guessGame = new Game();

        [TestMethod]
        public void MakeGuess_Valid_Guess()
        {
            _guessGame.StartNewGame();
            int input = 15;
            GuessResult actualResult = _guessGame.MakeGuess(input);
            Assert.IsFalse(actualResult == GuessResult.None);
        }

        [TestMethod]
        public void MakeGuess_Invalid_Guess()
        {
            _guessGame.StartNewGame();
            int input = 105;
            GuessResult actualResult = _guessGame.MakeGuess(input);
            GuessResult expectedResult = GuessResult.None;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MakeGuess_Game_Not_Started_No_Result()
        {
            Assert.IsTrue(_guessGame.MakeGuess(1) == GuessResult.None);
        }
    }
}
