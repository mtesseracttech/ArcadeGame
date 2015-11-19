using System.Runtime.Remoting.Messaging;
using TimeGuardian.Level;

namespace TimeGuardian.player
{
    class Player : AnimationSprite
    {
        private LevelBase _level;

        private float _walkSpeed, _jumpSpeed;
        private const float MaxMoveSpeed = 1.0f;

        private int _currentStaticFrame, _currentMovingFrame, _currentJumpingFrame;

        private short[] _staticFrames = {0, 1, 2, 3, 4}; //TODO: Set to actual sprite values
        private short[] _movingFrames = {5, 6, 7, 8, 9}; //TODO: Set to actual sprite values
        private short[] _jumpFrames = {10, 11, 12, 13, 14}; //TODO: Set to actual sprite values

        public Player() : base(UtilStrings.SpriteDebug, 1, 1)
        {

        }

        public Player(string filename, int cols, int rows, LevelBase level, int frames = -1) : base(filename, cols, rows, frames)
        {
            filename = UtilStrings.SpriteDebug;
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
            if (_walkSpeed != 0.0f && !Input.GetKey(Key.W) && !Input.GetKey(Key.S)) _walkSpeed /= 1.02f;

            if(IsOnSolidGround())

            Move(_walkSpeed, 0);
        }

        private void SpriteHandler()
        {
            if (_walkSpeed > 0.1f || _walkSpeed < -0.1f) MovingSprite();
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
            //This one should be called when the player is not touching the ground.
            //The frame of the jump can be decided by looking at the falling speed of the player
        }

        private bool IsOnSolidGround()
        {
            return true; //TODO: Change value based 
        }
    }
}
