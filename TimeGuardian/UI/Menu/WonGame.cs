using System;
using TimeGuardian.Utility;

namespace TimeGuardian.UI.Menu
{
    internal class WonGame : GameObject
    {
        private TimeGuardianGame _game;

        public WonGame(TimeGuardianGame game)
        {
            _game = game;
            Sprite background = new Sprite(UtilStrings.SpritesOther + "gamewon/background.png");
            Sprite header = new Sprite(UtilStrings.SpritesOther + "gamewon/header.png");
            header.SetXY(100, game.height-400);
            AddChild(background);
            AddChild(header);
        }

        private void Update()
        {
            if(Input.GetKeyDown(ArcadeButtons.PLAYER1_BUTTON1)) _game.SetState("MainMenu");
        }
    }
}