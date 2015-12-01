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
        private int _glideDirection;

        private int[] _flyFrames = {1, 2, 3, 4, 5};
        private int[] _createFrames = {7, 8, 9, 10, 11, 12, 13};
        private int[] _defaultFrames = {0, 1, 2, 3, 4, 5};

        private int _currentDefaultFrame, _currentFlyFrame;

        public EnemyOwl(LevelBase level) : base(UtilStrings.SpritesEnemy + "/boss_2/spritesheet_boss_owl.png", 3, 4, 5, level)
        {
            SetOrigin(width/2, height/2);
            _state = 0;
        }

        private void Update()
        {
            if (Input.GetKeyDown(Key.Z)) { _state = 1;}

            switch (_state)
            {
                case 0: //Neutral state at beginning of meeting
                    SetXY(game.width / 2 + 100, game.height / 2 - 70);
                    break;
                case 1: //Flies Up to top of screen
                    MoveUp();
                    break;
                case 2: //
                    Glide(_glideDirection);
                    break;
                case 3: //Death state

                    break;
            }
        }

        private void MoveUp()
        {
            FlyFrames();
            rotation = -5;
            if (y > 0 - this.height) Move(0, -5);
            else
            {
                _glideDirection = Utils.Random(0, 2);
                if(_glideDirection == 1) SetXY(0,0);
                else SetXY(game.width, 0);
                _state = 2;
            }

        }

        private void Glide(int direction)
        {

        }

        private void DefaultFrames()
        {
            if (_currentDefaultFrame < _defaultFrames.Length * 10 - 1) _currentDefaultFrame++;
            else _currentDefaultFrame = 0;
            currentFrame = _defaultFrames[_currentDefaultFrame / 10];
        }

        private void FlyFrames()
        {
            if (_currentFlyFrame < _flyFrames.Length * 5 - 1) _currentFlyFrame++;
            else _currentFlyFrame = 0;
            currentFrame = _defaultFrames[_currentFlyFrame / 5];
        }
    }
}
