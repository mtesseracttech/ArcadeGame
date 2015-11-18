using System.Drawing;

namespace GXPEngine.UI.Menu
{
    class Button : AnimationSprite
    {
        private string _state;

        public Button(string filename, int cols, int rows, int x, int y, string state, int frames = -1) : base(filename, cols, rows, frames)
        {
            SetOrigin(width / 2, height / 2);
            SetXY(x, y);
            _state = state;
        }

        void Selected()
        {
            SetFrame(0);
        }

        void DeSelect()
        {
            SetFrame(1);
        }


        //Should get called when the button is being pressed
        public string Pressed()
        {
            return _state;
        }

    }
}
