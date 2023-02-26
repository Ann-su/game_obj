using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;

namespace game_obj
{
    internal class GameOverScene :GameOverSceneFunction
    {
        public static int sceneID = 3;                      
        GameOverSceneGraphic gameOverSceneGraphic = new GameOverSceneGraphic();

        public static List<string> greatestSoldiersNames = new List<string>();  // nazwy najlepszych graczy
        public static List<int> greatestSoldiersScores = new List<int>();       // wyniki najlepszych graczy
        public static Dictionary<string, int> ranking = new Dictionary<string, int>();
        private static string contents = System.IO.File.ReadAllText(Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Results.txt"));
        public static string Contents { get { return contents; } }
        public void Start(int playerScore)
        {
            while (Console.KeyAvailable) Console.ReadKey(true);  // czyszczenie wejścia konsoli
            GameManager.ActiveSceneId = 2;
            Console.Clear();
            Console.SetCursorPosition(80, 20);
            Console.Write("State your name, soldier: ");            
            string playerName = Console.ReadLine();
            
            while (HasComma(playerName))
            {
                Console.SetCursorPosition(80, 20);
                Console.WriteLine("Player's name cannot contain comma");
                Console.SetCursorPosition(80, 21);
                Console.Write("                                                                       ");
                Console.SetCursorPosition(80, 21);
                Console.Write("State your name, soldier: ");
                playerName = Console.ReadLine();                
            }

            greatestSoldiersNames.Add(playerName);
            greatestSoldiersScores.Add(playerScore);
            File2Dictionary(Contents, greatestSoldiersNames, greatestSoldiersScores);         

            SaveToFile(greatestSoldiersNames, greatestSoldiersScores);
            int playerRanking = greatestSoldiersNames.IndexOf(playerName) + 1;  // przypisać zmiennej playerRanking pozycję gracza na liście
            
            gameOverSceneGraphic.DrawScoreTable(greatestSoldiersNames, greatestSoldiersScores, playerRanking);
        }
        public void KeyPressed(Key key)
        {
            if (key == Key.Space)
            {
                GameManager.isRunning = false; // spacja zamyka okno z wynikami
            }
        }
    }
}
