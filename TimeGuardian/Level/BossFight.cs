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

        public BossFight(Game game, int[] tiles, Player player, bool night, int levelNumber, string[] dialog, bool talking) : base(game, tiles, player, night, levelNumber)
        {
            Game = game;
            Dialog = dialog;
            Talking = talking;
            this.player = player;
        }

        abstract override protected void UpdateUnpaused();
    }
}
