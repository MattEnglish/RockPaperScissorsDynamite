using System;
using RockPaperDynamiteEngine;
using SimpleExampleBot;
using BotInterface;
using ABetterBot;
using MEDrawBot;
using TestBots;


namespace RockPaperDynamite
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameRunner = new GameRunnerWithData();
            IBot bot1 = new ASimpleExampleBot();
            IBot bot2 = new ASecondSimpleExampleBot();
            GameData gameData = gameRunner.RunGame(new MEDraw(), new BetterBot());
            PrintRange(gameData,100,10);
            Console.WriteLine(gameData.ToString());

            gameData = gameRunner.RunGame(new MEDraw(), new DynamiteBot());
            Console.WriteLine(gameData.ToString());
            gameData = gameRunner.RunGame(new MEDraw(), new WaterBallons());
            Console.WriteLine(gameData.ToString());
            gameData = gameRunner.RunGame(new MEDraw(), new WeWillRockYou());
            Console.WriteLine(gameData.ToString());

            var leagueData = LeagueRunner.RunLeague(new BetterBot(), new MEDraw());
            Console.WriteLine(leagueData.ToString());
            leagueData = LeagueRunner.RunLeague(new MEDraw(), new BetterBot());
            Console.WriteLine(leagueData.ToString());
            leagueData = LeagueRunner.RunQuickLeague(new MEDraw(), new BetterBot());
            Console.WriteLine(leagueData.ToString());
            leagueData = LeagueRunner.RunQuickLeague(new BetterBot(), new MEDraw());
            Console.WriteLine(leagueData.ToString());


        }

        public static void PrintRange(GameData gameData, int startingIndex, int count)
        {
            foreach(var battle in gameData.Battles.GetRange(startingIndex, count))
            {
                Console.WriteLine(battle.ToString());
            }
        }
    }
}
