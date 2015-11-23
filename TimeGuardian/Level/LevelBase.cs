using System.Collections.Generic;
using TimeGuardian.player;
using TimeGuardian.UI.Menu;
using TimeGuardian.Utility;

namespace TimeGuardian.Level
{
    abstract class LevelBase : GameObject
    {
        protected int[] Tiles;

        protected bool Paused;
        protected bool TimeStop;

        protected TimeGuardianGame Game;
        protected Player Player;
        protected Sprite[] Spritesheet;
        protected Sprite Background;
        protected Pause Pause;

        public LevelBase(TimeGuardianGame game, int[] tiles, int levelNumber)
        {
            Game = game;
            Tiles = tiles;
            Pause = new Pause(game);
            AddChild(Pause);

            /*Spritesheet = CreateSpriteSheet(tiles, levelNumber);*/
        }

        
        protected virtual Sprite[] CreateSpriteSheet(int[] tiles, int levelNumber)
        {
            List<Sprite> spriteList = new List<Sprite>();
            for (int i = 0; i < tiles.Length; i++)
            {
                spriteList.Add(new Sprite(UtilStrings.levelSprite(levelNumber, tiles[i])));
            }
            return spriteList.ToArray();
        }
        

        public Player GetPlayer()
        {
            return Player;
        }

        public bool GetPaused()
        {
            return Paused;
        }

        void Update()
        {
            if (!Paused) UpdateUnpaused();
        }

        protected virtual void UpdateUnpaused()
        {
            if (!TimeStop) UpdateUnpaused();
        }

        protected virtual void UpdateNoTimeStop()
        {
            
        }

        protected virtual void HitDetection()
        {
            //Add General Hitdetection
        }

        public void PauseToggle()
        {
            Paused = !Paused;
            Pause.Toggle();
        }

        
    }
}
