﻿using System.Collections.Generic;
using TimeGuardian.player;
using TimeGuardian.Utility;

namespace TimeGuardian.Level
{
    abstract class LevelBase : GameObject
    {
        protected int[] Tiles;

        protected bool Paused;
        protected bool Night;

        protected Game Game;
        protected Player Player;
        protected Sprite[] Spritesheet;

        public LevelBase(Game game, int[] tiles, Player player, bool night, int levelNumber)
        {
            Game = game;
            Tiles = tiles;
            Player = player;
            Night = night;
            Spritesheet = CreateSpriteSheet(tiles, levelNumber);
        }

        protected virtual Sprite[] CreateSpriteSheet(int[] tiles, int levelNumber)
        {
            List<Sprite> spriteList = new List<Sprite>();
            for (int i = 0; i < tiles.Length; i++)
            {
                spriteList.Add(new Sprite(UtilStrings.levelSprite(levelNumber, i)));
            }
            return spriteList.ToArray();
        }


        void Update()
        {
            if (!Paused) UpdateUnpaused();
        }

        abstract protected void UpdateUnpaused();

        protected virtual void HitDetection()
        {
            //Add General Hitdetection
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
