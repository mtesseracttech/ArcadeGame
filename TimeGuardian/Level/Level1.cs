using TimeGuardian.Entity.Enemy;
using TimeGuardian.Entity.LevelEntities;
using TimeGuardian.player;
using TimeGuardian.Utility;

namespace TimeGuardian.Level
{
    class Level1 : LevelBase
    {
        private int _levelNr = 1;

        private int[,] _tileMap;

        public Level1(TimeGuardianGame game) : base(game)
        {
            Game = game;
            BackgroundCreator();
            _tileMap = FileReader.levelMaker(_levelNr, UtilStrings.TilesX, UtilStrings.TilesY);
            CreateLevel();
            Player = new Player (5, this, Game);
            AddChild(Player);
			EagleEnemy eagleEnemy = new EagleEnemy (6, 1, 10, 5, this);
			AddChild (eagleEnemy);
			Enemies.Add (eagleEnemy.GetHitBox());
            Music = new Sound(UtilStrings.SoundsBackground+ "music_level_1.mp3", true, true);
            MusicChannel = Music.Play();
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
            foreach (Wall wall in Walls)
            {
                AddChild(wall);
            }
        }

        private void AddObject(int x, int y, int tile)
        {
            switch (tile)
            {
                case 17:
                    Wall wall17 = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall17.SetXY(x, y);
                    Walls.Add(wall17);
                    break;
                case 18:
                    Wall wall18 = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall18.SetXY(x, y);
                    Walls.Add(wall18);
                    break;
                case 19:
                    Wall wall19 = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall19.SetXY(x, y);
                    Walls.Add(wall19);
                    break;
                case 20:
                    Wall wall20 = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall20.SetXY(x, y);
                    Walls.Add(wall20);
                    break;
                case 21:
                    Wall wall21 = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall21.SetXY(x, y);
                    Walls.Add(wall21);
                    break;
                case 22:
                    Wall wall22 = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall22.SetXY(x, y);
                    Walls.Add(wall22);
                    break;
                case 23:
                    Wall wall23 = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall23.SetXY(x, y);
                    Walls.Add(wall23);
                    break;
                case 24:
                    Wall wall24 = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall24.SetXY(x, y);
                    Walls.Add(wall24);
                    break;
                case 25:
                    Wall wall25 = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall25.SetXY(x, y);
                    Walls.Add(wall25);
                    break;
                case 26:
                    Wall wall26 = new Wall(UtilStrings.TileLevel1 + tile + ".png");
                    wall26.SetXY(x, y);
                    Walls.Add(wall26);
                    break;
                case 27:
                    Wall wall27 = new Wall(UtilStrings.TileLevel1 + tile + ".png"); //INVISIBLE WALL
                    wall27.SetXY(x, y);
                    Walls.Add(wall27);
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
