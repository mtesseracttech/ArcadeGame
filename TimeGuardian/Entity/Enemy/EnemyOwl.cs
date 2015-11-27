using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeGuardian.Level;

namespace TimeGuardian.Entity.Enemy
{
    class EnemyOwl : BossBase
    {
        private int[] _createFrames = {7, 8, 9, 10, 11, 12, 13};
        private int[] _defaultFrames = {0, 1, 2, 3, 4, 5};

        private int _currentDefaultFrame;

        public EnemyOwl(LevelBase level) : base(UtilStrings.SpritesEnemy + "/boss_2/spritesheet_boss_owl.png", 3, 4, 5, level)
        {
            
        }

        private void DefaultFrames()
        {
            if (_currentDefaultFrame < _defaultFrames.Length * 20 - 1) _currentDefaultFrame++;
            else _currentDefaultFrame = 0;
            currentFrame = _defaultFrames[_currentDefaultFrame / 20];
        }
    }
}
