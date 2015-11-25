using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeGuardian.UI.Menu;

namespace TimeGuardian.UI
{
    internal class GameOver : GameObject
    {
        private TimeGuardianGame _game;
        private Sprite _header, _background;
        private Button[] _buttons;
        private int _selection;

        public GameOver(TimeGuardianGame game)
        {
            _game = game;
            SetBackground();

            _buttons = new[]
            {
            new Button(UtilStrings.SpritesOther + "gameover/button_restart.png", 2, 300, 600, "Level1"),
            new Button(UtilStrings.SpritesOther + "gameover/button_exit.png", 2, game.width - 300, 600, "MainMenu")
            };

            foreach (Button button in _buttons)
            {
                AddChild(button);
            }

            _buttons[0].Selected();
        }

        private void SetBackground()
        {
            _background = new Sprite(UtilStrings.SpritesOther + "gameover/overlay.png");
            AddChild(_background);
        }

        private void SetHeader()
        {
            _header = new Sprite(UtilStrings.SpriteDebug);
            _header.SetOrigin(_header.width / 2, _header.height / 2);
            _header.SetXY(game.width / 2, 120);
            _header.SetScaleXY(6f, 2f);
            AddChild(_header);
        }

        void Update()
        {
            //_tweener.Update(_updateTime);
            //_buttons[_selection].Selected();
            if (Input.GetKeyDown(Key.LEFT) || Input.GetKeyDown(Key.A)) SelectionUp();
            if (Input.GetKeyDown(Key.RIGHT) || Input.GetKeyDown(Key.D)) SelectionDown();
            if (Input.GetKeyDown(Key.ENTER) || Input.GetKeyDown(Key.SPACE)) Select();
        }

        void SelectionDown()
        {
            _buttons[_selection].DeSelect();
            if (_selection < _buttons.Length - 1) _selection++;
            else _selection = 0;
            _buttons[_selection].Selected();
        }

        void SelectionUp()
        {
            _buttons[_selection].DeSelect();
            if (_selection > 0) _selection--;
            else _selection = _buttons.Length - 1;
            _buttons[_selection].Selected();
        }

        void Select()
        {
            _game.SetState(_buttons[_selection].Pressed());
        }

    }
}
