using System.Collections.Generic;
using System.IO;

namespace GXPEngine.Utility
{
    class FileReader
    {
        public static List<int[,]> LevelsCompiler(int numberOfLevels)
        {
            List<int[,]> levels = new List<int[,]>();

            for (int i = 0; i < numberOfLevels; i++)
            {
                levels.Add(levelMaker(i + 1));
            }

            return levels;
        }


        public static int[,] levelMaker(int levelnr)
        {
            StreamReader reader = new StreamReader("level" + levelnr + ".txt");
            string fileData = reader.ReadToEnd();
            reader.Close();

            int[,] level = new int[0, 0];
            string[] lines = fileData.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                string[] cols = lines[i].Split(',');
                for (int j = 0; j < cols.Length; j++)
                {
                    //Sets the height and width the first time
                    //TODO: Check if lines.Length and cols.Length have to be switched around
                    if (i == 0 && j == 0) level = new int[lines.Length,cols.Length]; 
                    level[i, j] = int.Parse(cols[j]);
                }
            }

            return level;
        }




    }
}
