using TimeGuardian.Level;
using TimeGuardian.UI.Menu;

namespace TimeGuardian.UI
{
    class BossBeaten : GameObject
    {
        private TimeGuardianGame _game;
        private Sprite _header, _background;
        private Button[] _buttons;
        private LevelBase _level;
        private int _selection;

        public BossBeaten(TimeGuardianGame game, LevelBase level)
        {

            _game = game;
            _level = level;
            SetBackground();
            SetHeader();
            _buttons = new[]
            {
            new Button(UtilStrings.SpritesOther + "levelbeaten/button_next.png", 2, 300, 550, _level.GetNextLevelName()),
            new Button(UtilStrings.SpritesOther + "levelbeaten/button_exit.png", 2, game.width - 300, 550, "MainMenu")
            };
            foreach (Button button in _buttons)
            {
                AddChild(button);
            }

            _buttons[0].Selected();
        }

        private void SetBackground()
        {
            _background = new Sprite(UtilStrings.SpritesOther + "levelbeaten/overlay.png");
            AddChild(_background);
        }

        private void SetHeader()
        {
            _header = new Sprite(UtilStrings.SpritesOther + "levelbeaten/level_complete.png");
            _header.SetOrigin(_header.width / 2, _header.height / 2);
            _header.SetXY(game.width / 2, 250);
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
            switch (_selection)
            {
                case 0:
                    _game.SetState(_buttons[_selection].Pressed(), true);
                    break;
                case 1:
                    _game.SetState(_buttons[_selection].Pressed());
                    break;
            }

        }
    }
}
