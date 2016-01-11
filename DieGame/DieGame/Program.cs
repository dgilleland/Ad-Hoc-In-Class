using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int dieSize;
            Console.WriteLine("Enter the number of sides (6 or 12): ");
            dieSize = int.Parse(Console.ReadLine()); // no validation for now.....

            // Instantiate our Die objects
            Die firstPlayer = new Die(dieSize);
            Die secondPlayer;
            if (dieSize == 6)
                secondPlayer = new Die();
            else
                secondPlayer = new Die(dieSize);

            PlayGame(firstPlayer, secondPlayer);
        }

        private static void PlayGame(Die firstPlayerDie, Die secondPlayerDie)
        {
            firstPlayerDie.Roll();
            secondPlayerDie.Roll();
            Console.WriteLine("Results: " + firstPlayerDie.FaceValue + " vs. " + secondPlayerDie.FaceValue);
            if (firstPlayerDie.FaceValue > secondPlayerDie.FaceValue)
                Console.WriteLine("First player won");
            else if (firstPlayerDie.FaceValue < secondPlayerDie.FaceValue)
                Console.WriteLine("Second player won");
            else
                Console.WriteLine("It's a Tie!!");
        }
    }
}
