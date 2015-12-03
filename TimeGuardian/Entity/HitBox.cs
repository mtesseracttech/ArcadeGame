using System;

namespace TimeGuardian.Entity
{
	public class HitBox : Sprite
	{
	    private bool _weakSpot;

        public HitBox (string filename, bool weakSpot) : base(filename)
        {
            _weakSpot = weakSpot;
        }

	    public bool IsWeakSpot()
	    {
	        return _weakSpot;
	    }
	}
}

