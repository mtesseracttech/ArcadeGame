using System;
using TimeGuardian.Entity.Enemy;
using TimeGuardian.player;

namespace TimeGuardian.Level
{
    abstract class BossFight : LevelBase
    {
        protected string[] Dialog;
        protected bool Talking; //Blocks the update as long as the pre-battle conversation is going on
        protected Player player;

        public BossFight(Game game, int[] tiles, Player player, bool night, Sprite spritesheet) : base(game, tiles, player, night, spritesheet)
        {
            Game = game;
            Tiles = tiles;
            Player = player;
        }

        abstract override protected void UpdateUnpaused();
    }
}
