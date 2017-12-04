using System;
using BotInterface;

namespace ABetterBot
{
    public class BetterBot : IBot
    {
        private Random rand;
        private int currentDrawStreak = 0;
        private int dynamiteCounter = 0;
        private int enemyDynamiteCounter = 0;
        private int myWins = 0;
        private int enemyWins = 0;

        public string Name => "Better Bot";

        public BetterBot()
        {
            rand = new Random();
            rand = new Random(rand.Next(12345));
        }

        public Weapon GetNextWeaponChoice()
        {
            int approxWinsLeft = 2000 - 2*Math.Max(myWins, enemyWins);

            double ApproxNumTimesSituationWillRepeat = (double)approxWinsLeft / (Math.Pow(3, currentDrawStreak));
            int dynamiteLeft = 100 - dynamiteCounter;
            if ((ApproxNumTimesSituationWillRepeat/3)*0.95 < 100-dynamiteCounter)
            {
                if(rand.Next(3)==0)
                {
                    return Weapon.Dynamite;
                }
            }
            
            return (Weapon)rand.Next(3);// returns rock, paper, scissors randomly.
        }

        public void HandleBattleResult(BattleResult result, Weapon yourWeapon, Weapon enemiesWeapon)
        {
            
            if(result == BattleResult.Win)
            {
                myWins += 1 + currentDrawStreak;
            }
            if(result == BattleResult.Lose)
            {
                enemyWins += 1 + currentDrawStreak;
            }
            if(yourWeapon==Weapon.Dynamite)
            {
                dynamiteCounter++;
            }
            if(enemiesWeapon == Weapon.Dynamite)
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
