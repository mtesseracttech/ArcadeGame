namespace TimeGuardian.Entity.Enemy
{
    class EnemyHitBox : Sprite
    {
        private bool _weakSpot;
        private EnemyBase _enemy;


        public EnemyHitBox(string filename, bool weakSpot, EnemyBase enemy) : base(filename)
        {
            _weakSpot = weakSpot;
            _enemy = enemy;
        }

        public bool IsWeakSpot()
        {
            return _weakSpot;
        }

        public EnemyBase GetOwner()
        {
            return _enemy;
        }

        public void DamageOwner()
        {
            if (_enemy.IsVurnerable() && !_enemy.IsInvincible() && !_enemy.IsDead() && _enemy.IsFrozen())
            {
                _enemy.LoseLife(1);
            }
        }
    }
}
