using System;

namespace NumberGuess
{
    public class Program
    {        
        static void Main(string[] args)
        {
            NumberGuessingGame _guessGame = new NumberGuessingGame();
            _guessGame.Play();
        }
    }
}
