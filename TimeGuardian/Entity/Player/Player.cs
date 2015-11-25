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
        private HUDHeart _hudHeart;
        private TimeGuardianGame _game;
        private AnimationSprite _deadSprite;
        private float _xSpeed, _ySpeed;
        private bool _xFlip;
        private const float MaxXSpeed = 6.0f;
        private const float MaxYSpeed = 15.0f;
        private const int MaxTimeStopTimer = 200;
        private const int MaxLifes = 5;
        private const int MaxInvTimer = 500;
        private int _invTimer;
        private bool _restoring;
        private int _lives;
        private bool _dead = false;
        private const float _gravity = 0.2f;
        private float _walkSpeed, _jumpSpeed;
        private const float MaxMoveSpeed = 2.0f;
		private int _bottomPlayer;

        private int _jumpCounter;
        private int _currentStaticFrame, _currentMovingFrame, _currentJumpingFrame, _currentDeathFrame;

        private int _timestopTimer;

        private short[] _staticFrames = {13, 14, 15}; //TODO: Set to actual sprite values
        private short[] _movingFrames = {0, 1, 2, 3, 4, 5, 6, 7};//TODO: Set to actual sprite values
        private short[] _jumpFrames = {9, 9, 10, 11, 12}; //TODO: Set to actual sprite values
        private short[] _deathFrames = {0, 1, 2, 3, 4, 5, 6,};

        private HUD _hud;
		private bool _arcadeMachineControls;

        public Player(int lives, LevelBase level, TimeGuardianGame game) : base(UtilStrings.SpritesPlayer + "spritesheet_hero.png", 8, 2)
        {
            SetOrigin(width/2, 0);
            SetXY(100, 500);
            _game = game;
            _lives = lives;
            _level = level;
            _timestopTimer = MaxTimeStopTimer;
            DeadSpriteCreator();
            _hud = new HUD(_lives, _level, this);
        }

        private void DeadSpriteCreator()
        {
            _deadSprite = new AnimationSprite(UtilStrings.SpritesPlayer + "spritesheet_hero_death.png", 4, 2);
            _deadSprite.SetOrigin(_deadSprite.width/2, 24);
            _deadSprite.visible = false;
        }

		public int DefineFeet()
		{
			_bottomPlayer = (int)y + height;
			return _bottomPlayer;
		}

        void Update()
        {
            if (Input.GetKeyDown(Key.B)) LoseLife();
            if (Input.GetKeyDown(Key.C)) GetLife();

            if(!_level.GetPaused()) UpdateUnpaused();
        }

        void UpdateUnpaused()
        {
            if (!_dead) Ability();
            Movement();
            SpriteHandler();
        }

        public void Ability()
        {
            if (!_level.GetTimeStopped() && _timestopTimer < MaxTimeStopTimer)
            {
                _timestopTimer++;
                _restoring = true;
            }
            else _restoring = false;
            if (_level.GetTimeStopped() && _timestopTimer <= 0) _level.SetTimeStop(false);
            if (_level.GetTimeStopped())
            {
                _timestopTimer--;
                _restoring = false;
            }
            if (!_level.GetTimeStopped() && _timestopTimer == MaxTimeStopTimer && Input.GetKeyDown(Key.E)) _level.SetTimeStop(true);
            _hud.UpdateAbility(_timestopTimer, _restoring);
        }

        public void LoseLife()
        {
            if (_lives < 1)
            {
                _dead = true;
                _deadSprite.Mirror(_xFlip, false);
                _deadSprite.visible = true;
                alpha = 0.0f;
                AddChild(_deadSprite);
                GameOver gameOver = new GameOver(_game);
                _level.AddChild(gameOver);
            }
            else
            {
                _lives--;
                _invTimer = MaxInvTimer;
                _hud.SetHearts(_lives);
            }
        }

        public void GetLife()
        {
            if (_lives >= MaxLifes) return;
            _lives++;
            _hud.SetHearts(_lives);
        }

        private void Movement()
        {
            if (IsOnSolidGround())
            {
                _ySpeed = 0f;
                _jumpCounter = 0;
            }
            if (!IsOnSolidGround()) _ySpeed -= 0.5f;

            if (!_dead)
            {
                if (_xSpeed < MaxXSpeed && Input.GetKey(Key.D))
                {
                    _xSpeed += 0.3f;
                    _xFlip = false;
                    Mirror(_xFlip, false);
                }
                if (_xSpeed > -MaxXSpeed && Input.GetKey(Key.A))
                {
                    _xSpeed -= 0.3f;
                    _xFlip = true;
                    Mirror(_xFlip, false);
                }
                if (_xSpeed != 0.0f && !Input.GetKey(Key.D) && !Input.GetKey(Key.A)) _xSpeed *= 0.3f;

                if (Input.GetKeyDown(Key.SPACE) && _jumpCounter < 2)
                {
                    _jumpCounter++;
                    _ySpeed = 15.0f;
                }
            }

            EdgeBumper();
            Move(_xSpeed, -_ySpeed);

        }

        private void EdgeBumper()
        {
            if (x + width/2 > game.width) _xSpeed = -_xSpeed;
            else if(x - width/2 < 0) _xSpeed = -_xSpeed;
        }
/*
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
        */

//        private GameObject Bottom()
//        {
//            
//        }

        private void SpriteHandler()
        {
            if (!_dead)
            {
                if (_ySpeed > 0.1f || _ySpeed < -0.1f) JumpingSprite();
                else if (_xSpeed > 0.1f || _xSpeed < -0.1f) MovingSprite();
                else StaticSprite();
            }
            else DeathSprite();

        }

        private void DeathSprite()
        {
            if (_currentDeathFrame < _deathFrames.Length*10 - 1) _currentDeathFrame++;
            else
            {
                //_game.SetState("LoseScreen");
            }
            _deadSprite.currentFrame = _deathFrames[_currentDeathFrame / 10];
        }

        private void MovingSprite()
        {
            if (_currentMovingFrame < _movingFrames.Length * 5 - 1) _currentMovingFrame++;
            else _currentMovingFrame = 0;
            currentFrame = _movingFrames[_currentMovingFrame / 5];
        }

        private void StaticSprite()
        {
            if (_currentStaticFrame < _staticFrames.Length * 10 - 1) _currentStaticFrame++;
            else _currentStaticFrame = 0;
            currentFrame = _staticFrames[_currentStaticFrame / 10];
        }

        private void JumpingSprite()
        {
            //The frame of the jump can be decided by looking at the vertical speed of the player
            if (_ySpeed > 10.0f) currentFrame = _jumpFrames[0];
            else if(_ySpeed > 0.0f) currentFrame = _jumpFrames[1];
            else /*(_ySpeed > -20.0f)*/ currentFrame = _jumpFrames[2];
            //else currentFrame = _jumpFrames[3];
        }

        public bool IsInvincible()
        {
            if (_invTimer > 0) return true;
            return false;
        }
			
        private bool IsOnSolidGround()
        {
            if (y >= 500)
            {
                return true;
            }

			return false;//TODO: Change value based 
        }

        public int GetMaxTimeStopTimer()
        {
            return MaxTimeStopTimer;
        }

        public int GetTimeStopTimer()
        {
            return _timestopTimer;
        }

        public float GetXSpeed()
        {
            return _xSpeed;
        }

        public float GetYSpeed()
        {
            return _ySpeed;
        }

		private void OnCollision(GameObject other){
			if(other is BossBase){
				BossBase enemy = other as BossBase;
				enemy.GetHit();
			}
		}
    }
}
