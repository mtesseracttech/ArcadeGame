using TimeGuardian.player;

namespace TimeGuardian.Level
{
    class Level1 : LevelBase
    {
        public Level1(TimeGuardianGame game, int[] tiles, int levelNumber) : base(game, tiles, levelNumber)
        {
            Player = new Player(this);
            Game = game;
            Tiles = tiles;
            AddChild(Player);
        }





        protected override void UpdateUnpaused()
        {
            
        }
    }
}
