namespace TimeGuardian.UI.Menu
{
    class MainMenu : GameObject
    {
        private Button[] _buttons;
        private TimeGuardianGame _game;
        private int _selection = 0;
        private int _cooldown = 0;


        public MainMenu(TimeGuardianGame game)
        {
            _buttons = new []
            {
            new Button(UtilStrings.AnimSpriteDebug, 2, 1, 100, 100, "Level1"),
            new Button(UtilStrings.AnimSpriteDebug, 2, 1, 100, 200, "HighScores"),
            new Button(UtilStrings.AnimSpriteDebug, 2, 1, 100, 300, "Exit")
            };
            foreach (Button button in _buttons)
            {
                AddChild(button);
            }
            _game = game;

        }

        void Update()
        {
            _buttons[_selection].Selected();
            if (_cooldown > 0) _cooldown--;
            if (Input.GetKeyDown(Key.UP) && _cooldown == 0) SelectionUp();
            if (Input.GetKeyDown(Key.DOWN) && _cooldown == 0) SelectionDown();
            if (Input.GetKey(Key.ENTER)) Select();
        }

        void SelectionDown()
        {
            _buttons[_selection].DeSelect();
            if (_selection < _buttons.Length - 1) _selection++;
            else _selection = 0;
        }

        void SelectionUp()
        {
            _buttons[_selection].DeSelect();
            if (_selection > 0) _selection--;
            else _selection = _buttons.Length - 1;
        }

        void Select()
        {
            _game.SetState(_buttons[_selection].Pressed());
        }
    }
}
