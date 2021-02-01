using System;

namespace NumberGuess
{
    public class Program
    {        
        static void Main(string[] args)
        {
            NumberGuessingGame guessGame = new NumberGuessingGame();
            guessGame.Start();
        }
    }
}
