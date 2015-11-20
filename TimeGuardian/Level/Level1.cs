using TimeGuardian.player;

namespace TimeGuardian.Level
{
    class Level1 : LevelBase
    {
        public Level1(TimeGuardianGame game, int[] tiles, int levelNumber) : base(game, tiles, levelNumber)
        {
            //Player = new Player(this);

			Player player = new Player (UtilStrings.SpritesPlayer +"spritesheet_player_2.png", 8, 2, this);

            Game = game;
            Tiles = tiles;
            AddChild(player);
        }





        protected override void UpdateUnpaused()
        {
            
        }
    }
}
