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
    private LevelBase _level;
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
                _menu.Destroy();
                break;
            case "HighScores":
                _scores.Destroy();
                break;
            case "Credits":
                _credits.Destroy();
                break;
            case "Level1":
                _player = _level.GetPlayer();
                _level.Destroy();
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
            case "HighScores":
                _scores = new HighScores(this);
                AddChild(_scores);
                break;
            case "Credits":
                _credits = new Credits(this);
                AddChild(_credits);
                break;
            case "Level1":
                _level = new Level1(this, new []{2}, 1);
                AddChild(_level);
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

