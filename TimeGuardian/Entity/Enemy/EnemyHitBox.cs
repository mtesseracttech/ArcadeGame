namespace TimeGuardian.Entity.Enemy
{
    class EnemyHitBox : Sprite
    {
        private bool _weakSpot;
        private BossBase _boss;


        public EnemyHitBox(string filename, bool weakSpot, BossBase boss) : base(filename)
        {
            _weakSpot = weakSpot;
            _boss = boss;
        }

        public bool IsWeakSpot()
        {
            return _weakSpot;
        }

        public BossBase GetOwner()
        {
            return _boss;
        }

        public void DamageOwner()
        {
            if (_boss.IsVurnerable() && !_boss.IsInvincible() && !_boss.IsDead() && _boss.IsFrozen())
            {
                _boss.LoseLife(1);
            }
        }
    }
}
