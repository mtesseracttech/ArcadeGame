using TimeGuardian.player;

namespace TimeGuardian.Level
{
    class Level1 : LevelBase
    {
        public Level1(Game game, int[] tiles, Player player, bool night, int levelNumber) : base(game, tiles, player, night, levelNumber)
        {
            Game = game;
            Tiles = tiles;
        }

        protected override void UpdateUnpaused()
        {
            
        }
    }
}
