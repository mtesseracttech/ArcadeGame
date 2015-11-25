using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeGuardian.UI.HUD
{
    class HUDAbility : AnimationSprite
    {
        private int _maxTime;

        private int[] _timerFrames = { 0,1,2,3,4,5,6 };
        private int[] _alarmFrames = { 13, 20};

        private const int MaxDiv = 100;
        private int _currentAlarmFrame;
        private bool _restoring;

        public HUDAbility(float x, float y, int MaxTime) : base(UtilStrings.SpritesHUD + "spritesheet_ability.png", 7, 3)
        {
            _maxTime = MaxTime;
            SetXY(x, y);
        }

        public void TimerTextureChanger(int time, bool restoring)
        {
            if(!restoring && time > (_maxTime/MaxDiv)* (MaxDiv-1)) currentFrame = _timerFrames[0];
            else if (!restoring && time > (_maxTime / MaxDiv) * (MaxDiv-2)) currentFrame = _timerFrames[1];
            else if (!restoring && time > (_maxTime / MaxDiv) * (MaxDiv-3)) currentFrame = _timerFrames[2];
            else if (!restoring && time > (_maxTime / MaxDiv) * (MaxDiv-4)) currentFrame = _timerFrames[3];
            else if (!restoring && time > (_maxTime / MaxDiv) * (MaxDiv-5)) currentFrame = _timerFrames[4];
            else if (!restoring && time > (_maxTime / MaxDiv) * (MaxDiv-6)) currentFrame = _timerFrames[5];
            else if (!restoring && time > (_maxTime / MaxDiv) * (MaxDiv-7)) currentFrame = _timerFrames[6];
            else if (restoring && time > 0) AlarmFrames();
        }

        private void AlarmFrames()
        {
            if (_currentAlarmFrame < _alarmFrames.Length * 5 - 1) _currentAlarmFrame++;
            else _currentAlarmFrame = 0;
            currentFrame = _alarmFrames[_currentAlarmFrame / 5];
        }

    }
}
