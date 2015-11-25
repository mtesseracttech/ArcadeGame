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

        private int _currentAlarmFrame;
        private bool _restoring;

        public HUDAbility(float x, float y, int MaxTime) : base(UtilStrings.SpritesHUD + "spritesheet_ability.png", 7, 3)
        {
            _maxTime = MaxTime;
            SetXY(x, y);
        }

        public void TimerTextureChanger(int time, bool restoring)
        {
            if(time > (_maxTime/10)*9) currentFrame = _timerFrames[0];
            else if (time > (_maxTime / 10) * 8) currentFrame = _timerFrames[1];
            else if (time > (_maxTime / 10) * 7) currentFrame = _timerFrames[2];
            else if (time > (_maxTime / 10) * 6) currentFrame = _timerFrames[3];
            else if (time > (_maxTime / 10) * 5) currentFrame = _timerFrames[4];
            else if (time > (_maxTime / 10) * 4) currentFrame = _timerFrames[5];
            else if (time > (_maxTime / 10) * 3) currentFrame = _timerFrames[6];
            else if (!restoring && time > 0) AlarmFrames();
            else currentFrame = _timerFrames[6];
        }

        private void AlarmFrames()
        {
            if (_currentAlarmFrame < _alarmFrames.Length * 50 - 1) _currentAlarmFrame++;
            else _currentAlarmFrame = 0;
            currentFrame = _alarmFrames[_currentAlarmFrame / 50];
        }

    }
}
