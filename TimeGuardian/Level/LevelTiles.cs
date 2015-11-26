using TimeGuardian.Entity.LevelEntities;
using TimeGuardian.player;
using TimeGuardian.Utility;

namespace TimeGuardian.Level
{
    class LevelTiles : GameObject
    {
        private const int TileSize = 32;
        private const int TilesX = 32;
        private const int TilesY = 24;
        private int[,] _tileMap;
        private string[] _tileSprites;

        public LevelTiles(int levelNr, LevelBase level)
        {
            _tileMap = FileReader.levelMaker(levelNr, TilesX, TilesY);
            //CreateLevel();
            level.AddChild(this);
        }
        /*
        
        
        private void AddObject(int x, int y, int tile)
        {
            switch (tile)
            {
            }
        }
        */
        
    }
}
