using Godot;
using System;

public class TitleScreen : Node
{
	public override void _Ready()
	{
		var button = (Button)GetNode("StartButton");
		button.Connect("pressed", this, nameof(StartGame));
	}
	
	private void StartGame()
	{
		GetTree().ChangeScene("res://Levels/CharacterCreation.tscn");
	}
}
