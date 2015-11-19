using System.Runtime.Remoting.Messaging;
using TimeGuardian.Level;

namespace TimeGuardian.player
{
    class Player : AnimationSprite
    {
        private LevelBase _level;
        private GameObject _feet;
        private float _walkSpeed, _jumpSpeed;
        private const float MaxMoveSpeed = 1.0f;

        private int _jumpCounter;
        private int _currentStaticFrame, _currentMovingFrame, _currentJumpingFrame;

        private short[] _staticFrames = {0, 1, 2, 3, 4}; //TODO: Set to actual sprite values
        private short[] _movingFrames = {5, 6, 7, 8, 9}; //TODO: Set to actual sprite values
        private short[] _jumpFrames = {10, 11, 12, 13, 14}; //TODO: Set to actual sprite values

        public Player(LevelBase level) : base(UtilStrings.SpriteDebug, 1, 1)
        {
            SetXY(100, 100);
            _level = level;
        }

        public Player(string filename, int cols, int rows, LevelBase level) : base(filename, cols, rows)
        {
            SetXY(100, 100);
            _level = level;
        }



        void Update()
        {
            Movement();
        }

        private void Movement()
        {
            
            if (_walkSpeed < MaxMoveSpeed && Input.GetKey(Key.D)) _walkSpeed += 0.01f;
            if (_walkSpeed > -MaxMoveSpeed && Input.GetKey(Key.A)) _walkSpeed -= 0.01f;
            if (_walkSpeed != 0.0f && !Input.GetKey(Key.D) && !Input.GetKey(Key.A)) _walkSpeed /= 1.02f;
            if (IsOnSolidGround()) _jumpCounter = 0;
            if (Input.GetKeyDown(Key.SPACE) && _jumpCounter < 2)
            {
                _jumpCounter++;
                _jumpSpeed = 1.0f;
            }
            if (_jumpSpeed != 0.0f) _jumpSpeed /= 1.01f;
            Move(_walkSpeed, 0);
        }

        private GameObject Bottom()
        {
            
        }

        private void SpriteHandler()
        {
            if(_jumpSpeed > 0.1f || _jumpSpeed < -0.1f) JumpingSprite();
            else if (_walkSpeed > 0.1f || _walkSpeed < -0.1f) MovingSprite();
            else StaticSprite();
        }

        private void MovingSprite()
        {
            if (_currentMovingFrame < _movingFrames.Length * 100 - 1) _currentMovingFrame++;
            else _currentMovingFrame = 0;
            currentFrame = _movingFrames[_currentMovingFrame / 100];
        }

        private void StaticSprite()
        {
            if (_currentStaticFrame < _staticFrames.Length * 100 - 1) _currentStaticFrame++;
            else _currentStaticFrame = 0;
            currentFrame = _staticFrames[_currentStaticFrame / 100];
        }

        private void JumpingSprite()
        {
            //The frame of the jump can be decided by looking at the vertical speed of the player
            if (_jumpSpeed > 0.5f) _currentJumpingFrame = _jumpFrames[0];
            else if(_jumpSpeed > 0.0f) _currentJumpingFrame = _jumpFrames[1];
            else if(_jumpSpeed > -0.5f) _currentJumpingFrame = _jumpFrames[2];
            else _currentJumpingFrame = _jumpFrames[3];
        }

        private bool IsOnSolidGround()
        {
            return true; //TODO: Change value based 
        }
    }
}
