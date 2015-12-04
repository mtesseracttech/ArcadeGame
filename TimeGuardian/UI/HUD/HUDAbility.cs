using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeGuardian.UI.HUD
{
    class HUDAbility : AnimationSprite
    {
        private int _maxTime;

        private int[] _timerFrames = { 0,1,2,3,4,5,6,19,18,12,11,10};
        private int[] _alarmFrames = { 13, 20};

        private const int MaxDiv = 50;
        private int _currentAlarmFrame;

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
            else if (!restoring && time > (_maxTime / MaxDiv) * (MaxDiv-20)) currentFrame = _timerFrames[6];
            else if (!restoring && time > (_maxTime / MaxDiv) * (MaxDiv-25)) currentFrame = _timerFrames[7];
            else if (!restoring && time > (_maxTime / MaxDiv) * (MaxDiv-30)) currentFrame = _timerFrames[8];
            else if (!restoring && time > (_maxTime / MaxDiv) * (MaxDiv-35)) currentFrame = _timerFrames[9];
            else if (!restoring && time > (_maxTime / MaxDiv) * (MaxDiv-40)) currentFrame = _timerFrames[10];
            else if (!restoring && time > (_maxTime / MaxDiv) * (MaxDiv-45)) currentFrame = _timerFrames[11];
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
