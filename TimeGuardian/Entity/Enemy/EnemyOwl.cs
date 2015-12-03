﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeGuardian.Core;
using TimeGuardian.Level;
using TimeGuardian.player;

namespace TimeGuardian.Entity.Enemy
{
    class EnemyOwl : BossBase
    {
        private int _state;
        private LevelBase _level;

        private int _staticCounter;

        private int[] _flyFrames = {1, 2, 3, 4, 5};
        private int[] _deathFrames = {1, 2, 3, 4, 5};

        private int _currentFlyFrame;

        public EnemyOwl(LevelBase level) : base(UtilStrings.SpritesEnemy + "/boss_2/spritesheet_boss_owl.png", 3, 4, 5, level)
        {
            SetOrigin(width/2, height/2);
            SetXY(game.width/2 +100, game.height/2 -70);
            _level = level;
            _state = 0;
        }

        protected override void UpdateNoTimeStop()
        {
            if (Input.GetKeyDown(Key.Z)) { _state = 1; }

            switch (_state)
            {
                case 0: //Neutral state at beginning of meeting
                    _staticCounter++;
                    if (_staticCounter > 50)
                    {
                        _staticCounter = 0;
                        _state = 1;
                    }
                    break;
                case 1: //Flies Up to top of screen after meeting
                    MoveUp(5);
                    break;
                case 2: //Glides down to player
                    Glide();
                    break;
                case 3: //Flies up quickly for new attack
                    MoveUp(14);
                    break;
                case 4: //Death state

                    break;
            }

            SideReturn();
        }

        private void SideReturn()
        {
            if (x < 0 - width || x > game.width + width || y > game.height + height)
            {
                rotation = Utils.Random(-10, 10);
                color = 0xFFAAAA;
                alpha = 0.7f;
                Vurnerable = true;
                _state = 1;
            }
        }


        private void MoveUp(int speed)
        {
            Mirror(false, false);
            
            FlyFrames();
            if (y > 0 - height) Move(0, -speed);
            else
            {
                if (Utils.Random(0, 2) == 1)
                {
                    Mirror(false, true);
                    SetXY(0, -height);
                }
                else
                {
                    SetXY(game.width, -this.height);
                }
                AimAtPlayer();
                Vurnerable = false;
                color = 0xFFFFFF;
                alpha = 1;
                _state = 2;
            }

            if (HitTest(Level.GetPlayer()))
            {
                _state = 1;
            }

        }

        private void AimAtPlayer()
        {
            Player player = _level.GetPlayer();
            float deltaX = this.x - player.x;
            float deltaY = this.y - player.y;
            rotation = (Mathf.Atan2(deltaY, deltaX) * 180) / Mathf.PI;
        }

        private void Glide()
        {
            currentFrame = 6;
            Move(-20, 0);
        }

        private void FlyFrames()
        {
            if (_currentFlyFrame < _flyFrames.Length * 5 - 1) _currentFlyFrame++;
            else _currentFlyFrame = 0;
            currentFrame = _flyFrames[_currentFlyFrame / 5];
        }
    }
}
