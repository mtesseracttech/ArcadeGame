using System.Collections.Generic;
using TimeGuardian.Level;

namespace TimeGuardian.UI.HUD
{
    class HUD : GameObject
    {
        private List<Heart> _lifeHearts;
        private int _lives;
        private LevelBase _level;

        public HUD(int lives, LevelBase level)
        {
            _level = level;
            _lives = lives;
            CreateHearts();
            _level.AddChild(this);
        }

        private void CreateHearts()
        {
            _lifeHearts = new List<Heart>();
            for (int i = 0; i < _lives; i++)
            {
                _lifeHearts.Add(new Heart(x + 30 + (i * 64), 30));
            }
            foreach (Heart heart in _lifeHearts)
            {
                AddChild(heart);
            }
        }

        public void LoseHeart()
        {
            if (_lifeHearts.Count > 0)
            {
                _lifeHearts[_lifeHearts.Count - 1].Break();
                _lifeHearts.RemoveAt(_lifeHearts.Count - 1);
            }
        }

        public void AddHeart()
        {
            _lifeHearts.Add(new Heart(x + 30 + ((_lifeHearts.Count) * 64), 30));
            AddChild(_lifeHearts[_lifeHearts.Count-1]);
        }

        private void Update()
        {
            
            
        }


        public void Render()
        {
            
        }
    }
}
