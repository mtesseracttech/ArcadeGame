using System.CodeDom;
using System.Collections.Generic;
using System.IO;

namespace TimeGuardian.Utility
{
    class FileReader
    {
        public static int[,] levelMaker(int levelnr, int width, int height)
        {
            int[,] level = new int[height, width];

            StreamReader reader = new StreamReader("level_" + levelnr + ".txt");
            string fileData = reader.ReadToEnd();
            reader.Close();

            string[] lines = fileData.Split('\n');
            for (int i = 0; i < height; i++)
            {
                string[] columns = lines[i].Split(',');
                for (int j = 0; j < width; j++)
                {
                    level[i, j] = int.Parse(columns[j]);
                }
            }
            return level;
        }
    }
}
