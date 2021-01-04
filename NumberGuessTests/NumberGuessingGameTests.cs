using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NumberGuess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NumberGuessTests
{
    [TestClass]
    public class NumberGuessingGameTests
    {
        private readonly NumberGuessingGame _guessGame = new NumberGuessingGame(new GuessNumber(1,1));

        [TestMethod]
        public void Play_Valid_Guess()
        {
            Console.SetIn(new StringReader("1"));
            StringWriter output = new StringWriter();
            Console.SetOut(output);
            _guessGame.Start();
            Assert.AreEqual(output.ToString().Split("\r\n")[1], "You guessed correctly!");
        }

    }
}
