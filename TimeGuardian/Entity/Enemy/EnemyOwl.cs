using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeGuardian.Core;
using TimeGuardian.Level;

namespace TimeGuardian.Entity.Enemy
{
    class EnemyOwl : BossBase
    {
        private int _state;

        

        private int[] _createFrames = {7, 8, 9, 10, 11, 12, 13};
        private int[] _defaultFrames = {0, 1, 2, 3, 4, 5};

        private int _currentDefaultFrame;

        public EnemyOwl(LevelBase level) : base(UtilStrings.SpritesEnemy + "/boss_2/spritesheet_boss_owl.png", 3, 4, 5, level)
        {
            SetOrigin(width/2, height/2);
            SetXY(game.width/2, game.height/2);
        }

        private void Update()
        {
            switch (_state)
            {
                case 0: //Neutral state at beginning of meeting
                    break;
                case 1: //
                    break;
                case 2: //
                    break;
                case 3: //Death state
                    break;
            }
        }

        private void DefaultFrames()
        {
            if (_currentDefaultFrame < _defaultFrames.Length * 20 - 1) _currentDefaultFrame++;
            else _currentDefaultFrame = 0;
            currentFrame = _defaultFrames[_currentDefaultFrame / 20];
        }
    }
}
