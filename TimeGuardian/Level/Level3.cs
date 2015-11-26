﻿using TimeGuardian.Entity.LevelEntities;
using TimeGuardian.player;
using TimeGuardian.UI.Menu;
using TimeGuardian.Utility;

namespace TimeGuardian.Level
{
    class Level3 : LevelBase
    {
        private int _levelNr = 3;

        private int[,] _tileMap;

        public Level3(TimeGuardianGame game, Player player) : base(game)
        {
            Game = game;
            Player = player;
            BackgroundCreator();

            _tileMap = FileReader.levelMaker(_levelNr, UtilStrings.TilesX, UtilStrings.TilesY);

            AddChild(Player);
            CreateLevel();

            AddChild(Pause);
        }

        private void CreateLevel()
        {
            for (int i = 0; i < UtilStrings.TilesY; i++)
            {
                for (int j = 0; j < UtilStrings.TilesX; j++)
                {
                    int tile = _tileMap[i, j];
                    if (tile != 0) AddObject(j * UtilStrings.TileSize, i * UtilStrings.TileSize, tile);
                }
            }
        }

        private void AddObject(int x, int y, int tile)
        {
            Wall wall = new Wall(UtilStrings.SpriteDebug);
            switch (tile)
            {
                case 17:
                    wall = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall.SetXY(x, y);
                    AddChild(wall);
                    break;
                case 18:
                    wall = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall.SetXY(x, y);
                    AddChild(wall);
                    break;
                case 19:
                    wall = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall.SetXY(x, y);
                    AddChild(wall);
                    break;
                case 20:
                    wall = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall.SetXY(x, y);
                    AddChild(wall);
                    break;
                case 21:
                    wall = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall.SetXY(x, y);
                    AddChild(wall);
                    break;
                case 22:
                    wall = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall.SetXY(x, y);
                    AddChild(wall);
                    break;
                case 23:
                    wall = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall.SetXY(x, y);
                    AddChild(wall);
                    break;
                case 24:
                    wall = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall.SetXY(x, y);
                    AddChild(wall);
                    break;
                case 25:
                    wall = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall.SetXY(x, y);
                    AddChild(wall);
                    break;
                case 26:
                    wall = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall.SetXY(x, y);
                    AddChild(wall);
                    break;
                case 27:
                    wall = new Wall(UtilStrings.TileLevel1 + tile + ".png"); //INVISIBLE WALL
                    wall.SetXY(x, y);
                    AddChild(wall);
                    break;
            }

        }

        private void BackgroundCreator()
        {
            for (int i = 0; i < 2; i++)
            {
                Backgrounds.Add(new Background(UtilStrings.SpritesLevel1 + "background_" + i + ".png", i, this));
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
            return "Level" + _levelNr;
        }
    }
}
