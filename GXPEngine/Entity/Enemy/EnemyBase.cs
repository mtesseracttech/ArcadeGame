using GXPEngine.Level;

namespace GXPEngine.Enemy
{
    abstract class EnemyBase : AnimationSprite
    {
        protected LevelBase Level;
        public EnemyBase(string filename, int cols, int rows, LevelBase level, int frames = -1) : base(filename, cols, rows, frames)
        {
            Level = level;
        }

        private void Update()
        {
            if (!Level.GetPause()) UpdateUnpaused();
        }

        protected abstract void UpdateUnpaused();
    }
}
