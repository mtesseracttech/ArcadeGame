using System.Collections.Generic;
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

			//create new enemy with ?? 10 ?? healthpoints and ?? 5 ?? damage
			EagleEnemy eagleEnemy = new EagleEnemy (6, 1, 10, 5, this);
			AddChild (eagleEnemy);
			Enemies.Add (eagleEnemy.GetHitBox());



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
