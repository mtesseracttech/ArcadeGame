using System.Collections.Generic;
using TimeGuardian.Entity;
using TimeGuardian.Entity.LevelEntities;
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
        protected List<Background> Backgrounds;
        protected List<Wall> Walls;
        protected TimeGuardianGame Game;
        protected Player Player;
        protected Sprite[] Spritesheet;
        protected Sprite Background;
        protected Pause Pause;

		private int _bottomPlayer;

        protected LevelBase(TimeGuardianGame game)
        {
            Game = game;
            Pause = new Pause(game, this);
            Enemies = new List<GameObject>();
            Backgrounds = new List<Background>();
            Walls = new List<Wall>();
            //AddChild(Pause);
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
            if (!Player.IsDead() && !Player.IsInvincible()) PlayerHitDetection();
        }

        protected virtual void PlayerHitDetection()
        {
            foreach (GameObject enemy in Enemies)
            {
                if (Player.HitTest(enemy))
                {
                    _bottomPlayer = Player.DefineFeet();
                    if (_bottomPlayer < enemy.y)
                    {
                        enemy.Destroy();

                    }
                    else if (_bottomPlayer > enemy.y)
                    {
                        Player.LoseLife();
                        Player.Bounce();
                    }
                }
            }
        }

		protected virtual void HitDetectAbove()
		{
			foreach(GameObject enemy in Enemies)
			{
				//when player hits the top of the sprite, from above.
				//bottom of the player
				//has to be higher then the top of the boss in order to hit him
				if(Player.HitTest(enemy))
				{
					_bottomPlayer = Player.DefineFeet ();
					if(_bottomPlayer < enemy.y)
					{
						enemy.Destroy ();
					}
					else if(_bottomPlayer > enemy.y)
					{ 
						Player.LoseLife ();
						Player.SetXY (100, 500);
					}
				}
			}	
		}

        public void SetTimeStop(bool timeStop)
        {
            TimeStop = timeStop;

            if (TimeStop)
            {
                foreach (Background background in Backgrounds)
                {
                    background.color = 0x005555;
                }
            }
            else
            {
                foreach (Background background in Backgrounds)
                {
                    background.color = 0xFFFFFF;
                }
            }



                
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

        public abstract string GetLevelName();

    }
}
