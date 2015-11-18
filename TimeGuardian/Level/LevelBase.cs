using TimeGuardian.player;

namespace TimeGuardian.Level
{
    abstract class LevelBase : GameObject
    {
        protected int[] Tiles;

        protected bool Paused;
        protected bool Night;

        protected Game Game;
        protected Player Player;
        private Sprite Spritesheet;

        public LevelBase(Game game, int[] tiles, Player player, bool night, Sprite spritesheet)
        {
            Game = game;
            Tiles = tiles;
            Player = player;
            Night = night;
            Spritesheet = spritesheet;
        }

        void Update()
        {
            if (!Paused) UpdateUnpaused();
        }

        abstract protected void UpdateUnpaused();

        void HitDetection()
        {
        }

        public void SetPause(bool paused)
        {
            Paused = paused;
        }

        public bool GetPause()
        {
            return Paused;
        }

        public void SetNight(bool night)
        {
            Night = night;
        }

        public bool GetNight()
        {
            return Night;
        }
    }
}
