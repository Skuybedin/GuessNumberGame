using System;

namespace GuessNum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GuessNum game = new GuessNum(maxTries: 7, guessingPlayer: GuessingPlayer.Human);
            game.Start();

            Console.ReadLine();
        }
    }
}
