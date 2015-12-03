using TimeGuardian.Level;

namespace TimeGuardian.Entity.Enemy
{
	 class EnemyEagle : BossBase
	{

		private float _moveX, _moveY;
		int firstFrame = 0, lastFrame = 5;
		float frame = 0.0f;
	    private LevelBase _level;
		private HitBox _hitBox;

		public EnemyEagle(int cols, int rows, int healthPoints, LevelBase level) : base(UtilStrings.SpritesEnemy + "spritesheet_enemy_2.png", cols,rows,healthPoints,level)
		{
		    _level = level;
            SetOrigin(height/2, width/2);
		    SetXY(500, 450);
			HealthPoints = healthPoints;
		    _moveX = -2;
			_moveY = 1;
			_hitBox = new HitBox (UtilStrings.SpritesEnemy + "hitbox_enemy_2.png");
			_hitBox.alpha = 1; // make hitbox invisible(0) (1 is visible)
			AddChild (_hitBox);

		}

		public HitBox GetHitBox()
		{
			return _hitBox;
		}

	    protected override void Update()
	    {
	        base.Update();
	    }

	    protected override void UpdateNoTimeStop()
	    {
            Movement();
            SpriteHandler();
        }

        private void Movement(){	
		    //scripted movement for boss
		    Move (_moveX, _moveY);

            if (x > game.width - 200)
            {
                _moveX = Utils.Random(-10, -1);
                Mirror(false, false);
            }
            if (x < 200)
            {
                _moveX = Utils.Random(2,11);
                Mirror(true, false);
            }
		    if (y > game.height - 350)  _moveY = Utils.Random(-5, -1);
		    if (y < 200) _moveY = Utils.Random(2, 6);
		}

		private void SpriteHandler(){
			IsVurnerable ();
			MovingSprite ();
		}

		private void MovingSprite(){
			frame += 0.1f;
			if (frame > lastFrame + 1)
				frame = firstFrame;
			if (frame < firstFrame)
				frame = lastFrame;
			SetFrame ((int)frame);
		}
			
	}
}

