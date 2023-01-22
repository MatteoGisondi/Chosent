using Godot;
using System;

public class UIView : Node
{
	/// <summary>
	/// Preparation phase = 0;
	/// Placement phase = 1;
	/// Game phase = 2;
	/// </summary>
	private int _gameState;
	
	private Button readyButton;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_gameState = 0;
		var globals = GetNode<GlobalVariables>("/root/GlobalVariables");
		globals.gameState = _gameState;
		
		readyButton = (Button)GetNode("StartButton");
		readyButton.Connect("pressed", this, nameof(StartRound));
		
		var healthAmount = (RichTextLabel)GetNode("HealthAmount");
		var stats = (RichTextLabel)GetNode("Stats");
		stats.Text = "Aliven't: " + globals._hp +
					"\nStronkn't: " + globals._str +
					"\nDexn't: " + globals._dex +
					"\nIntn't: " + globals._int;
	}
	
	private void StartRound()
	{
		_gameState = 1;
		var globals = GetNode<GlobalVariables>("/root/GlobalVariables");
		globals.gameState = _gameState;
		readyButton.Disabled = true;
	}
}
