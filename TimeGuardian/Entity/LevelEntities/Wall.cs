using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeGuardian.Entity.LevelEntities
{
    class Wall : Sprite
    {
        /// <summary>
        /// This Class only Exists to make Friendly collisions easier.
        /// </summary>
        /// <param name="filename"></param>
        public Wall(string filename) : base(filename)
        {
        }
    }
}
