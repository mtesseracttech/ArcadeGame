﻿using System;
using TimeGuardian.Entity.Enemy;
using TimeGuardian.Entity.LevelEntities;
using TimeGuardian.Level;
using TimeGuardian.UI;
using TimeGuardian.UI.HUD;
using TimeGuardian.Utility;

namespace TimeGuardian.Entity.Player
{
    internal class Player : AnimationSprite
    {
        private const float MaxXSpeed = 6.0f;
        private const float MaxYSpeed = 15.0f;
        private const int MaxTimeStopTimer = 200;
        private const int MaxLifes = 5;
        private const int MaxInvTimer = 100;

        private readonly short[] _deathFrames = {0, 1, 2, 3, 4, 5, 6};
        private readonly short[] _jumpFrames = {9, 9, 10, 11, 12};
        private readonly short[] _movingFrames = {0, 1, 2, 3, 4, 5, 6, 7};
        private readonly short[] _staticFrames = {13, 14, 15};

        private PlayerHitBox _bodyHitBox;
        private int _bottomPlayer;
        private int _currentStaticFrame, _currentMovingFrame, _currentDeathFrame;
        private bool _dead;
        private AnimationSprite _deadSprite;
        private PlayerHitBox _feetHitBox;
        private readonly TimeGuardianGame _game;
        private readonly HUD _hud;
        private bool _isGrounded;
        private int _jumpCounter;

        private readonly Sound _jumpSound, _hurtSound, _getLifeSound, _abilityLoadedSound, _abilityDepletedSound;
        private LevelBase _level;

        private int _lives;
        private bool _restoring;
        private int _timestopTimer, _invincibilityTimer;
        private bool _xFlip;

        private float _xSpeed;
        private float _ySpeed;

        public Player(int lives, LevelBase level, TimeGuardianGame game)
            : base(UtilStrings.SpritesPlayer + "spritesheet_hero.png", 8, 2)
        {
            SetOrigin(width/2, 0);
            SetXY(100, 500);
            _game = game;
            _lives = lives;
            _level = level;
            _timestopTimer = MaxTimeStopTimer;
            DeadSpriteCreator();
            HitBoxCreator();
            _hud = new HUD(_lives, _level, this);
            _jumpSound = new Sound(UtilStrings.SoundsPlayer + "sound_jump.wav");
            _hurtSound = new Sound(UtilStrings.SoundsPlayer + "sound_hurt.wav");
            _getLifeSound = new Sound(UtilStrings.SoundsPlayer + "sound_getLife.wav");
            _abilityLoadedSound = new Sound(UtilStrings.SoundsPlayer + "sound_abilityActive.wav");
            _abilityDepletedSound = new Sound(UtilStrings.SoundsPlayer + "sound_abilityDepleted.wav");
        }

        private void HitBoxCreator()
        {
            _bodyHitBox = new PlayerHitBox(UtilStrings.SpritesPlayer + "hitbox_hero_body.png", this);
            _bodyHitBox.SetOrigin(_bodyHitBox.width/2, 0);
            _bodyHitBox.alpha = 0f;
            AddChild(_bodyHitBox);
            _feetHitBox = new PlayerHitBox(UtilStrings.SpritesPlayer + "hitbox_hero_feet.png", this);
            _feetHitBox.SetOrigin(_feetHitBox.width/2, 0);
            _feetHitBox.SetXY(0, height - _feetHitBox.height);
            _feetHitBox.alpha = 0f;
            AddChild(_feetHitBox);
        }

        private void DeadSpriteCreator()
        {
            _deadSprite = new AnimationSprite(UtilStrings.SpritesPlayer + "spritesheet_hero_death.png", 4, 2);
            _deadSprite.SetOrigin(_deadSprite.width/2, 24);
            _deadSprite.visible = false;
        }

        public int DefineFeet()
        {
            _bottomPlayer = (int) y + height;
            return _bottomPlayer;
        }

