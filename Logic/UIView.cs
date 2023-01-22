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
	
	private TextureButton _batButton;
	private TextureButton _batBlueButton;
	private TextureButton _batGreenButton;
	private TextureButton _batRedButton;
	private SpriteFrames _nextHazardPlacement;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_gameState = 0;
		
		// TODO! TODO! TODO!
		_batButton = (TextureButton)GetNode("BatButtonName");
		_batBlueButton = (TextureButton)GetNode("BatButtonName");
		_batGreenButton = (TextureButton)GetNode("BatButtonName");
		_batRedButton = (TextureButton)GetNode("BatButtonName");
		//
		
		//_batButton.Connect("pressed", this, nameof(PlaceBat));
		//_batBlueButton.Connect("pressed", this, nameof(PlaceBatBlue));
		//_batGreenButton.Connect("pressed", this, nameof(PlaceBatGreen));
		//_batRedButton.Connect("pressed", this, nameof(PlaceBatRed));
	}
	
	private void PlaceBat()
	{
		var globals = GetNode<GlobalVariables>("/root/GlobalVariables");
		globals._nextHazardPlacement = (SpriteFrames)ResourceLoader.Load("res://assets/Bat.tres", "SpriteFrames");
	}
	
	private void PlaceBatBlue()
	{
		var globals = GetNode<GlobalVariables>("/root/GlobalVariables");
		globals._nextHazardPlacement = (SpriteFrames)ResourceLoader.Load("res://assets/BatBlue.tres", "SpriteFrames");
	}
	
	private void PlaceBatGreen()
	{
		var globals = GetNode<GlobalVariables>("/root/GlobalVariables");
		globals._nextHazardPlacement = (SpriteFrames)ResourceLoader.Load("res://assets/BatGreen.tres", "SpriteFrames");
	}
	
	private void PlaceBatRed()
	{
		var globals = GetNode<GlobalVariables>("/root/GlobalVariables");
		globals._nextHazardPlacement = (SpriteFrames)ResourceLoader.Load("res://assets/BatRed.tres", "SpriteFrames");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
