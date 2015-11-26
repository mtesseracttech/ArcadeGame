using System;
using TimeGuardian;
using TimeGuardian.Level;
using TimeGuardian.player;
using TimeGuardian.UI.Menu;

public class TimeGuardianGame : Game
{
    private string _state;
    private MainMenu _menu;
    private HighScores _scores;
    private Credits _credits;
    private Level1 _level1;
    private Player _player;

	public TimeGuardianGame () : base(1024, 768, false, false)

	{
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

    public void SetState(string state, bool restart = false)
    {
        if (state == _state && !restart) return;
        StopState();
        _state = state;
        StartState();
    }

    private void StopState()
    {
        switch (_state)
        {
            case "MainMenu":
                _menu.Destroy();
                break;
            case "HighScores":
                _scores.Destroy();
                break;
            case "Credits":
                _credits.Destroy();
                break;
            case "Level1":
                _player = _level1.GetPlayer();
                _level1.Destroy();
                break;
                /*
            case "Level2":
                _player = _level2.GetPlayer();
                _level2.Destroy();
                break;
            case "Level3":
                _player = _level3.GetPlayer();
                _level3.Destroy();
                break;
                */
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
            case "HighScores":
                _scores = new HighScores(this);
                AddChild(_scores);
                break;
            case "Credits":
                _credits = new Credits(this);
                AddChild(_credits);
                break;
            case "Level1":
                _level1 = new Level1(this);
                AddChild(_level1);
                break;
            case "Level2":
                //_level = new Level2(this);
                //AddChild(_level2);
                break;
            case "Level3":
                //_level = new Level2(this);
                //AddChild(_level3);
                break;
            case "Exit":
                Environment.Exit(0);
                break;
            default:
                throw new Exception("You tried to load a non-existant state");
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

