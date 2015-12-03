using System.Collections.Generic;
using TimeGuardian.Entity.Enemy;
using TimeGuardian.Entity.LevelEntities;
using TimeGuardian.Entity.Player;
using TimeGuardian.UI.Menu;
using TimeGuardian.Utility;

namespace TimeGuardian.Level
{
    abstract class LevelBase : GameObject
    {
        protected int[] Tiles;
        protected bool Paused;
        protected bool TimeStop;

        protected bool Finished = false;

        protected List<GameObject> Enemies;
        protected List<Background> Backgrounds;
        protected List<Wall> Walls;
        protected TimeGuardianGame Game;
        protected Player Player;
        protected Sprite[] Spritesheet;
        protected Sprite Background;
        protected Pause Pause;
        protected Sound Music;
        protected SoundChannel MusicChannel;

        private int _bottomPlayer;

        protected LevelBase(TimeGuardianGame game)
        {
            Game = game;
            Pause = new Pause(game, this);
            Enemies = new List<GameObject>();
            Backgrounds = new List<Background>();
            Walls = new List<Wall>();
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
            if (Input.GetKeyDown(ArcadeButtons.PLAYER1_BUTTON5)) PauseToggle();
            if (!Paused) UpdateUnpaused();
        }

        protected virtual void UpdateUnpaused()
        {
            if (!TimeStop) UpdateNoTimeStop();
        }

        protected virtual void UpdateNoTimeStop()
        {
            
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

        public void PauseToggle()
        {
            Paused = !Paused;
            Pause.Toggle();
        }

        public void StopMusic()
        {
            MusicChannel.Stop();
        }

        public void PauseMusic(bool pause)
        {
            MusicChannel.IsPaused = pause;
        }

        public abstract string GetLevelName();

        public abstract string GetNextLevelName();

        public TimeGuardianGame GetGame()
        {
            return Game;
        }

        public bool GetFinished()
        {
            return Finished;
        }

        public void SetFinished(bool finished)
        {
            Finished = finished;
        }
    }
}
