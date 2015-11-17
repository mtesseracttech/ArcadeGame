using GXPEngine;

public class MyGame : Game
{
    private string _state;

	public MyGame () : base(800, 600, false)
	{
	    SetState("MainMenu");
	}

    public void SetState(string state)
    {
        if (state == _state) return;
        StopState();
        _state = state;
        StartState();
    }

    private void StopState()
    {
        switch (_state)
        {
            case "MainMenu":
                //_menu.Destroy();
                break;
        }
    }

    private void StartState()
    {
        switch (_state)
        {
            case "MainMenu":
                //_menu = new Menu(this);
                //AddChild(_menu);
                break;
        }
    }


    void Update () 
	{
		//empty
	}

	static void Main() {
		new MyGame().Start();
	}
}

