using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeGuardian.UI
{
    internal class GameOver : GameObject
    {
        private TimeGuardianGame _game;
        private Sprite _background;


        public GameOver(TimeGuardianGame game)
        {
            _game = game;
            SetBackground();
        }

        private void SetBackground()
        {
            _background = new Sprite(UtilStrings.SpritesOther + "gameover/overlay.png");
            AddChild(_background);
        }

    }
}
