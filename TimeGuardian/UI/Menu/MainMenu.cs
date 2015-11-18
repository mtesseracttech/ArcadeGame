using System.Drawing.Imaging;
using TimeGuardian;


namespace TimeGuardian.UI.Menu
{
    class MainMenu : GameObject
    {
        private Button[] buttons;
        private Game _game;
        private int _selection;


        public MainMenu(Game game)
        {
            buttons = new []
            {
            new Button(UtilStrings.AnimSpriteDebug, 2, 1, 100, 100, "Level1"),
            new Button(UtilStrings.AnimSpriteDebug, 2, 1, 100, 200, "HighScores"),
            new Button(UtilStrings.AnimSpriteDebug, 2, 1, 100, 200, "Exit")
            };
            _game = game;

        }

        void Update()
        {

        }

        void select()
        {
            //_game.SetState(buttons[_selection]); //WHY IS THIS NOT WORKING????
        }
    }
}
