using TimeGuardian.Entity.LevelEntities;
using TimeGuardian.player;
using TimeGuardian.Utility;

namespace TimeGuardian.Level
{
    class LevelTiles : GameObject
    {
        private const int TileSize = 64;
        private const int TilesX = 16;
        private const int TilesY = 12;
        private int[,] _tileMap;
        private string[] _tileSprites;

        public LevelTiles(int levelNr, LevelBase level)
        {
            _tileMap = FileReader.levelMaker(levelNr, TilesX, TilesY);
            CreateLevel();
            level.AddChild(this);
        }

        private void CreateLevel()
        {
            for (int i = 0; i < TilesY; i++)
            {
                for (int j = 0; j < TilesX; j++)
                {
                    int tile = _tileMap[i, j];
                    if (tile != 0) AddObject(j * TileSize, i * TileSize, tile);
                }
            }
        }

        private void AddObject(int x, int y, int tile)
        {
            switch (tile)
            {
            }
        }
    }
}
