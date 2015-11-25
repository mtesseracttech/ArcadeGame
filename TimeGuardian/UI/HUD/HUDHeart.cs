using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

namespace TimeGuardian.UI.HUD
{
    class HUDHeart : AnimationSprite
    {
        private int _currentCreateFrame, _currentDefaultFrame, _currentBreakFrame;
        private int[] _breakFrames = {0, 1, 2, 3, 4, 5, 6, 16};
        private int[] _createFrames = {7, 8, 9, 10, 11, 12, 13};
        private int[] _defaultFrames = {14, 15};

        private int _state;

        public HUDHeart(float x, float y) : base(UtilStrings.SpritesHUD + "spritesheet_health.png", 7, 3)
        {
            SetXY(x, y);
            _state = 0;
        }

        void Update()
        {
            switch (_state)
            {
                case 0:
                    CreationFrames();
                    break;
                case 1:
                    DefaultFrames();
                    break;
                case 2:
                    BreakFrames();
                    break;
            }
        }

        public void Break()
        {
            _currentBreakFrame = 0;
            _state = 2;
        }

        public void Create()
        {
            _currentCreateFrame = 0;
            _state = 0;
        }

        private void CreationFrames()
        {
            if (_currentCreateFrame < _createFrames.Length * 50 - 1) _currentCreateFrame++;
            else _state = 1;
            currentFrame = _createFrames[_currentCreateFrame / 50];
        }

        private void DefaultFrames()
        {
            if (_currentDefaultFrame < _defaultFrames.Length * 100 - 1) _currentDefaultFrame++;
            else _currentDefaultFrame = 0;
            currentFrame = _defaultFrames[_currentDefaultFrame / 100];
        }

        private void BreakFrames()
        {
            if (_currentBreakFrame < _breakFrames.Length*50 - 1) _currentBreakFrame++;
            else Destroy();
            currentFrame = _breakFrames[_currentBreakFrame/50];
        }
    }
}
