using System;
using System.Collections.Generic;
using GXPEngine;

public class MyGame : Game
{
    private string _state;
    private List<int[,]> _levels;


	public MyGame () : base(800, 600, false)
	{
	    SetState("Exit");
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
            case "Exit":
                Environment.Exit(0);
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

