using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Player : AnimationSprite
    {
        private float _frame = 0.0f;
        private float _velocityX = 0.0f;
        private float _velocityY = 8.0f;
        private bool right = true;
        private bool left = false;
        private bool facesDirection = true;


        public Player() : base("../res/img/mario_sprite.png", 3, 1, 7)
        {

            SetOrigin(-height, width/2);

            x = 100;
            y = 100;


        }

        private void Update()
        {

            if (Input.GetKey(Key.A))
            {
                facesDirection = left; //make hook for switching direction sprite
                if (Input.GetKey(Key.LEFT_SHIFT))
                {
                    if (_velocityX > -4)
                    {
                        _velocityX -= 0.1f;
                    }
                }
                else
                {
                    if (_velocityX > -2)
                    {
                        _velocityX -= 0.05f;
                    }
                }
                _frame += 0.05f;
                if (_frame > 6.0f) _frame = 0.0f;
                SetFrame((int)_frame);

            }

            if (Input.GetKey(Key.D))
            {
                facesDirection = right; //make hook for switching direction sprite
                if (Input.GetKey(Key.LEFT_SHIFT))
                {
                    if (_velocityX < 4)
                    {
                        _velocityX += 0.1f;
                    }
                }
                else
                {
                    if (_velocityX < 2)
                    {
                        _velocityX += 0.05f;
                    }
                }
                _frame += 0.05f;
                if (_frame > 6.0f) _frame = 0.0f;
                SetFrame((int)_frame);
            }


            if ((_velocityX != 0.0f) && !Input.GetKey(Key.D) && !Input.GetKey(Key.A))
            {
                if (_velocityX > 0)
                {
                    _velocityX -= 0.1f;
                }
                if (_velocityX < 0)
                {
                    _velocityX += 0.1f;
                }
            }

            x += _velocityX;



            if (Input.GetKeyDown(Key.SPACE)) Jump();
            ApplyGravity();
        }

        private void Jump()
        {
            _velocityY = -10;
        }

        private void ApplyGravity()
        {
            y = y + _velocityY;
            _velocityY = _velocityY + 0.1F;
            if (y > game.height -this.height/2)
            {
                this.y = game.height - this.height/2;
                _velocityY = 0.0f;
            }


        }
    }
}
