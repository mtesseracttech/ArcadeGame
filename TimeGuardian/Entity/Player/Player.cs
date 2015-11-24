using System.Drawing.Text;
using System.Runtime.Remoting.Messaging;
using TimeGuardian.Level;
using TimeGuardian.UI;
using TimeGuardian.UI.HUD;
using TimeGuardian.Entity.Enemy;

namespace TimeGuardian.player
{
    class Player : AnimationSprite
    {
        private LevelBase _level;
        private Heart _heart;
        private float _walkSpeed, _jumpSpeed;
        private const float MaxMoveSpeed = 2.0f;

        private int _jumpCounter;
        private int _currentStaticFrame, _currentMovingFrame, _currentJumpingFrame;

  		private short[] _staticFrames = {0}; //TODO: Set to actual sprite values
		private short[] _movingFrames = {0,1,2,3,4,5,6,7};//TODO: Set to actual sprite values
        private short[] _jumpFrames = {8,9,10,11,12}; //TODO: Set to actual sprite values

        private HUD _hud;
		private bool _arcadeMachineControls;

        public Player(string filename, int cols, int rows, LevelBase level) : base(filename, cols, rows)
        {
            SetXY(100, 500);
            _level = level;
            _heart = new Heart(100, 100);
            _hud = new HUD(3, _level);
        }


        void Update()
        {
            //for testing purposes only
			if(Input.GetKeyDown(Key.E)) _level.FreezeTimeToggle();
            //if (Input.GetKeyDown(Key.B)) _hud.LoseHeart();
            //if (Input.GetKeyDown(Key.C)) _hud.AddHeart();
            if(!_level.GetPaused()) UpdateUnpaused();
        }

        void UpdateUnpaused()
        {
            Movement();
            SpriteHandler();
        }

        private void Movement()
		{
			//change here wether we play on pc/laptop or arcade
			_arcadeMachineControls = false;
			if (_arcadeMachineControls == false) {

				if (_walkSpeed < MaxMoveSpeed && Input.GetKey (Key.D)) {
					_walkSpeed += 0.01f;
					Mirror (false, false);
				}
				if (_walkSpeed > -MaxMoveSpeed && Input.GetKey (Key.A)) {
					_walkSpeed -= 0.01f;
					Mirror (true, false);
				}
				if (_walkSpeed != 0.0f && !Input.GetKey (Key.D) && !Input.GetKey (Key.A))
					_walkSpeed /= 1.02f;
				if (IsOnSolidGround ())
					_jumpCounter = 0;
				if (Input.GetKeyDown (Key.SPACE) && _jumpCounter < 2) {
					_jumpCounter++;
					_jumpSpeed = 1.0f;
				}
				if (_jumpSpeed != 0.0f)
					_jumpSpeed -= 0.01f;
				Move (_walkSpeed, -_jumpSpeed);
			}
			if(_arcadeMachineControls == true){
				//arcademachine controls are in here
			}
				//makes it so you cannot walk beyond the borders of the screen
				if (x < 0)
					x = 0; 
				if (x > 930)
					x = 930;
				if (y < 0)
					y = 0;
				if (y > 770)
					y = 770;


			//Random collision code
//			foreach (Sprite other in GetCollisions ()) {
//				if (x > 0) x = Mathf.Min (other.x - width, x); //at left side of block
//				if (x < 0) x = Mathf.Max (other.x + other.width, x); //at right side of block
//				if (y > 0) y = Mathf.Min (other.y - height, y); //at top of block
//				if (y < 0) y = Mathf.Max (other.y + other.height, y); //at bottom of block
//			}
		}

//        private GameObject Bottom()
//        {
//            
//        }


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
            if (y == 500)
            {
                _jumpSpeed = 0.0f;
                return true;
            }

			else {return false;}//TODO: Change value based 
        }

		private void OnCollision(GameObject other){
			if(other is BossBase){
				BossBase enemy = other as BossBase;
				enemy.GetHit();
			}
		}
    }
}
