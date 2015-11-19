using System.Drawing;
using TimeGuardian;

namespace TimeGuardian.UI.Menu
{
    class Button : AnimationSprite
    {
        private string _state;

        public Button(string filename, int rows, int x, int y, string state) : base(filename, 1, rows)
        {
            DeSelect();
            SetOrigin(width / 2, height / 2);
            SetXY(x, y);
            _state = state;
        }

        public void Selected()
        {
            if(scaleX != 1.2f) SetScaleXY(1.2f, 1.2f); //Only made it scan for scaleX because if that one is not right, the other won't be either
            SetFrame(0);
        }

        public void DeSelect()
        {
            if(scaleX != 1.0f) SetScaleXY(1f, 1f);
            SetFrame(1);
        }


        //Should get called when the button is being pressed, it returns the gamestate to which the game should be set
        public string Pressed()
        {
            return _state;
        }

    }
}
