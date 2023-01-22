using Godot;
using System;
/// <summary>
/// This class is used to convert the level into an array
/// </summary>
namespace Chosent.Logic
{
	public class LevelToArray : Node2D
	{
		public int[,] levelArray = new int[8, 8];
		// Called when the node enters the scene tree for the first time.

		private bool isRendered = false;

		public override void _Ready()
		{
			// Convert the level into an array
			// Get the level
			var level = this;

			// Initialize level array to 0
			for (int y = 0; y < levelArray.GetLength(0); y++)
			{
				for (int x = 0; x < levelArray.GetLength(1); x++)
				{
					levelArray[y, x] = 0;
				}
			}
			// Get the level's children
			var levelChildren = level.GetChildren();
			GD.Print(levelChildren);

			// Loop through the level's children and add them to the array

			// Loop through the level's children
			foreach (var child in levelChildren)
			{
				// Check if the child is a block
				if (child is Block)
				{
					// Get the block's position
					var blockPosition = ((Block)child).Position;

					// Convert the block's position to an array position

					// Add the block to the array
					levelArray[(int)(blockPosition.y/64.0 - 0.5), (int)(blockPosition.x/64.0 - 0.5)] = 1;
				}
			}

			// Print the array nicely
			for (int y = 0; y < levelArray.GetLength(0); y++)
			{
				string line = "";
				for (int x = 0; x < levelArray.GetLength(1); x++)
				{
					line += levelArray[y, x] + " ";
				}
				GD.Print(line);
			}

			this.isRendered = true;
		}

		public bool IsRendered()
		{
			return this.isRendered;
		}

		// Press 1 on the keyboard to spawn a yellow bat at mouse position
		public override void _Input(InputEvent @event)
		{
			// if key1 on the keyboard is pressed spawn a yellow bat at mouse position

			if (Input.IsActionPressed("key1"))
			{
				// Get the mouse position
				var mousePosition = GetViewport().GetMousePosition();

				GD.Print($"{mousePosition.x}, {mousePosition.y}");

				// Convert the mouse position to a tile position and snap to center of nearest tile
				var tilePosition = new Vector2((mousePosition.x - 200)/0.8f, (mousePosition.y - 25)/0.8f);

				// Make tilePosition snap to a grid. Adjust for it being slightly off center
				tilePosition.x = (float)Math.Round(tilePosition.x/64.0 - 0.5)*64.0f + 32.0f;
				tilePosition.y = (float)Math.Round(tilePosition.y/64.0 - 0.5)*64.0f + 32.0f;
				

				// Add a hazard as a child of this node and set the position to the tile position
				var hazard = (Hazard)ResourceLoader.Load<PackedScene>("res://Objects/Hazard.tscn").Instance();
				hazard.Position = tilePosition;
				this.AddChild(hazard);

				// change the hazard sprite to yellow bat
				var sprite = (AnimatedSprite)(hazard.GetNode("Sprite"));
				sprite.Frames = (SpriteFrames)ResourceLoader.Load("res://assets/Bat.tres", "SpriteFrames");
				hazard.ResetStats();
				
			}

			// if key2 on the keyboard is pressed spawn a red bat at mouse position

			if (Input.IsActionPressed("key2"))
			{
				// Get the mouse position
				var mousePosition = GetViewport().GetMousePosition();

				GD.Print($"{mousePosition.x}, {mousePosition.y}");

				// Convert the mouse position to a tile position and snap to center of nearest tile
				var tilePosition = new Vector2((mousePosition.x - 200)/0.8f, (mousePosition.y - 25)/0.8f);

				// Make tilePosition snap to a grid. Adjust for it being slightly off center
				tilePosition.x = (float)Math.Round(tilePosition.x/64.0 - 0.5)*64.0f + 32.0f;
				tilePosition.y = (float)Math.Round(tilePosition.y/64.0 - 0.5)*64.0f + 32.0f;
				

				// Add a hazard as a child of this node and set the position to the tile position
				var hazard = (Hazard)ResourceLoader.Load<PackedScene>("res://Objects/Hazard.tscn").Instance();
				hazard.Position = tilePosition;
				this.AddChild(hazard);

				// change the hazard sprite to red bat
				var sprite = (AnimatedSprite)(hazard.GetNode("Sprite"));
				sprite.Frames = (SpriteFrames)ResourceLoader.Load("res://assets/BatBlue.tres", "SpriteFrames");
				hazard.ResetStats();
				
			}

			// if key3 on the keyboard is pressed spawn a blue bat at mouse position

			if (Input.IsActionPressed("key3"))
			{
				// Get the mouse position
				var mousePosition = GetViewport().GetMousePosition();

				GD.Print($"{mousePosition.x}, {mousePosition.y}");

				// Convert the mouse position to a tile position and snap to center of nearest tile
				var tilePosition = new Vector2((mousePosition.x - 200)/0.8f, (mousePosition.y - 25)/0.8f);

				// Make tilePosition snap to a grid. Adjust for it being slightly off center
				tilePosition.x = (float)Math.Round(tilePosition.x/64.0 - 0.5)*64.0f + 32.0f;
				tilePosition.y = (float)Math.Round(tilePosition.y/64.0 - 0.5)*64.0f + 32.0f;
				

				// Add a hazard as a child of this node and set the position to the tile position
				var hazard = (Hazard)ResourceLoader.Load<PackedScene>("res://Objects/Hazard.tscn").Instance();
				hazard.Position = tilePosition;
				this.AddChild(hazard);

				// change the hazard sprite to blue bat
				var sprite = (AnimatedSprite)(hazard.GetNode("Sprite"));
				sprite.Frames = (SpriteFrames)ResourceLoader.Load("res://assets/BatGreen.tres", "SpriteFrames");
				hazard.ResetStats();
				
			}

			// if key4 on the keyboard is pressed spawn a green bat at mouse position

			if (Input.IsActionPressed("key4"))
			{
				// Get the mouse position
				var mousePosition = GetViewport().GetMousePosition();

				GD.Print($"{mousePosition.x}, {mousePosition.y}");

				// Convert the mouse position to a tile position and snap to center of nearest tile
				var tilePosition = new Vector2((mousePosition.x - 200)/0.8f, (mousePosition.y - 25)/0.8f);

				// Make tilePosition snap to a grid. Adjust for it being slightly off center
				tilePosition.x = (float)Math.Round(tilePosition.x/64.0 - 0.5)*64.0f + 32.0f;
				tilePosition.y = (float)Math.Round(tilePosition.y/64.0 - 0.5)*64.0f + 32.0f;
				

				// Add a hazard as a child of this node and set the position to the tile position
				var hazard = (Hazard)ResourceLoader.Load<PackedScene>("res://Objects/Hazard.tscn").Instance();
				hazard.Position = tilePosition;
				this.AddChild(hazard);

				// change the hazard sprite to green bat
				var sprite = (AnimatedSprite)(hazard.GetNode("Sprite"));
				sprite.Frames = (SpriteFrames)ResourceLoader.Load("res://assets/BatRed.tres", "SpriteFrames");
				hazard.ResetStats();
				
			}
		}

		


	}
}
