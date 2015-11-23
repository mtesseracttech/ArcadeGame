using TimeGuardian.Entity;
using TimeGuardian.player;

namespace TimeGuardian.Level
{
    class Level1 : LevelBase
    {
        public Level1(TimeGuardianGame game, int[] tiles, int levelNumber) : base(game, tiles, levelNumber)
        {
            Background = new Sprite(UtilStrings.SpritesLevel + "1/background.png");
            AddChild(Background);
            AddChild(Pause);
            Player = new Player (UtilStrings.SpritesPlayer + "spritesheetplayer_temp.png", 8, 9, this);
            Game = game;
            Tiles = tiles;
            AddChild(Player);

            AddChild(new DebugBall(this));

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
