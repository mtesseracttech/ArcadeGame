using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeGuardian.Managers;

namespace TimeGuardian.Level
{
    class Background : Sprite
    {
        private int _index;
        private LevelBase _level;

        public Background(string filename, int index, LevelBase level) : base(filename)
        {
            SetOrigin(width/2, height/2);
            SetXY(game.width/2, game.height/2);
            _index = index;
            _level = level;
        }

        public void Scroll(float xSpeed, float ySpeed)
        {
            
            Move(-(xSpeed * _index/10), (ySpeed * _index/10));
            
        }
        /*
        public void Scroll(float x, float y)
        {
            SetXY(game.width/2 - (x * _index/10), game.height/2 + -(y * _index/10));
        }
        */
    }
}
