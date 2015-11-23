using TimeGuardian.player;

namespace TimeGuardian.Level
{
    class Level1 : LevelBase
    {
        public Level1(TimeGuardianGame game, int[] tiles, int levelNumber) : base(game, tiles, levelNumber)
        {
            Sprite background = new Sprite(UtilStrings.SpritesLevel + "1/background.png");
            AddChild(background);
            //Player = new Player(this);
            Player player = new Player (UtilStrings.SpritesPlayer + "spritesheetplayer_temp.png", 8, 9, this);
            Game = game;
            Tiles = tiles;
            AddChild(player);

        }





        protected override void UpdateUnpaused()
        {
            
        }
    }
}
