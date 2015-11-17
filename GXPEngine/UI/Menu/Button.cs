using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GXPEngine.UI.Menu
{
    class Button : Canvas
    {
        private string _state;
        private Color _buttonColor;
        private string _text;

        /// <param name="width">width of the canvas</param>
        /// <param name="height">height of the canvas</param>
        /// <param name="xPos">x position of the button</param>
        /// <param name="yPos">y position of the button</param>
        /// <param name="state">which state the button will switch the game to</param>
        public Button(int width, int height, int xPos, int yPos, Color color, string text, string state) : base(width, height)
        {
            SetXY(x, y);
            _buttonColor = color;
            _text = text;
            _state = state;
        }


        //Changes the color of the button when selected
        public void Selected()
        {
            
        }

        //Should get called when the button is being pressed
        public string Pressed()
        {
            return _state;
        }

    }
}
