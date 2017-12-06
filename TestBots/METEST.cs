using System;
using System.Collections.Generic;
using System.Text;
using BotInterface;

namespace TestBots
{
    public class METEST : IBot

    {
        public string Name => "METEST";

        private Random rand;
        private int currentDrawStreak = 0;
        private int dynamiteCounter = 0;
        private int enemyDynamiteCounter = 0;
        private int myWins = 0;
        private int enemyWins = 0;

        public METEST()
        {
            rand = new Random();
            rand = new Random(rand.Next());
            rand = new Random(rand.Next());
            rand = new Random(rand.Next());
        }

        public Weapon GetNextWeaponChoice()
        {
            int approxWinsLeft = 2000 - 2 * Math.Max(myWins, enemyWins);

            double L = (double)approxWinsLeft / (Math.Pow(3, currentDrawStreak));//ApproxNumTimesSituationWillRepeat
            double d = (Math.Log((double)approxWinsLeft) - Math.Log(100 - dynamiteCounter)) / Math.Log(3);//Approx number Of Consecutive Draws Whereby dynamite can be thrown one third of the time.
            double v = Math.Max(0.5 * (Math.Floor(d) + 1.0), 0); //Very approx value of dynamite probably underestimate
            double ed = (Math.Log((double)approxWinsLeft) - Math.Log(100 - enemyDynamiteCounter)) / Math.Log(3);//Approx number Of Consecutive Draws Whereby dynamite can be thrown one third of the time.
            double ev = Math.Max(0.5 * (Math.Floor(ed) + 1.0), 0); //Very approx value of dynamite

            double pW = Math.Max((1 -  0.7* 2 * ev / (currentDrawStreak + 1)) / 3.0, 0);//probability of choosing waterBallon (This probably should be an upper bound)
            double pD = 0;
            if (currentDrawStreak > d)
            {
                pD = 0.33;
            }
            else if (currentDrawStreak == Math.Floor(d))
            {
                var a = (double)approxWinsLeft / (Math.Pow(3, currentDrawStreak + 1));//ApproxNumTimesSituationPlusOneDrawWillRepeat
                var b = 0.3 * a;
                var c = 100 - dynamiteCounter - b;
                pD = c / L;
            }
            else
            {
                pD = 0;
            }

            var weaponChoice = rand.NextDouble();
            if (weaponChoice < pW)
            {
                return Weapon.WaterBallon;
            }
            if (weaponChoice < pW + pD)
            {
                return Weapon.Dynamite;
            }

            return (Weapon)rand.Next(3);// returns rock, paper, scissors randomly.
        }

        public void HandleBattleResult(BattleResult result, Weapon yourWeapon, Weapon enemiesWeapon)
        {

            if (result == BattleResult.Win)
            {
                myWins += 1 + currentDrawStreak;
            }
            if (result == BattleResult.Lose)
            {
                enemyWins += 1 + currentDrawStreak;
            }
            if (yourWeapon == Weapon.Dynamite)
            {
                dynamiteCounter++;
            }
            if (enemiesWeapon == Weapon.Dynamite)
            {
                enemyDynamiteCounter++;
            }
            if (result == BattleResult.Draw)
            {
                currentDrawStreak++;
            }
            else
            {
                currentDrawStreak = 0;
            }
        }

        public void HandleFinalResult(bool isWin)
        {
        }

        public void NewGame(string enemyBotName)
        {
            currentDrawStreak = 0;
            dynamiteCounter = 0;
            enemyDynamiteCounter = 0;
            myWins = 0;
            enemyWins = 0;
        }
    }
}
