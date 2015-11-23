using System.Drawing.Imaging;

namespace TimeGuardian.UI.Menu
{
    class Pause : GameObject
    {
        private Sprite _header, _background;
        private Button[] _buttons;
        private TimeGuardianGame _game;
        private int _selection;
        private bool _open;

        public Pause(TimeGuardianGame game)
        {
            _game = game;


            x = -500;
            _background = new Sprite(UtilStrings.SpritesMenu + "background_Pause.png");
            _background.SetOrigin(0,_background.height/2);
            _background.y = game.height/2;
            _header = new Sprite(UtilStrings.SpriteDebug);
            _header.SetOrigin(_header.width/2, _header.height/2);
            _header.SetXY(_background.width/2, 200);
            _buttons = new[]
            {
            new Button(UtilStrings.SpritesMenu + "button_exit.png", 2, _background.width/2, 350, ""),
            new Button(UtilStrings.SpritesMenu + "button_exit.png", 2, _background.width/2, 450, "")
            };

            AddChild(_background);
            AddChild(_header);
            foreach (Button button in _buttons)
            {
                AddChild(button);
            }
        }


        void Update()
        {
            if (_open)
            {
                if (x < 0) x+=5;
                _buttons[_selection].Selected();
                if (Input.GetKeyDown(Key.UP) || Input.GetKeyDown(Key.W)) SelectionUp();
                if (Input.GetKeyDown(Key.DOWN) || Input.GetKeyDown(Key.S)) SelectionDown();
                if (Input.GetKeyDown(Key.ENTER) || Input.GetKeyDown(Key.SPACE)) Select();
            }

            else
            {
                if (x >= -500) x-=5;
            }
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


        public void Toggle()
        {
            _open = !_open;
            _buttons[_selection].DeSelect();
            if (_open) _selection = 0;
        }

        void Select()
        {
            if (_selection == 0) Toggle();
            else
            {
                _game.SetState(_buttons[_selection].Pressed());
            }
        }
    }
}
