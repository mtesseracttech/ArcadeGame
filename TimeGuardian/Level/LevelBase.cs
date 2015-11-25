using System.Collections.Generic;
using TimeGuardian.Entity;
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


        protected List<Sprite> Enemies; 
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
            Enemies = new List<Sprite>();
            AddChild(Pause);
            /*Spritesheet = CreateSpriteSheet(tiles, levelNumber);*/
        }

        
        protected virtual Sprite[] CreateSpriteSheet(int[] tiles, int levelNumber)
        {
            List<Sprite> spriteList = new List<Sprite>();
            for (int i = 0; i < tiles.Length; i++)
            {
                spriteList.Add(new Sprite(UtilStrings.LevelSprite(levelNumber, tiles[i])));
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

        public bool GetTimeStopped()
        {
            return TimeStop;
        }

        protected virtual void Update()
        {
            if (Input.GetKeyDown(Key.Q)) PauseToggle();
            if (!Paused) UpdateUnpaused();
        }

        protected virtual void UpdateUnpaused()
        {
            HitDetection();
            if (!TimeStop) UpdateUnpaused();
        }

        protected virtual void UpdateNoTimeStop()
        {
            
        }

        protected virtual void HitDetection()
        {
            foreach (Sprite enemy in Enemies)
            {
                if (Player.HitTest(enemy))
                {
                    Player.LoseLife();
                    AddChild(new DebugBall(this));
                }
            }
        }

        public void SetTimeStop(bool timeStop)
        {
            TimeStop = timeStop;
        }

        public void StopTimeToggle()
        {
            TimeStop = !TimeStop;
        }

        public void PauseToggle()
        {
            Paused = !Paused;
            Pause.Toggle();
        }

        

        
    }
}
