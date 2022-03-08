using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNum
{
    public enum GuessingPlayer
    {
        Human,
        Machine
    }
    public class GuessNum
    {
        private readonly int max;
        private readonly int maxTries;
        private readonly GuessingPlayer guessingPlayer;

        public GuessNum(int max = 100, int maxTries = 5, GuessingPlayer guessingPlayer = GuessingPlayer.Human)
        {
            this.max = max;
            this.maxTries = maxTries;
            this.guessingPlayer = guessingPlayer;
        }

        public void Start()
        {
            if (guessingPlayer == GuessingPlayer.Human) HumanGuess();
            else MachineGuess();
        }

        private void HumanGuess()
        {
            Random rand = new Random();
            int guessedNumber = rand.Next(0,max);

            int lastGuess = -1;
            int count = 0;

            while(lastGuess != guessedNumber && count < maxTries)
            {
                Console.WriteLine("Guess the number");
                lastGuess = int.Parse(Console.ReadLine());

                if (lastGuess == guessedNumber)
                {
                    Console.WriteLine("Congrats! You guessed the number!");
                    break;
                }
                else if (lastGuess < guessedNumber) Console.WriteLine("My number is greater!");
                else Console.WriteLine("My number is less!");
                count++;

                if (count == maxTries) Console.WriteLine("You lost!");
            }
        }

        private void MachineGuess()
        {
            Console.WriteLine("Enter a number that`s going to be a computer!");

            int guessedNumber = -1;
            while(guessedNumber == -1)
            {
                int parsedNumber = int.Parse(Console.ReadLine());
                if (parsedNumber >= 0 && parsedNumber <= this.max) guessedNumber = parsedNumber;
            }

            int lastGuess = -1;
            int min = 0;
            int max = this.max;
            int count = 0;

            while (lastGuess != guessedNumber && count < maxTries)
            {
                lastGuess = (max + min) / 2;
                Console.WriteLine($"Did you guess this number - {lastGuess}?\nIf yes enter 'y', if your number is greater - enter 'g', if less - enter 'l'");

                string answer = Console.ReadLine();

                if (answer == "y") 
                {
                    Console.WriteLine("Super! I guessed your number");
                    break;
                }

                else if (answer == "g") min = lastGuess;
                else max = lastGuess;

                if (lastGuess == guessedNumber) Console.WriteLine("Dont cheat!");

                count++;

                if (count == maxTries) Console.WriteLine("No tries anymore :( I lost!");
            }
        }
    }
}
