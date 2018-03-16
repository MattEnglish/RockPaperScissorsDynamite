﻿using System;
using BotInterface;

namespace MEDrawBot
{
    public class MEDraw : IBot

    {
        public string Name => "MEBOT";

        private Random rand;
        private int currentDrawStreak = 0;
        private int dynamiteCounter = 0;
        private int enemyDynamiteCounter = 0;
        private int myWins = 0;
        private int enemyWins = 0;

        public MEDraw()
        {
            rand = new Random();
            rand = new Random(rand.Next());
            rand = new Random(rand.Next());
        }

        public Weapon GetNextWeaponChoice()
        {
            int approxWinsLeft = 2000 - 2 * Math.Max(myWins, enemyWins);

            double L = (double)approxWinsLeft / (Math.Pow(3, currentDrawStreak));//ApproxNumTimesSituationWillRepeat
            double d = -1 + (Math.Log((double)approxWinsLeft) - Math.Log(100 - dynamiteCounter)) / Math.Log(3);//Approx number Of Consecutive Draws Whereby dynamite can be thrown one third of the time.
            double v = 1.4* Math.Max((Math.Floor(d) + 1.0), 0); //Very approx value of dynamite probably underestimate
            double ed = -1 + (Math.Log((double)approxWinsLeft) - Math.Log(100 - enemyDynamiteCounter)) / Math.Log(3);//Approx number Of Consecutive Draws Whereby dynamite can be thrown one third of the time.
            double ev = 1.4 * Math.Max((Math.Floor(ed) + 1.0), 0); //Very approx value of dynamite

            double pW = Math.Max((1 -  1 * ev / (currentDrawStreak + 1)) / 3.0, 0);//I don't understand why does 0.8 work better than 1. SOMETHING WRONG!!!!!!!!!!!!!!!!!!!!!
            double pD = 0;
            if( currentDrawStreak > d)
            {
                pD = 0.33;
            }
            else if (currentDrawStreak == Math.Floor(d))
            {
                var a = (double)approxWinsLeft / (Math.Pow(3, currentDrawStreak+1));//ApproxNumTimesSituationPlusOneDrawWillRepeat
                var b = 0.30 * a;//For whatever reason this works fine
                var c = Math.Max(100 - dynamiteCounter - b,0);
                pD = c / L;
                pD = Math.Min(pD, 0.33);
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
            if(weaponChoice < pW + pD)
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
