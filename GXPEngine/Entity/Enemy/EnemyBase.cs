using GXPEngine.Level;

namespace GXPEngine.Enemy
{
    abstract class EnemyBase : AnimationSprite
    {
        public EnemyBase(string filename, int cols, int rows, LevelBase level, int frames = -1) : base(filename, cols, rows, frames)
        {
            
        }
    }
}
