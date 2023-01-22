using Godot;
using System;

public class TitleScreen : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private Node startButton; 

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var button = (Button)GetNode("StartButton");
		button.Connect("pressed", this, nameof(StartGame));
	}
	
	public void StartGame()
	{
		GetTree().ChangeScene("res://Levels/MainLevel.tscn");
	}
}
