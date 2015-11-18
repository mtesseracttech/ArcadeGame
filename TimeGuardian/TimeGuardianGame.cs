using System;
using System.Collections.Generic;
using TimeGuardian;
using TimeGuardian.UI.Menu;
using TimeGuardian.Utility;

public class TimeGuardianGame : Game
{
    private string _state;
    private List<int[,]> _levels;
    private MainMenu _menu;


	public TimeGuardianGame () : base(800, 600, false)
	{
	    _levels = FileReader.LevelsCompiler(2);
	    SetState("MainMenu");
	}

    //List of States:
    //MainMenu: Goes to the main menu
    //Exit: Instantly exits the game
    //Level1 - 3: Loads the respective level
    //BossFight1 - 3: Loads Respective Bossfight
    //Won: State for when you won the game
    //Lose: State for when it's Game Over
    //Pause: Makes all the entities pause the things they do in their Update()

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
                break;
        }
    }

    private void StartState()
    {
        switch (_state)
        {
            case "MainMenu":
                _menu = new MainMenu(this);
                AddChild(_menu);
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
		new TimeGuardianGame().Start();
	}
}

