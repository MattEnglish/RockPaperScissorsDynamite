using System;
using RockPaperDynamiteEngine;
using SimpleExampleBot;
using BotInterface;
using ABetterBot;
using MEDRAW3;
using TestBots;
using MeLearn;
using MELearn2;


namespace RockPaperDynamite
{
    class Program
    {
        static void Main(string[] args)
        {
            runGames();
        }

        public static void runTest()
        {
            var waveMemory = new WaveMemoryStreak();
            waveMemory.AddMove(Weapon.Rock);
            waveMemory.AddMove(Weapon.Rock);
            waveMemory.AddMove(Weapon.Rock);
            waveMemory.AddMove(Weapon.Dynamite);
            waveMemory.AddMove(Weapon.Dynamite);
            waveMemory.AddMove(Weapon.Dynamite);

            var x = waveMemory.getNextShotProbValues();
        }

        public static void runGames()
        {

            var gameRunner = new GameRunnerWithData();
            IBot bot1 = new ASimpleExampleBot();
            IBot bot2 = new ASecondSimpleExampleBot();

            GameData gameData;
            gameData = gameRunner.RunGame(new WaveBot(), new WeWillRockYou());
            Console.WriteLine(gameData.ToString());
            gameData = gameRunner.RunGame(new WaveBot(), new BetterBot());
            PrintRange(gameData, 100, 10);
            Console.WriteLine(gameData.ToString());
            gameData = gameRunner.RunGame(new WaterBallons(), new DynamiteBot());
            Console.WriteLine(gameData.ToString());
            gameData = gameRunner.RunGame(new WaveBot(), new DynamiteBot());
            Console.WriteLine(gameData.ToString());
            gameData = gameRunner.RunGame(new WaveBot(), new WaterBallons());
            Console.WriteLine(gameData.ToString());
            gameData = gameRunner.RunGame(new WaveBot(), new WeWillRockYou());
            Console.WriteLine(gameData.ToString());
            gameData = gameRunner.RunGame(new WaveBot(), new ShortTermMemory());
            Console.WriteLine(gameData.ToString());
            gameData = gameRunner.RunGame(new WaveBot(), new ShortTermMemory2());
            Console.WriteLine(gameData.ToString());
            gameData = gameRunner.RunGame(new WaveBot(), new METEST());
            Console.WriteLine(gameData.ToString());
            gameData = gameRunner.RunGame(new WaveBot(), new METEST());
            Console.WriteLine(gameData.ToString());


            gameData = gameRunner.RunGame(new WaveBot(), new DynamiteBot());
            Console.WriteLine(gameData.ToString());
            gameData = gameRunner.RunGame(new WaveBot(), new WaterBallons());
            Console.WriteLine(gameData.ToString());
            gameData = gameRunner.RunGame(new WaveBot(), new WeWillRockYou());
            Console.WriteLine(gameData.ToString());
            gameData = gameRunner.RunGame(new WaveBot(), new ShortTermMemory());
            Console.WriteLine(gameData.ToString());
            gameData = gameRunner.RunGame(new ShortTermMemory(), new WaveBot());
            Console.WriteLine(gameData.ToString());
            gameData = gameRunner.RunGame(new WaveBot(), new METEST());
            Console.WriteLine(gameData.ToString());
            gameData = gameRunner.RunGame(new WaveBot(), new METEST());
            Console.WriteLine(gameData.ToString());

            var leagueData = LeagueRunner.RunLeague(new ShortTermMemory(), new WaveBot());
            Console.WriteLine(leagueData.ToString());

            leagueData = LeagueRunner.RunLeague(new METEST(), new WaveBot());
            Console.WriteLine(leagueData.ToString());
            leagueData = LeagueRunner.RunLeague( new WaveBot(), new ShortTermMemory2());
            Console.WriteLine(leagueData.ToString());
            leagueData = LeagueRunner.RunQuickLeague(new WaveBot(), new MEDraw());
            Console.WriteLine(leagueData.ToString());
            leagueData = LeagueRunner.RunQuickLeague(new WaveBot(), new BetterBot());
            Console.WriteLine(leagueData.ToString());
            leagueData = LeagueRunner.RunQuickLeague(new WaveBot(), new DynamiteBot());
            Console.WriteLine(leagueData.ToString());
            leagueData = LeagueRunner.RunQuickLeague(new WaveBot(), new WaterBallons());
            Console.WriteLine(leagueData.ToString());
            Console.Read();
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
