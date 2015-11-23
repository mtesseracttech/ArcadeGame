using TimeGuardian.Level;

namespace TimeGuardian.Enemy
{
    abstract class EnemyBase : AnimationSprite
    {
        protected LevelBase Level;
        public EnemyBase(string filename, int cols, int rows, LevelBase level, int frames = -1) : base(filename, cols, rows, frames)
        {
            Level = level;
        }

        protected abstract void UpdateUnpaused();
    }
}
