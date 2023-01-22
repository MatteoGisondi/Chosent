using Godot;
using System;
/// <summary>
/// This class is used to convert the level into an array
/// </summary>
namespace Chosent.Logic
{
	public class LevelToArray : Node2D
	{
		int[,] levelArray = new int[10, 10];
		// Called when the node enters the scene tree for the first time.
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


		}

		//  // Called every frame. 'delta' is the elapsed time since the previous frame.
		//  public override void _Process(float delta)
		//  {
		//      
		//  }
	}
}
