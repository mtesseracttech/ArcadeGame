using System.Collections.Generic;
using TimeGuardian.Entity;
using TimeGuardian.player;
using TimeGuardian.Entity.Enemy;
using TimeGuardian.Entity.LevelEntities;
using TimeGuardian.Utility;

namespace TimeGuardian.Level
{
    class Level1 : LevelBase
    {
        private int _levelNr = 1;
        private const int TileSize = 32;
        private const int TilesX = 32;
        private const int TilesY = 24;
        private int[,] _tileMap;

        public Level1(TimeGuardianGame game) : base(game)
        {
            Game = game;

            BackgroundCreator();

            _tileMap = FileReader.levelMaker(_levelNr, TilesX, TilesY);

            Player = new Player (4, this, Game);

            AddChild(Player);
            CreateLevel();
			//create new enemy with ?? 10 ?? healthpoints and ?? 5 ?? damage
			//EagleEnemy eagleEnemy = new EagleEnemy (6, 1, 10, 5, this);

			//AddChild (eagleEnemy);
			//Enemies.Add (eagleEnemy.GetHitBox());

            AddChild(Pause);
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
                case 1:
                    Wall debugWall = new Wall(UtilStrings.SpriteDebugSmall);
                    debugWall.SetXY(x, y);
                    AddChild(debugWall);
                    break;
            }

        }







        private void BackgroundCreator()
        {
            for (int i = 0; i < 2; i++)
            {
                Backgrounds.Add(new Background(UtilStrings.SpritesLevel + "1/background_" + i + ".png", i, this));
            }
            for (int i = 0; i < Backgrounds.Count; i++)
            {
                AddChild(Backgrounds[i]);
            }
        }

        protected override void Update()
        {
            BackgroundManager();
            base.Update();
        }

        private void BackgroundManager()
        {
            foreach (Background background in Backgrounds)
            {
                //This solution works fine, as long as the player x and y are always manipulated through the x/ySpeed
                //background.Scroll(Player.GetXSpeed(), Player.GetYSpeed());
                background.Scroll(Player.x, Player.y);
            }
        }

        protected override void UpdateUnpaused()
        {
            HitDetection();
        }

        protected override void UpdateNoTimeStop()
        {
            
        }

        protected override void HitDetection()
        {
            base.HitDetection();
        }

        public override string GetLevelName()
        {
            return "Level"+_levelNr;
        }
    }
}
