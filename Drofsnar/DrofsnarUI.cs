using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Drofsnar
{
    class DrofsnarUI
    {
        public enum BirdType { Bird = 10, CrestedIbis = 100, GreatKiskudee = 300, RedCrossbill = 500, RedneckedPhalarope = 700, EveningGrosbeak = 1000, GreaterPrairieChicken = 2000, IcelandGull = 3000, OrangebelliedParrot = 5000 }
        public int playerLives = 3;
        public int playerPoints = 5000;
        public int lifePoints = 5000;
        public int vbh = 0;
        public int finalScore;
        //Set the address below to the game-sequence.txt address in the Drofsnar folder above the solution file.
        StreamReader sr = new StreamReader(@"C:\Users\kylew\1150Projects\DotNetProjects\GoldBadge\Projects\Drofsnar\game-sequence.txt");
        public void Run()
        {
            RunMenu();
        }
        private void RunMenu()
        {
            while (playerLives > 0)
            {
                foreach (string bird in sr.ReadLine().Split(','))
                {
                    if (bird != "InvincibleBirdHunter" && bird != "VulnerableBirdHunter")
                    {
                        BirdType birdEnum = (BirdType)Enum.Parse(typeof(BirdType), bird);
                        playerPoints += (int)birdEnum;
                        lifePoints += (int)birdEnum;
                        Console.WriteLine($"Drofsnar saved a {birdEnum}!                    {playerPoints}pts");
                        Thread.Sleep(100);
                    }
                    else if (bird == "VulnerableBirdHunter")
                    {
                        playerPoints += 200 * Convert.ToInt32(Math.Pow(2, vbh));
                        lifePoints += 200 * Convert.ToInt32(Math.Pow(2, vbh));
                        vbh++;
                        Console.WriteLine($"Drofsnar defeated a Vulnerable Bird Hunter. {playerPoints}pts");
                        Thread.Sleep(100);
                    }
                    else
                    {
                        playerLives--;
                        Console.WriteLine($"Drofsnar encountered an Invincible Bird Hunter. Drofsnar has {playerLives} lives left.");
                        Thread.Sleep(100);
                    }
                    finalScore = playerPoints;
                    if (lifePoints >= 10000)
                    {
                        lifePoints -= 10000;
                        playerLives++;
                        Console.WriteLine($"Drofsnar gained an extra life! Drofsnar now has {playerLives} lives!");
                    }
                    if (playerLives == 0)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine($"Thanks for playing. Your final score is {finalScore}. Enter any key to exit.");
            Console.ReadKey();
        }
    }
}
