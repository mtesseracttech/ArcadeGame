using System.Runtime.Remoting.Messaging;
using TimeGuardian.Level;

namespace TimeGuardian.player
{
    class Player : AnimationSprite
    {
        private LevelBase _level;
//        private GameObject _feet;
        private float _walkSpeed, _jumpSpeed;
//        private const float MaxMoveSpeed = 0.5f;
//
        private int _jumpCounter, _jumpTimer;
//        private int _currentStaticFrame, _currentMovingFrame, _currentJumpingFrame;
//
//		private short[] _staticFrames = {8, 9, 10}; //TODO: Set to actual sprite values
//		private short[] _movingFrames = {0, 1, 2, 3, 4, 5, 6, 7};//TODO: Set to actual sprite values
//        private short[] _jumpFrames = {11, 12, 13, 14}; //TODO: Set to actual sprite values

		private int _firstFrame = 0, _lastFrame = 0;
		private float _frame = 0.0f;

        public Player(LevelBase level) : base(UtilStrings.SpriteDebug, 1, 1)
        {
			SetXY(100, 500);
            _level = level;
        }

        public Player(string filename, int cols, int rows, LevelBase level) : base(filename, cols, rows)
        {
            SetXY(100, 500);
            _level = level;
        }


        void Update()
        {
            Movement();
			UpdateAnimation ();
        }

        private void Movement()
        {
			//MovingSprite ();

			if(Input.GetKey(Key.LEFT) || Input.GetKey(Key.RIGHT) || Input.GetKey(Key.SPACE)){
				SetAnimationRange (0, 7);
				if(Input.GetKey(Key.LEFT)) { x -= 5; Mirror (true, false); }
				if(Input.GetKey(Key.RIGHT)) { x += 5; Mirror (false, false); }
				if (IsOnSolidGround()) _jumpCounter = 0;
				if(Input.GetKey(Key.SPACE) && _jumpCounter < 2) { 
					_jumpCounter++;
					_jumpTimer = 20;
	               // _jumpSpeed = 1.0f;
				}
				//if (_jumpSpeed != 0.0f) _jumpSpeed /= 1.01f;
				if(_jumpTimer > 0){
					_jumpTimer -= 1;
					y -= 5;
					if (IsOnSolidGround ())
						_jumpSpeed = 0;
				}
				if(_jumpTimer==0) {
					while(IsOnSolidGround()==false){
						y += 5;
					}	
				}
					
				
			}
			else{
				SetAnimationRange (8, 10);
			}
				

//            if (_walkSpeed < MaxMoveSpeed && Input.GetKey(Key.D)) _walkSpeed += 0.01f;
//            if (_walkSpeed > -MaxMoveSpeed && Input.GetKey(Key.A)) _walkSpeed -= 0.01f;
//            if (_walkSpeed != 0.0f && !Input.GetKey(Key.D) && !Input.GetKey(Key.A)) _walkSpeed /= 1.02f;
//            if (IsOnSolidGround()) _jumpCounter = 0;
//            if (Input.GetKeyDown(Key.SPACE) && _jumpCounter < 2)
//            {
//                _jumpCounter++;
//                _jumpSpeed = 1.0f;
//            }
//            if (_jumpSpeed != 0.0f) _jumpSpeed /= 1.01f;
//            Move(_walkSpeed, 0);
        }

//        private GameObject Bottom()
//        {
//            
//        }

		private void SetAnimationRange(int first, int last){
			_firstFrame = first;
			_lastFrame = last;
		}
//
//        private void SpriteHandler()
//        {
//            if(_jumpSpeed > 0.1f || _jumpSpeed < -0.1f) JumpingSprite();
//            else if (_walkSpeed > 0.1f || _walkSpeed < -0.1f) MovingSprite();
//            else StaticSprite();
//        }
//
//        private void MovingSprite()
//        {
//            if (_currentMovingFrame < _movingFrames.Length * 100 - 1) _currentMovingFrame++;
//            else _currentMovingFrame = 0;
//            currentFrame = _movingFrames[_currentMovingFrame / 100];
//        }
//
//        private void StaticSprite()
//        {
//            if (_currentStaticFrame < _staticFrames.Length * 100 - 1) _currentStaticFrame++;
//            else _currentStaticFrame = 0;
//            currentFrame = _staticFrames[_currentStaticFrame / 100];
//        }
//
//        private void JumpingSprite()
//        {
//            //The frame of the jump can be decided by looking at the vertical speed of the player
//            if (_jumpSpeed > 0.5f) _currentJumpingFrame = _jumpFrames[0];
//            else if(_jumpSpeed > 0.0f) _currentJumpingFrame = _jumpFrames[1];
//            else if(_jumpSpeed > -0.5f) _currentJumpingFrame = _jumpFrames[2];
//            else _currentJumpingFrame = _jumpFrames[3];
//        }

		void UpdateAnimation()
		{
			_frame += 0.2f;
			if (_frame > _lastFrame + 1)
				_frame = _firstFrame;
			if (_frame < _firstFrame)
				_frame = _lastFrame;
			SetFrame ((int)_frame);
		}

        private bool IsOnSolidGround()
        {
			if(y==500)return true;
			else {return false;}//TODO: Change value based 
        }
    }
}
