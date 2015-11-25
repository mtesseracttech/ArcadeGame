using System.Drawing.Text;
using System.Runtime.Remoting.Messaging;
using TimeGuardian.Level;
using TimeGuardian.UI;
using TimeGuardian.UI.HUD;

namespace TimeGuardian.player
{
    class Player : AnimationSprite
    {
        private LevelBase _level;
        private HUDHeart _hudHeart;
        private TimeGuardianGame _game;
        private float _xSpeed, _ySpeed;
        private const float MaxXSpeed = 1.0f;
        private const float MaxYSpeed = 2.0f;
        private const int MaxTimeStopTimer = 2000;
        private const int MaxLifes = 5;
        private bool _restoring;
        private int _lives;
        private const float _gravity = 0.2f;


        private int _jumpCounter;
        private int _currentStaticFrame, _currentMovingFrame, _currentJumpingFrame, _currentDeathFrame;

  		private short[] _staticFrames = {64};
		private short[] _movingFrames = {35, 36, 37, 38, 39, 32, 33, 34};
        private short[] _jumpFrames = {43, 44, 45, 46};
        private short[] _deathFrames = {16, 17, 18, 19, 20, 21, 22, 23}; //TODO: Set to actual sprite values

        private int _timestopTimer;

        private HUD _hud;
		//private int _firstFrame = 0, _lastFrame = 0;
		//private float _frame = 0.0f;

        public Player(string filename, int lives, int cols, int rows, LevelBase level, TimeGuardianGame game) : base(filename, cols, rows)
        {
            SetXY(100, 500);
            _game = game;
            _lives = lives;
            _level = level;
            _timestopTimer = 2000;
            _hud = new HUD(_lives, _level, this);
        }


        void Update()
        {
            if (Input.GetKeyDown(Key.B)) LoseLife();
            if (Input.GetKeyDown(Key.C)) GetLife();
            if(!_level.GetPaused()) UpdateUnpaused();
        }

        void UpdateUnpaused()
        {
            Movement();
            Ability();
            SpriteHandler();
        }

        public void Ability()
        {
            if (!_level.GetTimeStopped() && _timestopTimer < MaxTimeStopTimer)
            {
                _timestopTimer++;
                _restoring = true;
            }
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
                DeathSprite();
            }
            else
            {
                _lives--;
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
            if (_xSpeed < MaxXSpeed && Input.GetKey(Key.D))
            {
                _xSpeed += 0.01f;
                Mirror(false, false);
            }
            if (_xSpeed > -MaxXSpeed && Input.GetKey(Key.A))
            {
                _xSpeed -= 0.01f;
                Mirror(true, false);
            }
            if (_xSpeed != 0.0f && !Input.GetKey(Key.D) && !Input.GetKey(Key.A)) _xSpeed /= 1.05f;

            
            if (IsOnSolidGround())
            {
                _ySpeed = 0f;
                _jumpCounter = 0;
            }
            if (Input.GetKeyDown(Key.SPACE) && _jumpCounter < 2)
            {
                _jumpCounter++;
                _ySpeed = 2.0f;
            }
            if(!IsOnSolidGround())_ySpeed -= 0.01f;
            

            Move(_xSpeed, -_ySpeed);
        }

        private void SpriteHandler()
        {
            if(_ySpeed > 0.1f || _ySpeed < -0.1f) JumpingSprite();
            else if (_xSpeed > 0.1f || _xSpeed < -0.1f) MovingSprite();
            else StaticSprite();
        }

        private void DeathSprite()
        {
            if (_currentDeathFrame < _deathFrames.Length * 50 - 1) _currentDeathFrame++;
            else _game.SetState("LoseScreen");
            currentFrame = _deathFrames[_currentDeathFrame / 50];
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
            if (_ySpeed > 0.5f) currentFrame = _jumpFrames[0];
            else if(_ySpeed > 0.0f) currentFrame = _jumpFrames[1];
            else if (_ySpeed > -0.5f) currentFrame = _jumpFrames[2];
            else currentFrame = _jumpFrames[3];
        }

        private bool IsOnSolidGround()
        {
            if (y >= 500)
            {
                return true;
            }

			else {return false;}//TODO: Change value based 
        }

        public int GetMaxTimeStopTimer()
        {
            return MaxTimeStopTimer;
        }

        public int GetTimeStopTimer()
        {
            return _timestopTimer;
        }
    }
}
