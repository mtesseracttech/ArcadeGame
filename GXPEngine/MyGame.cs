using System.Drawing;
using GXPEngine;

public class MyGame : Game
{	

	public MyGame () : base(1400, 700, false)
	{
        Canvas background = new Canvas(game.width, game.width);
	    background.graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0,0, 1400, 700));

        AddChild(background);
	    Player player1 = new Player();
        AddChild(player1);
        
        Player gun = new Player(); //Need to find a good way to implement multiple guns
	    AddChild(gun);

        Player bullet = new Player(); //Need to find way to make different bullets;
        AddChild(bullet); 

	}

	void Update () 
	{

	}

	static void Main() {
		new MyGame().Start();
	}
}

