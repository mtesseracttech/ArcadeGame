using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeGuardian.Entity.LevelEntities;
using TimeGuardian.player;
using TimeGuardian.Utility;

namespace TimeGuardian.Level
{
    class Level2 : LevelBase
    {
        private int _levelNr = 2;

        private int[,] _tileMap;

        public Level2(TimeGuardianGame game) : base(game)
        {
            Game = game;

            BackgroundCreator();

            _tileMap = FileReader.levelMaker(_levelNr, UtilStrings.TilesX, UtilStrings.TilesY);

            Player = new Player(4, this, Game);

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
            return "Level" + _levelNr;
        }
    }
}