        private void Update()
        {
            if (Input.GetKeyDown(Key.R)) LoseLife();
            if (Input.GetKeyDown(Key.T)) GetLife();
            if (Input.GetKeyDown(Key.Y)) _game.SetState("Level1");
            if (Input.GetKeyDown(Key.U)) _game.SetState("Level2");
            if (Input.GetKeyDown(Key.I)) _game.SetState("Level3");


            if (!_level.GetPaused()) UpdateUnpaused();
        }

        private void UpdateUnpaused()
        {
            if (!_dead) Ability();
            Movement();
            SpriteHandler();
        }

        public void Ability()
        {
            if (_invincibilityTimer > 0) _invincibilityTimer--;
            if (!_level.GetTimeStopped() && _timestopTimer < MaxTimeStopTimer)
            {
                _timestopTimer++;
                _restoring = true;
            }
            else _restoring = false;
            if (_level.GetTimeStopped() && _timestopTimer <= 0)
            {
                _level.SetTimeStop(false);
                _abilityDepletedSound.Play();
            }
            if (_level.GetTimeStopped())
            {
                _timestopTimer--;
                _restoring = false;
            }
            if (!_level.GetTimeStopped() && _timestopTimer == MaxTimeStopTimer &&
                Input.GetKeyDown(ArcadeButtons.PLAYER1_BUTTON2))
            {
                _abilityLoadedSound.Play();
                _level.SetTimeStop(true);
            }
            _hud.UpdateAbility(_timestopTimer, _restoring);
        }

        public void LoseLife()
        {
            _hurtSound.Play();
            if (_lives < 1)
            {
                _dead = true;
                _deadSprite.Mirror(_xFlip, false);
                _deadSprite.visible = true;
                _xSpeed = 0;
                alpha = 0.0f;
                AddChild(_deadSprite);
                var gameOver = new GameOver(_game, _level);
                _level.AddChild(gameOver);
            }
            else
            {
                _lives--;
                _invincibilityTimer = MaxInvTimer;
                _hud.SetHearts(_lives);
            }
        }

        public int GetLives()
        {
            return _lives;
        }

        public void GetLife()
        {
            if (_lives >= MaxLifes) return;
            _getLifeSound.Play();
            _lives++;
            _hud.SetHearts(_lives);
        }

        private void Movement()
        {
            if (!_isGrounded && _ySpeed > -MaxYSpeed) _ySpeed -= 0.5f;
            if (_level.GetFinished()) _xSpeed = 0.0f;
            if (!_dead && !_level.GetFinished())
            {
                if (_xSpeed < MaxXSpeed && Input.GetKey(ArcadeButtons.PLAYER1_RIGHT))
                {
                    if (_xSpeed < 0) _xSpeed = 0f;
                    _xSpeed += 0.3f;
                    _xFlip = false;
                    Mirror(_xFlip, false);
                }
                else if (_xSpeed > -MaxXSpeed && Input.GetKey(ArcadeButtons.PLAYER1_LEFT))
                {
                    if (_xSpeed > 0) _xSpeed = 0f;
                    _xSpeed -= 0.3f;
                    _xFlip = true;
                    Mirror(_xFlip, false);
                }
                if (_xSpeed != 0.0f && !Input.GetKey(ArcadeButtons.PLAYER1_RIGHT) &&
                    !Input.GetKey(ArcadeButtons.PLAYER1_LEFT)) _xSpeed *= 0.3f;


                if (Input.GetKeyDown(ArcadeButtons.PLAYER1_BUTTON1) && _jumpCounter < 2)
                {
                    _jumpSound.Play();
                    _jumpCounter++;
                    _ySpeed = 15.0f;
                }
            }
            //EdgeBumper();
            move(_xSpeed, 0);
            move(0, -_ySpeed);
            if (!IsDead() && !_level.GetFinished()) FeetDetection();
            if (!IsInvincible() && !IsDead() && !_level.GetFinished()) BodyDetection();
            //Move(_xSpeed, -_ySpeed);
        }

