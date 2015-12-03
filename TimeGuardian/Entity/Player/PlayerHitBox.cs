using TimeGuardian.Entity.Player;

namespace TimeGuardian.Entity.Player
{
    class PlayerHitBox : Sprite
    {
        private Player _player;

        public PlayerHitBox(string filename, Player player) : base(filename)
        {
            _player = player;
        }

        public Player GetPlayer()
        {
            return _player;
        }
    }
}
