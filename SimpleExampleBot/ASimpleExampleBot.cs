using System;
using BotInterface;

namespace SimpleExampleBot
{
    public class ASimpleExampleBot : IBot
    {
        private Random rand;

        private int dynamiteCounter;

        public string Name => "Simple Example Bot";

        public Weapon GetNextWeaponChoice()
        {
            if (rand.Next(10) % 10 == 0 && dynamiteCounter < 100)
            {
                dynamiteCounter++;
                return Weapon.Dynamite;
            }
            else return (Weapon)rand.Next(3);// returns rock, paper, scissors randomly.
        }

        public void HandleBattleResult(BattleResult result, Weapon yourWeapon, Weapon enemiesWeapon)
        {
        }

        public void HandleFinalResult(bool isWin)
        {
        }

        public void NewGame(string enemyBotName)
        {
            rand = new Random();
            dynamiteCounter = 0;
        }
    }
}
