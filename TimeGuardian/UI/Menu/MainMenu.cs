using System.ComponentModel;
using Glide;
using TimeGuardian.Utility;

namespace TimeGuardian.UI.Menu
{
    class MainMenu : GameObject
    {
        private Sprite _header, _background;
        private Button[] _buttons ;
        private TimeGuardianGame _game;
        private Sound _music;
        private Sound _selectedSound;
        private SoundChannel _musicChannel;

        private int _selection;

        public MainMenu(TimeGuardianGame game)
        {
            _game = game;
            SetBackground();
            SetHeader();
            _buttons = new []
            {
            new Button(UtilStrings.SpritesMenu + "button_newgame.png", 2, game.width/2, 350, "Level1"),
            new Button(UtilStrings.SpritesMenu + "button_highscore.png", 2, game.width/2, 450, "HighScores"),
            new Button(UtilStrings.SpritesMenu + "button_credits.png", 2, game.width/2, 550, "Credits"), 
            new Button(UtilStrings.SpritesMenu + "button_exit.png", 2, game.width/2, 650, "Exit")
            };

            foreach (Button button in _buttons)
            {
                AddChild(button);
            }

            _selectedSound = new Sound(UtilStrings.SoundsMenu + "sound_selected.wav");
            _music = new Sound(UtilStrings.SoundsMenu + "music_menu.mp3", true, true);
            _musicChannel = _music.Play();

            _buttons[0].Selected();
        }
        
        private void SetBackground()
        {
            _background = new Sprite(UtilStrings.SpritesMenu + "background.png");
            AddChild(_background);
        }

        private void SetHeader()
        {
            _header = new Sprite(UtilStrings.SpritesMenu + "header_logo.png");
            _header.SetOrigin(_header.width/2, _header.height/2);
            _header.SetXY(game.width / 2, 120);
            AddChild(_header);
        }

        void Update()
        {
            //_tweener.Update(_updateTime);
            //_buttons[_selection].Selected();
            if (Input.GetKeyDown(Key.UP) || Input.GetKeyDown(Key.W) || Input.GetKeyDown(ArcadeButtons.PLAYER1_UP)) SelectionUp();
            if (Input.GetKeyDown(Key.DOWN) || Input.GetKeyDown(Key.S) || Input.GetKeyDown(ArcadeButtons.PLAYER1_DOWN)) SelectionDown();
            if (Input.GetKeyDown(Key.ENTER) || Input.GetKeyDown(Key.SPACE) || Input.GetKeyDown(ArcadeButtons.PLAYER1_BUTTON1)) Select();
        }

        void SelectionDown()
        {
            _selectedSound.Play();
            _buttons[_selection].DeSelect();
            if (_selection < _buttons.Length - 1) _selection++;
            else _selection = 0;
            _buttons[_selection].Selected();
        }

        void SelectionUp()
        {
            _selectedSound.Play();
            _buttons[_selection].DeSelect();
            if (_selection > 0) _selection--;
            else _selection = _buttons.Length - 1;
            _buttons[_selection].Selected();
        }

        void Select()
        {
            _game.SetState(_buttons[_selection].Pressed());
        }

        public void StopMusic()
        {
            _musicChannel.Stop();
        }
    }
}
