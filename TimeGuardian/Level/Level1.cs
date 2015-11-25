using TimeGuardian.Entity;
using TimeGuardian.player;

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
