using System.Drawing.Imaging;
using TimeGuardian.Level;
using TimeGuardian.Utility;

namespace TimeGuardian.UI.Menu
{
    class Pause : GameObject
    {
        private Button[] _buttons;
        private TimeGuardianGame _game;
        private LevelBase _level;
        private Sound _selectedSound;
        private Sound _openSound;
        private int _selection;
        private bool _open;

        public Pause(TimeGuardianGame game, LevelBase level)
        {
            _level = level;
            _game = game;

            x = -500;

            Sprite background = new Sprite(UtilStrings.SpritesPause + "background_pause.png");
            background.SetOrigin(0,background.height/2);
            background.y = game.height/2;

            Sprite header = new Sprite(UtilStrings.SpritesPause + "header_pause.png");
            header.SetOrigin(header.width/2, header.height/2);
            header.SetXY(background.width/2, 200);

            _buttons = new[]
            {
            new Button(UtilStrings.SpritesPause + "button_resume.png", 2, background.width/2, 350, "Resume"),
            new Button(UtilStrings.SpritesPause + "button_restart.png", 2, background.width/2, 450, _level.GetLevelName()),
            new Button(UtilStrings.SpritesPause + "button_exit.png", 2, background.width/2, 550, "MainMenu")
            };

            AddChild(background);
            AddChild(header);
            foreach (Button button in _buttons)
            {
                AddChild(button);
            }

            _selectedSound = new Sound(UtilStrings.SoundsMenu + "sound_selected.wav");
            _openSound = new Sound(UtilStrings.SoundsMenu + "sound_pause.wav");
        }


        void Update()
        {
            Opener();
        }

        void Opener()
        {
            if (_open)
            {
                if (x < 0) x += 50;
                _buttons[_selection].Selected();
                if (Input.GetKeyDown(Key.UP) || Input.GetKeyDown(Key.W) || Input.GetKeyDown(ArcadeButtons.PLAYER1_UP)) SelectionUp();
                if (Input.GetKeyDown(Key.DOWN) || Input.GetKeyDown(Key.S) || Input.GetKeyDown(ArcadeButtons.PLAYER1_DOWN)) SelectionDown();
                if (Input.GetKeyDown(Key.ENTER) || Input.GetKeyDown(Key.SPACE) || Input.GetKeyDown(ArcadeButtons.PLAYER1_BUTTON1)) Select();
            }
            else
            {
                if (x >= -500) x -= 50;
            }
        }

        void SelectionDown()
        {
            _selectedSound.Play();
            _buttons[_selection].DeSelect();
            if (_selection < _buttons.Length - 1) _selection++;
            else _selection = 0;
        }

        void SelectionUp()
        {
            _selectedSound.Play();
            _buttons[_selection].DeSelect();
            if (_selection > 0) _selection--;
            else _selection = _buttons.Length - 1;
        }


        public void Toggle()
        {
            _open = !_open;
            _buttons[_selection].DeSelect();
            _openSound.Play();
            if (_open)
            {
                _level.PauseMusic(true);
                _selection = 0;
            }
            else _level.PauseMusic(false);
        }

        void Select()
        {
            switch (_selection)
            {
                case 0:
                    _level.PauseToggle();
                    break;
                case 1:
                    _game.SetState(_buttons[_selection].Pressed(), true);
                    break;
                case 2:
                    _game.SetState(_buttons[_selection].Pressed(), true);
                    break;
            }
        }
    }
}
