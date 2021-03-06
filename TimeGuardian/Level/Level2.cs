﻿using TimeGuardian.Entity.Enemy;
using TimeGuardian.Entity.LevelEntities;
using TimeGuardian.Entity.Player;
using TimeGuardian.Utility;

namespace TimeGuardian.Level
{
    internal class Level2 : LevelBase
    {
        private readonly EnemyOwl _enemy;
        private readonly int[,] _tileMap;

        private readonly int _levelNr = 2;

        public Level2(TimeGuardianGame game, int lives) : base(game)
        {
            Game = game;
            BackgroundCreator();
            _tileMap = FileReader.levelMaker(_levelNr, UtilStrings.TilesX, UtilStrings.TilesY);
            Player = new Player(lives, this, Game);
            _enemy = new EnemyOwl(this);
            CreateLevel();
            AddChild(Player);
            AddChild(_enemy);
            Music = new Sound(UtilStrings.SoundsBackground + "music_level_2.mp3", true, true);
            MusicChannel = Music.Play();
            AddChild(Pause);
        }


        private void CreateLevel()
        {
            for (var i = 0; i < UtilStrings.TilesY; i++)
            {
                for (var j = 0; j < UtilStrings.TilesX; j++)
                {
                    var tile = _tileMap[i, j];
                    if (tile != 0) AddObject(j*UtilStrings.TileSize, i*UtilStrings.TileSize, tile);
                }
            }
            foreach (var wall in Walls)
            {
                AddChild(wall);
            }
        }

        private void AddObject(int x, int y, int tile)
        {
            switch (tile)
            {
                case 17:
                    var wall17 = new Wall(UtilStrings.TileLevel2 + tile + ".png");
                    wall17.SetXY(x, y);
                    Walls.Add(wall17);
                    break;
                case 18:
                    var wall18 = new Wall(UtilStrings.TileLevel2 + tile + ".png");
                    wall18.SetXY(x, y);
                    Walls.Add(wall18);
                    break;
                case 19:
                    var wall19 = new Wall(UtilStrings.TileLevel2 + tile + ".png");
                    wall19.SetXY(x, y);
                    Walls.Add(wall19);
                    break;
                case 20:
                    var wall20 = new Wall(UtilStrings.TileLevel2 + tile + ".png");
                    wall20.SetXY(x, y);
                    Walls.Add(wall20);
                    break;
                case 21:
                    var wall21 = new Wall(UtilStrings.TileLevel2 + tile + ".png");
                    wall21.SetXY(x, y);
                    Walls.Add(wall21);
                    break;
                case 22:
                    var wall22 = new Wall(UtilStrings.TileLevel2 + tile + ".png");
                    wall22.SetXY(x, y);
                    Walls.Add(wall22);
                    break;
                case 23:
                    var wall23 = new Wall(UtilStrings.TileLevel2 + tile + ".png");
                    wall23.SetXY(x, y);
                    Walls.Add(wall23);
                    break;
                case 24:
                    var wall24 = new Wall(UtilStrings.TileLevel2 + tile + ".png");
                    wall24.SetXY(x, y);
                    Walls.Add(wall24);
                    break;
                case 25:
                    var wall25 = new Wall(UtilStrings.TileLevel2 + tile + ".png");
                    wall25.SetXY(x, y);
                    Walls.Add(wall25);
                    break;
                case 26:
                    var wall26 = new Wall(UtilStrings.TileLevel2 + tile + ".png");
                    wall26.SetXY(x, y);
                    Walls.Add(wall26);
                    break;
                case 27:
                    var wall27 = new Wall(UtilStrings.TileLevel2 + tile + ".png"); //INVISIBLE WALL
                    wall27.SetXY(x, y);
                    Walls.Add(wall27);
                    break;
            }
        }

        private void BackgroundCreator()
        {
            for (var i = 0; i < 2; i++)
            {
                Backgrounds.Add(new Background(UtilStrings.SpritesLevel2 + "background_" + i + ".png", i, this));
            }
            for (var i = 0; i < Backgrounds.Count; i++)
            {
                AddChild(Backgrounds[i]);
            }
        }

        protected override void Update()
        {
            if (_enemy.IsDead()) TimeStop = false;
            BackgroundManager();
            base.Update();
        }

        private void BackgroundManager()
        {
            foreach (var background in Backgrounds) background.Scroll(Player.x);
        }

        public override string GetLevelName()
        {
            return "Level" + _levelNr;
        }

        public override string GetNextLevelName()
        {
            return "Level" + (_levelNr + 1);
        }
    }
}