using System;
using TimeGuardian.Level;
using TimeGuardian.Managers;

namespace TimeGuardian.Entity.Enemy
{
	 class EagleEnemy : BossBase
	{

		private float _moveX, _moveY;
		int firstFrame = 0, lastFrame = 5;
		float frame = 0.0f;
	    private LevelBase _level;

		public EagleEnemy(int cols, int rows, int healthPoints, int damage, LevelBase level) : base(UtilStrings.SpritesEnemy + "spritesheet_enemy_2.png", cols,rows,healthPoints,damage,level)
		{
		    _level = level;
			SetXY(750, 450);
			HealthPoints = healthPoints;
			Damage = damage;
			_moveY = 1;
			HitBox hitBox = new HitBox (UtilStrings.SpritesEnemy+ "hitbox_enemy_2.png");
			hitBox.alpha = 0; // make hitbox invisible(0) (1 is visible)
			AddChild (hitBox);

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
		    if(y>650){
			    _moveY = -1;
		    }
		    if(y<450){
			    _moveY = 1;
		    }
		}

		private void SpriteHandler(){
			GetVurnerability ();
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

