using System.Collections.Generic;
using TimeGuardian.Level;
using TimeGuardian.player;

namespace TimeGuardian.UI.HUD
{
    class HUD : GameObject
    {
        private List<HUDHeart> _lifeHearts;
        private HUDAbility _hudAbility;
        private int _lives;
        private LevelBase _level;
        private Player _player;

        public HUD(int lives, LevelBase level, Player player)
        {
            _lives = lives;
            _level = level;
            _player = player;
            CreateHearts();
            _hudAbility = new HUDAbility(x + 30, 30 + 70, _player.GetMaxTimeStopTimer());
            AddChild(_hudAbility);
            _level.AddChildAt(this,10);
        }

        private void CreateHearts()
        {
            _lifeHearts = new List<HUDHeart>();
            for (int i = 0; i < _lives; i++)
            {
                _lifeHearts.Add(new HUDHeart(x + 30 + (i * 64), 30));
            }
            foreach (HUDHeart heart in _lifeHearts)
            {
                AddChild(heart);
            }
            
        }

        public void SetHearts(int lives)
        {
            if(_lifeHearts.Count < lives) while (_lifeHearts.Count < lives) AddHeart();
            else if(_lifeHearts.Count > lives) while (_lifeHearts.Count > lives) LoseHeart();
        }

        private void LoseHeart()
        {
            if (_lifeHearts.Count > 0)
            {
                _lifeHearts[_lifeHearts.Count - 1].Break();
                _lifeHearts.RemoveAt(_lifeHearts.Count - 1);
            }
        }

        private void AddHeart()
        {
            _lifeHearts.Add(new HUDHeart(x + 30 + ((_lifeHearts.Count) * 64), 30));
            AddChild(_lifeHearts[_lifeHearts.Count-1]);
        }

        private void Update()
        {
            
            
        }

        public void UpdateAbility(int time, bool restoring)
        {
            _hudAbility.TimerTextureChanger(time, restoring);
        }
    }
}
