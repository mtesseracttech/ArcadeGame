using TimeGuardian.player;

namespace TimeGuardian.Level
{
    class Level1 : LevelBase
    {
        private Player _player;
        public Level1(TimeGuardianGame game, int[] tiles, Player player, int levelNumber) : base(game, tiles, player, levelNumber)
        {
            Game = game;
            Tiles = tiles;
            _player = player;
            AddChild(player);
        }





        protected override void UpdateUnpaused()
        {
            
        }
    }
}
