namespace TimeGuardian.Entity.Enemy
{
    class BossBase : AnimationSprite
    {
        protected int HealthPoints;
        protected int Damage;
        protected bool Vurnerable; //Value is used to temporarily make the boss vurnerable to player attacks, boss is invincible otherwise.


        public BossBase(string filename, int cols, int rows, int healthPoints, int damage) : base(filename, cols, rows)
        {
            HealthPoints = healthPoints;
            Damage = damage;
            Vurnerable = false;
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
        }
    }
}
