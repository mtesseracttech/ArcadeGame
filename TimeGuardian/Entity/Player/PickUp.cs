//using System.Runtime.Remoting.Messaging;
//using TimeGuardian.Level;
//
//namespace TimeGuardian.player
//{
//	public class PickUp : AnimationSprite
//	{
//		private LevelBase _level;
//		private int _firstFrame = 0, _lastFrame = 0;
//		private float _frame = 0.0f;
//
////		public PickUp(LevelBase level) : base(UtilStrings.SpriteDebug, 1, 1)
////		{
////			SetXY(500, 100);
////			_level = level;
////		}
////
////		public PickUp(string filename, int cols, int rows, LevelBase level) : base(filename, cols, rows)
////		{
////			SetXY(500, 100);
////			_level = level;
////		}
//
//		void Update(){
//			UpdateAnimation ();
//		}
//
//		private void UpdateAnimation()
//		{
//			_frame += 0.2f;
//			if (_frame > _lastFrame + 1)
//				_frame = _firstFrame;
//			if (_frame < _firstFrame)
//				_frame = _lastFrame;
//			SetFrame ((int)_frame);
//		}
//
//	}
//}
//
