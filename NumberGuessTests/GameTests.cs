using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberGuess;
using System;
using System.Collections.Generic;
using System.IO;
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
            Console.SetIn(new StringReader("15"));
            GuessResult actualResult = _guessGame.MakeGuess();
            Assert.IsFalse(actualResult == GuessResult.None);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MakeGuess_Game_Not_Started_Exception()
        {
            Console.SetIn(new StringReader("1"));
            _guessGame.MakeGuess();
        }

        [TestMethod]
        public void StartNewGame_Game_Started()
        {
            GuessNumber input = new GuessNumber();
            input.GenerateNewNumber();
            Game testGame = new Game(input);
            Console.SetIn(new StringReader("1"));
            testGame.MakeGuess();
        }

    }
}
