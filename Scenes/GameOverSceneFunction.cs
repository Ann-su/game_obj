using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace game_obj
{
    internal class GameOverSceneFunction
    {
        protected bool HasComma(string word)
        {
            if (word.Contains(',')) return true;
            return false;
        }

        protected void Sort(List<string> namesList, List<int> scoresList)  //insertion sort list z nazwami i wynikami graczy
        {
            int n = scoresList.Count;
            int key, j;
            string temp;
            for (int i = 1; i < n; i++)
            {
                key = scoresList[i];
                temp = namesList[i];
                j = i - 1;
                while (j >= 0 && scoresList[j] < key)
                {
                    scoresList[j + 1] = scoresList[j];
                    namesList[j + 1] = namesList[j];
                    j--;
                }
                scoresList[j + 1] = key;
                namesList[j + 1] = temp;
            }
        }
        protected void File2Dictionary(string str, List<string> namesList, List<int> scoresList)  //zamiana list na słownik
        {
            String[] splitContents = str.Split(',');
            for (int i = 0; i < splitContents.Length; i++)
            {
                if (i % 2 == 0) namesList.Add(splitContents[i]);
                else scoresList.Add(Int32.Parse(splitContents[i]));
            }

            Sort(namesList, scoresList);

            //for (int i = 0; i < greatestSoldiersNames.Count; i++) ranking.Add(greatestSoldiersNames[i], greatestSoldiersScores[i]);

        }
        protected void SaveToFile(List<string> namesList, List<int> scoresList)  //zapisywanie do pliku
        {
            StreamWriter sw = new StreamWriter(System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Results.txt"));
            for (int i = 0; i < scoresList.Count; i++)
            {
                if (i != 0) sw.Write(",");
                sw.Write(namesList[i] + "," + scoresList[i]);
            }
            sw.Close();
        }
    }
}
