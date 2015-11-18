using TimeGuardian.Level;

namespace TimeGuardian.player
{
    class Player : AnimationSprite
    {
        private float _moveSpeed;
        private const float MaxMoveSpeed = 0.5f;

        private int _currentStaticFrame = 0;
        private int _currentMovingFrame = 0;

        private short[] _staticFrames = {0, 1, 2, 3, 4}; //All these sprite values are nonsense atm
        private short[] _movingFrames = {5, 6, 7, 8, 9}; //All these sprite values are nonsense atm
        private short[] _jumpFrames = {10, 11, 12, 13, 14}; //All these sprite values are nonsense atm

        public Player(string filename, int cols, int rows, LevelBase level, int frames = -1) : base(filename, cols, rows, frames)
        {
            
        }

        void Update()
        {
            
        }

        private void Movement()
        {
            if (_moveSpeed < MaxMoveSpeed && Input.GetKey(Key.W)) _moveSpeed += 0.01f;
            if (_moveSpeed > -MaxMoveSpeed && Input.GetKey(Key.S)) _moveSpeed -= 0.01f;
            if (_moveSpeed != 0.0f && !Input.GetKey(Key.W) && !Input.GetKey(Key.S)) _moveSpeed /= 1.01f;
            Move(0, -_moveSpeed);
        }

        private void SpriteHandler()
        {
            if (_moveSpeed > 0.1f || _moveSpeed < -0.1f) MovingSprite();
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

    }
}
