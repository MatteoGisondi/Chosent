using Godot;
using System;

public class TitleScreen : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	public override void _Process(float delta)
	{
		
	}

	public override void _Input(InputEvent inputEvent)
	{
		if (inputEvent.IsActionPressed("ui_accept"))
		{
			GD.Print("ui_accept pressed!");
			GetTree().ChangeScene("res://SecondScene.tscn");
			//GetTree().ChangeScene("res://SecondScene.tscn");
		}
	}
}
