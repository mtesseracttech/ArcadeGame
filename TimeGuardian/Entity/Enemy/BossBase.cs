using TimeGuardian.Level;

namespace TimeGuardian.Entity.Enemy
{
    class BossBase : AnimationSprite
    {
        protected int Lives;
        protected int Damage;
        protected bool Vurnerable; //Value is used to temporarily make the boss vurnerable to player attacks, boss is invincible otherwise.
        protected int MaxInvTimer = 50;
        protected bool Dead;
        protected int InvincibilityTimer;
        protected LevelBase Level;
        protected EnemyHitBox WeakSpotHitBox;
        protected EnemyHitBox BodyHitBox;
        protected Sound hitSound;

        public BossBase(string filename, int cols, int rows, int lives, LevelBase level) : base(filename, cols, rows)
        {
            Level = level;
            Lives = lives;
            Vurnerable = false;
        }

        protected virtual void Update()
        {
            if (!Level.GetPaused()) UpdateUnpaused();
        }

        protected virtual void UpdateUnpaused()
        {
            if (!Level.GetTimeStopped()) UpdateNoTimeStop();
        }

        protected virtual void UpdateNoTimeStop()
        {
            if (InvincibilityTimer > 0) InvincibilityTimer--;
        }

        public EnemyHitBox GetWeakSpot()
        {
            return WeakSpotHitBox;
        }

        /// <summary>
        /// When called, returns whether the boss is vurnerable or not at a given point.
        /// </summary>
        public bool IsVurnerable()
        {
            return Vurnerable;
        }

        /// <summary>
        /// Does Damage to the Boss and Starts the boss' deathcycle in case his health hits 0
        /// </summary>
        public virtual void LoseLife(int damage)
        {
            System.Console.WriteLine("YOU HIT THE BOSS");
            if (Lives < 1)
            {
                DeathCycle();
            }
            else
            {
                Lives--;
                InvincibilityTimer = MaxInvTimer;
            }
        }

        /// <summary>
        /// This keeps track of the grace period timer after a hit
        /// </summary>
        /// <returns></returns>
        public virtual bool IsInvincible()
        {
            if (InvincibilityTimer > 0) return true;
            return false;
        }

        protected virtual void DeathCycle()
        {
            Dead = true;
            throw new System.NotImplementedException();
        }
    }
}
