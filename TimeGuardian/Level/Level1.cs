using TimeGuardian.Entity;
using TimeGuardian.player;
using TimeGuardian.Entity.Enemy;

namespace TimeGuardian.Level
{
    class Level1 : LevelBase
    {
        public Level1(TimeGuardianGame game, int[] tiles, int levelNumber) : base(game, tiles, levelNumber)
        {
            Background = new Sprite(UtilStrings.SpritesLevel + "1/background.png");
            AddChild(Background);
            AddChild(Pause);
			Player player = new Player (UtilStrings.SpritesPlayer + "spritesheet_hero.png", 8, 2, this);
            Game = game;
            Tiles = tiles;
			//create new enemy with ?? 10 ?? healthpoints and ?? 5 ?? damage
			BossBase eagleEnemy = new EagleEnemy (UtilStrings.SpritesEnemy + "spritesheet_enemy_2.png", 6, 1, 10, 5);
            AddChild(player);
			AddChild (eagleEnemy);

           // AddChild(new DebugBall(this));

        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void UpdateUnpaused()
        {
            
        }

        protected override void UpdateNoTimeStop()
        {
            
        }
    }
}
