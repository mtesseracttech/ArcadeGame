using System;
using System.IO;

namespace TimeGuardian.Utility
{

	public class ArcadeButtons
	{

		private static int _player1_left = Key.A;
		private static int _player1_right = Key.D;
		private static int _player1_up = Key.W;
		private static int _player1_down = Key.S;

		private static int _player1_button1 = Key.F;
		private static int _player1_button2 = Key.G;
		private static int _player1_button3 = Key.H;
		private static int _player1_button4 = Key.V;
		private static int _player1_button5 = Key.B;
		private static int _player1_button6 = Key.N;

		private static int _player2_left = Key.J;
		private static int _player2_right = Key.L;
		private static int _player2_up = Key.I;
		private static int _player2_down = Key.K;

		private static int _player2_button1 = Key.INSERT;
		private static int _player2_button2 = Key.HOME;
		private static int _player2_button3 = Key.PAGE_UP;
		private static int _player2_button4 = Key.DELETE;
		private static int _player2_button5 = Key.END;
		private static int _player2_button6 = Key.PAGE_DOWN;
		
		private static int _player1_button = Key.X;
		private static int _player2_button = Key.DOT;
		private static int _credits_button = Key.Z;
		
		private static ArcadeButtons instance = new ArcadeButtons();

		public ArcadeButtons ()
		{
			if (File.Exists ("keys.txt")) {
				string[] keys = File.ReadAllLines ("keys.txt");
				foreach (string keyDefintion in keys) {
					string[] combo = keyDefintion.Split ('=');
					if (combo.Length < 2)
						continue;
					string keyName = combo [0].ToLower ();
					int keyCode;
					if (Int32.TryParse (combo [1], out keyCode)) {
						SetKey (keyName, keyCode);
					}
				}
			}
		}

		private void SetKey (string keyName, int keyCode)
		{
			Console.WriteLine (keyName, keyCode);
			switch (keyName) {
			case "p1left": _player1_left = keyCode; break;
			case "p1right": _player1_right = keyCode; break;
			case "p1up": _player1_up = keyCode; break;
			case "p1down": _player1_down = keyCode; break;
			case "p1button1": _player1_button1 = keyCode; break;
			case "p1button2": _player1_button2 = keyCode; break;
			case "p1button3": _player1_button3 = keyCode; break;
			case "p1button4": _player1_button4 = keyCode; break;
			case "p1button5": _player1_button5 = keyCode; break;
			case "p1button6": _player1_button6 = keyCode; break;

			case "p2left": _player2_left = keyCode; break;
			case "p2right": _player2_right = keyCode; break;
			case "p2up": _player2_up = keyCode; break;
			case "p2down": _player2_down = keyCode; break;
			case "p2button1": _player2_button1 = keyCode; break;
			case "p2button2": _player2_button2 = keyCode; break;
			case "p2button3": _player2_button3 = keyCode; break;
			case "p2button4": _player2_button4 = keyCode; break;
			case "p2button5": _player2_button5 = keyCode; break;
			case "p2button6": _player2_button6 = keyCode; break;

			case "p1button": _player1_button = keyCode; break;
			case "p2button": _player2_button = keyCode; break;
			case "creditsbutton": _credits_button = keyCode; break;
			}
		}

		public static int PLAYER1_LEFT {
			get { return _player1_left; }
		}
		public static int PLAYER1_RIGHT {
			get { return _player1_right; }
		}
		public static int PLAYER1_UP {
			get { return _player1_up; }
		}
		public static int PLAYER1_DOWN {
			get { return _player1_down; }
		}
		public static int PLAYER1_BUTTON1 {
			get { return _player1_button1; }
		}
		public static int PLAYER1_BUTTON2 {
			get { return _player1_button2; }
		}
		public static int PLAYER1_BUTTON3 {
			get { return _player1_button3; }
		}
		public static int PLAYER1_BUTTON4 {
			get { return _player1_button4; }
		}
		public static int PLAYER1_BUTTON5 {
			get { return _player1_button5; }
		}
		public static int PLAYER1_BUTTON6 {
			get { return _player1_button6; }
		}
		public static int PLAYER2_LEFT {
			get { return _player2_left; }
		}
		public static int PLAYER2_RIGHT {
			get { return _player2_right; }
		}
		public static int PLAYER2_UP {
			get { return _player2_up; }
		}
		public static int PLAYER2_DOWN {
			get { return _player2_down; }
		}
		public static int PLAYER2_BUTTON1 {
			get { return _player2_button1; }
		}
		public static int PLAYER2_BUTTON2 {
			get { return _player2_button2; }
		}
		public static int PLAYER2_BUTTON3 {
			get { return _player2_button3; }
		}
		public static int PLAYER2_BUTTON4 {
			get { return _player2_button4; }
		}
		public static int PLAYER2_BUTTON5 {
			get { return _player2_button5; }
		}
		public static int PLAYER2_BUTTON6 {
			get { return _player2_button6; }
		}

		public static int PLAYER1_BUTTON {
			get { return _player1_button; }
		}
		public static int PLAYER2_BUTTON {
			get { return _player2_button; }
		}
		public static int CREDITS_BUTTON {
			get { return _credits_button; }
		}

	}
}

