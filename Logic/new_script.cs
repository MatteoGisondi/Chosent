using Godot;
using System;

public class new_script : Area2D
{
	private int _moveSpeed = 100;
	private string _up;
	private string _down;

	public override void _Ready()
	{
		_up = "move_up";
		_down = "move_down";
	}

	public override void _Process(float delta)
	{
		// Called every frame
	}
	
	public override void _Input(InputEvent inputEvent)
{
	if (inputEvent.IsActionPressed(_up))
	{
		GD.Print("my_action occurred!");
	}
	
	/*float input = Input.IsActionPressed(move_down) - Input.IsActionPressed(move_up);
		Vector2 position = Position; // Required so that we can modify position.y.
		position += new Vector2(0, input * _moveSpeed * delta);
		position.y = Mathf.Clamp(position.y, 16, GetViewportRect().Size.y - 16);
		Position = position;*/
}
}
