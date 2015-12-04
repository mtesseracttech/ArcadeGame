using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeGuardian.Entity.LevelEntities;
using TimeGuardian.Level;

namespace TimeGuardian.Entity.Enemy.Summons
{
    class EnemyGoo : AnimationSprite
    {
        private LevelBase _level;

        private const float MaxYSpeed = 6.0f;
        private float _ySpeed;
        private float _xSpeed;

        private bool _isGrounded;

        public EnemyGoo(LevelBase level) : base(UtilStrings.SpritesEnemy + "summons/spritesheet_goo.png", 5, 2)
        {
            _level = level;
            SetDirection();
        }

        private void SetDirection()
        {
            if (Utils.Random(0, 2) == 0) _xSpeed = 5;
            else _xSpeed = -5;
        }

        void Update()
        {
            if (!_isGrounded && _ySpeed > -MaxYSpeed) _ySpeed -= 0.5f;
            move(_xSpeed, _ySpeed);
        }

        private void move(float moveX, float moveY)
        {
            x = x + moveX;
            y = y + moveY;

            foreach (Sprite wall in GetCollisions())
            {
                if (wall is Wall)
                {
                    if (moveY > 0)
                    {
                        y = Mathf.Min(wall.y - height, y); //at top of block
                        _isGrounded = true;
                        _ySpeed = 0f;
                    }
                    if (moveY < 0)
                    {
                        y = Mathf.Max(wall.y + wall.height, y); //at bottom of block
                        _isGrounded = true;
                        _ySpeed = 0f;
                    }
                }
                else
                {
                    _isGrounded = false;
                }
            }
        }
    }
}
