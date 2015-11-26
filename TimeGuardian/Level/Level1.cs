using System.Collections.Generic;
using TimeGuardian.Entity;
using TimeGuardian.player;
using TimeGuardian.Entity.Enemy;

namespace TimeGuardian.Level
{
    class Level1 : LevelBase
    {
        //DebugBall _testBall;

        public Level1(TimeGuardianGame game) : base(game)
        {
            Game = game;
            //Background = new Sprite(UtilStrings.SpritesLevel + "1/background.png");
            //AddChild(Background);

            BackgroundCreator();

            //AddChild(Pause);

            LevelTiles tiles = new LevelTiles(1, this);
            Player = new Player (4, this, Game);
            AddChild(Player);

            /*
            _testBall = new DebugBall(this);
            Enemies.Add(_testBall);
            AddChild(_testBall);
            */

			//create new enemy with ?? 10 ?? healthpoints and ?? 5 ?? damage
			EagleEnemy eagleEnemy = new EagleEnemy (6, 1, 10, 5, this);

			AddChild (eagleEnemy);
			Enemies.Add (eagleEnemy.GetHitBox());




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
                background.Scroll(Player.GetXSpeed(), Player.GetYSpeed());
                //background.Scroll(Player.x, Player.y);
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