        private void move(float moveX, float moveY)
        {
            x = x + moveX;
            y = y + moveY;

            foreach (Sprite wall in _bodyHitBox.GetCollisions())
            {
                if (wall is Wall)
                {
                    if (moveX > 0)
                    {
                        x = Mathf.Min(wall.x - _bodyHitBox.width / 2, x); //at left side of block
                    }
                    if (moveX < 0)
                    {
                        x = Mathf.Max(wall.x + wall.width + _bodyHitBox.width / 2, x); //at right side of block
                    }

                    if (moveY > 0)
                    {
                        y = Mathf.Min(wall.y - height, y); //at top of block
                        _ySpeed = 0f;
                        _jumpCounter = 0;
                    }
                    if (moveY < 0)
                    {
                        y = Mathf.Max(wall.y + wall.height, y); //at bottom of block
                        _ySpeed = 0f;
                    }
                }
                else
                {
                    _isGrounded = false;
                }
            }
        }


        private void FeetDetection()
        {
            EnemyHitBox hb;
            foreach (Sprite collision in _feetHitBox.GetCollisions())
            {
                if (collision is EnemyHitBox)
                {
                    hb = collision as EnemyHitBox;
                    if (hb.IsWeakSpot())
                    {
                        Bounce();
                        hb.DamageOwner();
                    }
                    else
                    {
                        Bounce();
                        if (!IsInvincible()) LoseLife();
                    }
                }
            }
        }

        private void BodyDetection()
        {
            //EnemyHitBox hb;
            foreach (Sprite collision in _bodyHitBox.GetCollisions())
            {
                if (collision is EnemyHitBox)
                {
                    if (_level.GetTimeStopped()) Bounce();
                    else
                    {
                        Bounce();
                        LoseLife();
                    }
                }
            }
        }

        private void SpriteHandler()
        {
            if (!_dead)
            {
                if (_invincibilityTimer > 0) alpha = 0.5f;
                else alpha = 1;
                if (_ySpeed > 0.1f || _ySpeed < -0.1f) JumpingSprite();
                else if (_xSpeed > 0.1f || _xSpeed < -0.1f) MovingSprite();
                else StaticSprite();
            }
            else DeathSprite();
        }

        private void DeathSprite()
        {
            if (_currentDeathFrame < _deathFrames.Length*10 - 1) _currentDeathFrame++;
            _deadSprite.currentFrame = _deathFrames[_currentDeathFrame/10];
        }

        private void MovingSprite()
        {
            if (_currentMovingFrame < _movingFrames.Length*5 - 1) _currentMovingFrame++;
            else _currentMovingFrame = 0;
            currentFrame = _movingFrames[_currentMovingFrame/5];
        }

        private void StaticSprite()
        {
            if (_currentStaticFrame < _staticFrames.Length*10 - 1) _currentStaticFrame++;
            else _currentStaticFrame = 0;
            currentFrame = _staticFrames[_currentStaticFrame/10];
        }

        private void JumpingSprite()
        {
            //TODO: GETTING IT TO WORK PROPERLY, WITHOUT THE WEIRD "INBETWEEN" SPRITE
            if (_ySpeed > 10.0f) currentFrame = _jumpFrames[0];
            else if (_ySpeed > 0.0f) currentFrame = _jumpFrames[1];
            else if (_ySpeed > -20.0f) currentFrame = _jumpFrames[2];
            else currentFrame = _jumpFrames[3];
        }

        public bool IsInvincible()
        {
            if (_invincibilityTimer > 0) return true;
            return false;
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

        public void Bounce()
        {
            _xSpeed = -_xSpeed;
            _ySpeed = -_ySpeed;
        }

        public bool IsDead()
        {
            return _dead;
        }

        public void SetLevel(LevelBase level)
        {
            _level = level;
        }
    }
}