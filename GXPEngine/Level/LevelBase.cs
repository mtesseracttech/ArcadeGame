using GXPEngine.player;

namespace GXPEngine.Level
{
    abstract class LevelBase : GameObject
    {
        protected int[] Tiles;
        protected Game Game;
        protected bool Paused;
        protected Player Player;

        public LevelBase(Game game, int[] tiles, Player player)
        {
            Game = game;
            Tiles = tiles;
            Player = player;
        }

        void Update()
        {
            if (!Paused) UpdateUnpaused();
        }

        abstract protected void UpdateUnpaused();

        void HitDetection()
        {
        }

        protected void SetPause(bool paused)
        {
            Paused = paused;
        }

        protected bool GetPause()
        {
            return Paused;
        }
    }
}
