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
            //Background = new Sprite(UtilStrings.SpritesLevel + "1/background.png");
            //AddChild(Background);

            BackgroundCreator();
            Tiles = tiles;

            //AddChild(Pause);

            Player = new Player (4, this, Game);
            AddChild(Player);

            /*
            _testBall = new DebugBall(this);
            Enemies.Add(_testBall);
            AddChild(_testBall);
            */

			BossBase eagleEnemy = new EagleEnemy (6, 1, 10, 5, this);
			AddChild (eagleEnemy);


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
                background.Scroll(Player.GetXSpeed(), Player.GetYSpeed());
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
    }
}
