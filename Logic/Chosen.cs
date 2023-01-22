using Godot;
using System;
using System.Collections.Generic;

namespace Chosent.Logic
{

	public class Chosen : KinematicBody2D
	{
		private DateTime _lastInput;
		private float _inputDelay = 0.1f * 8;
		private int _movementSpeed = 64;

		private (int,int) start = (0,0);
		private (int,int) end = (7,7);

		private List<(int,int)> movements;
		private int _moveIndex = 0;

		private bool isPathGenerated = false;
		private bool isAtEnd = false;

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
			_lastInput = DateTime.MinValue; // Set it to the minimum value so we can move immediately
		}

		public void GetMovements()
		{
			var aStar = new AStar(this.GetLevel().levelArray);
			var path = aStar.FindPath(this.start, this.end);
			this.movements = AStar.GetMovements(path);
		}

		private LevelToArray GetLevel()
		{
			return (LevelToArray)this.GetParent();
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _PhysicsProcess(float delta)
		{
			// Check if we have waited long enough since the last input, if we have then move
			// if (CheckInputDelay())
			// {
			// 	Movement();
			// }
			if (this.GetLevel().IsRendered() && !isPathGenerated)
			{
				this.GetMovements();
				isPathGenerated = true;
			}
			if (this.GetLevel().IsRendered() && isPathGenerated && CheckInputDelay() && !isAtEnd)
			{
				_lastInput = DateTime.Now;
				this.Move(this.movements[_moveIndex++]);
				if (_moveIndex == this.movements.Count) isAtEnd = true;
			}

			if (this.GetLevel().IsRendered() && isPathGenerated && isAtEnd)
			{
				var globals = (GlobalVariables)GetNode<GlobalVariables>("/root/GlobalVariables");
				var nextLevel = ++globals.level;
				if (nextLevel < 4)
				{
					GetTree().ChangeScene($"res://Levels/Level{nextLevel}.tscn");
				}
				else
				{
					GetTree().Quit();
				}
			}

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

		public void Move((int,int) move)
		{
			// Move up, down, left, right on a grid with input from AStar!
			// Move up
			if (move == (1, 0))
			{
				Position += new Vector2(0, -_movementSpeed);
			}

			// Move down
			if (move == (-1, 0))
			{
				Position += new Vector2(0, _movementSpeed);
			}

			// Move left
			if (move == (0, 1))
			{
				Position += new Vector2(-_movementSpeed, 0);
			}

			// Move right
			if (move == (0, -1))
			{
				Position += new Vector2(_movementSpeed, 0);
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
}
