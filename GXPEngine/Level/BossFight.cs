using GXPEngine.Entity.Enemy;
using GXPEngine.player;

namespace GXPEngine.Level
{
    abstract class BossFight : LevelBase
    {
        public BossFight(Game game, int[] tiles, Player player, BossBase boss, bool night) : base(game, tiles, player, night)
        {

        }

        abstract override protected void UpdateUnpaused();
    }
}
