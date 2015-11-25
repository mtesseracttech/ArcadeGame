using TimeGuardian.Entity;
using TimeGuardian.player;
using TimeGuardian.Entity.Enemy;

namespace TimeGuardian.Level
{
    class Level1 : LevelBase
    {
        DebugBall _testBall;

        public Level1(TimeGuardianGame game, int[] tiles, int levelNumber) : base(game, tiles, levelNumber)
        {
            Background = new Sprite(UtilStrings.SpritesLevel + "1/background.png");
            AddChild(Background);
            AddChild(Pause);
            Player = new Player (UtilStrings.SpritesPlayer + "spritesheetplayer_temp.png", 3, 8, 9, this, Game);
            Game = game;
            Tiles = tiles;
            AddChild(Player);
            _testBall = new DebugBall(this);
            Enemies.Add(_testBall);
            AddChild(_testBall);
			Player player = new Player (UtilStrings.SpritesPlayer + "spritesheet_hero.png", 8, 2, this);
            Game = game;
            Tiles = tiles;
			//create new enemy with ?? 10 ?? healthpoints and ?? 5 ?? damage
			BossBase eagleEnemy = new EagleEnemy (UtilStrings.SpritesEnemy + "spritesheet_enemy_2.png", 6, 1, 10, 5);
            AddChild(player);
			AddChild (eagleEnemy);

        }

        protected override void Update()
        {
            base.Update();
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
    }
}
