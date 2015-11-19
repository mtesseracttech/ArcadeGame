﻿using System.ComponentModel;
using Glide;

namespace TimeGuardian.UI.Menu
{
    class MainMenu : GameObject
    {
        private Sprite _header, _background;
        private Button[] _buttons ;
        private TimeGuardianGame _game;
        private int _selection;

        public MainMenu(TimeGuardianGame game)
        {
            _game = game;
            SetBackground();
            SetHeader();
            _buttons = new []
            {
            new Button(UtilStrings.AnimSpriteDebug, 2, game.width/2, 200, "Level1"),
            new Button(UtilStrings.AnimSpriteDebug, 2, game.width/2, 300, "HighScores"),
            new Button(UtilStrings.AnimSpriteDebug, 2, game.width/2, 400, "Credits"), 
            new Button(UtilStrings.AnimSpriteDebug, 2, game.width/2, 500, "Exit")
            };

            foreach (Button button in _buttons)
            {
                AddChild(button);
            }
        }

        private void SetBackground()
        {
            _background = new Sprite(UtilStrings.BackgroundDebug);
            AddChild(_background);
        }

        private void SetHeader()
        {
            _header = new Sprite(UtilStrings.SpriteDebug);
            _header.SetOrigin(_header.width/2, _header.height/2);
            _header.SetXY(game.width / 2, 80);
            AddChild(_header);
        }

        void Update()
        {
            //_tweener.Update(_updateTime);
            _buttons[_selection].Selected();
            if (Input.GetKeyDown(Key.UP) || Input.GetKeyDown(Key.W)) SelectionUp();
            if (Input.GetKeyDown(Key.DOWN) || Input.GetKeyDown(Key.S)) SelectionDown();
            if (Input.GetKeyDown(Key.ENTER) || Input.GetKeyDown(Key.SPACE)) Select();
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