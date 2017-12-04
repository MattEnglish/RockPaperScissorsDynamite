using System;
using BotInterface;

namespace ROCKS
{
    public class WeWillRockYou : IBot
    {
        string IBot.Name => "We Will Rock You";

        Weapon IBot.GetNextWeaponChoice()
        {
            return Weapon.Rock;
        }

        void IBot.HandleBattleResult(BattleResult result, Weapon yourWeapon, Weapon enemiesWeapon)
        {
        }

        void IBot.HandleFinalResult(bool isWin)
        {
        }

        void IBot.NewGame(string enemyBotName)
        {
        }
    }
}
