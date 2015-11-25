using TimeGuardian.Level;

namespace TimeGuardian.Entity.Enemy
{
    class BossBase : AnimationSprite
    {
        protected int HealthPoints;
        protected int Damage;
        protected bool Vurnerable; //Value is used to temporarily make the boss vurnerable to player attacks, boss is invincible otherwise.
        protected LevelBase Level;

        public BossBase(string filename, int cols, int rows, int healthPoints, int damage, LevelBase level) : base(filename, cols, rows)
        {
            Level = level;
            HealthPoints = healthPoints;
            Damage = damage;
            Vurnerable = false;
        }

        void Update()
        {
            if (!Level.GetPaused()) UpdateUnpaused();
        }

        protected virtual void UpdateUnpaused()
        {
            if (!Level.GetTimeStopped()) UpdateNoTimeStop();
        }

        protected virtual void UpdateNoTimeStop()
        {

        }


        /// <summary>
        /// When called, returns whether the boss is vurnerable or not at a given point.
        /// </summary>
        public bool GetVurnerability()
        {
            return Vurnerable;
        }

        /// <summary>
        /// Does Damage to the Boss and Starts the boss' deathcycle in case his health hits 0
        /// </summary>
        public void DoDamage(int damage)
        {
            HealthPoints -= damage;
            if (HealthPoints <= 0) DeathCycle();
        }


        private void DeathCycle()
        {
            throw new System.NotImplementedException();
			//this.Destroy ();
        }

		public void GetHit(){
			GetVurnerability ();
			if(Vurnerable == true){
				System.Console.WriteLine("YOU HIT THE BOSS");
			}
			if(Vurnerable == false){
				System.Console.WriteLine ("YOU CAN NEVER HIT ME");
			}

		}
    }
}
