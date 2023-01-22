using Godot;
using System;

namespace Chosent.Logic;

public class Icon : Sprite
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	private DateTime _lastInput;
	private float _inputDelay = 0.1f;
	private int _movementSpeed = 64;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_lastInput = DateTime.MinValue; // Set it to the minimum value so we can move immediately
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		// Check if we have waited long enough since the last input, if we have then move
		//if (CheckInputDelay())
			//Movement();
	}

	/// <summary>
	/// Handles the movement of the icon
	/// </summary>
	public void Movement()
	{
		// Move up, down, left, right on a grid with arrow keys. Block diagomal movement
		//Move up
		if (Input.IsActionPressed("ui_up") && !Input.IsActionPressed("ui_left") && !Input.IsActionPressed("ui_right") && !Input.IsActionPressed("ui_down"))
		{
			Position += new Vector2(0, -_movementSpeed);
			_lastInput = DateTime.Now;
		}

		//Move down
		if (Input.IsActionPressed("ui_down") && !Input.IsActionPressed("ui_left") && !Input.IsActionPressed("ui_right") && !Input.IsActionPressed("ui_up"))
		{
			Position += new Vector2(0, _movementSpeed);
			_lastInput = DateTime.Now;
		}

		//Move left
		if (Input.IsActionPressed("ui_left") && !Input.IsActionPressed("ui_up") && !Input.IsActionPressed("ui_down") && !Input.IsActionPressed("ui_right"))
		{
			Position += new Vector2(-_movementSpeed, 0);
			_lastInput = DateTime.Now;
		}

		//Move right
		if (Input.IsActionPressed("ui_right") && !Input.IsActionPressed("ui_up") && !Input.IsActionPressed("ui_down") && !Input.IsActionPressed("ui_left"))
		{
			Position += new Vector2(_movementSpeed, 0);
			_lastInput = DateTime.Now;
		}
	}

	/// <summary>
	/// Checks if the input delay has been met
	/// </summary>
	public bool CheckInputDelay()
	{
		if ((DateTime.Now - _lastInput).TotalSeconds < _inputDelay)
		{
			return false;
		}
		else
		{
			return true;
		}
	}
}
