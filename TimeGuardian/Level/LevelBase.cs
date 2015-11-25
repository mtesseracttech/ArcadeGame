using System.Collections.Generic;
using TimeGuardian.Entity;
using TimeGuardian.player;
using TimeGuardian.UI.Menu;

namespace TimeGuardian.Level
{
    abstract class LevelBase : GameObject
    {
        protected int[] Tiles;
        protected bool Paused;
        protected bool TimeStop;


        protected List<GameObject> Enemies; 
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
            Enemies = new List<GameObject>();
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
            if (Input.GetKeyDown(Key.G))
            {
                DebugBall DBBall = new DebugBall(this);
                Enemies.Add(DBBall);
                AddChild(DBBall);
            }
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
            foreach (GameObject enemy in Enemies)
            {
                if (Player.HitTest(enemy))
                {
                    Player.LoseLife();
                    Player.SetXY(game.width/2, game.height/2);
                }
            }
        }

        public void SetTimeStop(bool timeStop)
        {
            TimeStop = timeStop;
            if (TimeStop) Background.color = 0x005555;
            else Background.color = 0xFFFFFF;
        }

        /*
        public void StopTimeToggle()
        {
            TimeStop = !TimeStop;
        }
        */
        public void PauseToggle()
        {
            Paused = !Paused;
            Pause.Toggle();
        }

        

        
    }
}
