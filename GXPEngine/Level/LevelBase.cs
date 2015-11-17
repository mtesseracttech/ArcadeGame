namespace GXPEngine.Level
{
    abstract class LevelBase : GameObject
    {
        protected int[] Tiles;
        protected Game Game;

        public LevelBase(Game game, int[] tiles)
        {
            Game = game;
            Tiles = tiles;
        }

        void Update()
        {
            HitDetection();
        }

        void HitDetection()
        {
            //TODO Implement Hit Detection
        }
    }
}
