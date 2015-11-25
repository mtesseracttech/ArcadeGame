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
            Game = game;
            Background = new Sprite(UtilStrings.SpritesLevel + "1/background.png");
            AddChild(Background);
            Tiles = tiles;
            AddChild(Pause);
            Player = new Player (4, this, Game);

            AddChild(Player);
            _testBall = new DebugBall(this);
            Enemies.Add(_testBall);
            AddChild(_testBall);
			//create new enemy with ?? 10 ?? healthpoints and ?? 5 ?? damage
			BossBase eagleEnemy = new EagleEnemy (6, 1, 10, 5, this);
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
