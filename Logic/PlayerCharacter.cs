using Godot;
using System;

public class PlayerCharacter : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	
	private int _hp;
	private int _str;
	private int _dex;
	private int _int;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_hp = 0;
		_str = 0;
		_dex = 0;
		_int = 0;
		var globals = GetNode<GlobalVariables>("/root/GlobalVariables");
		SetStats(globals._hp, globals._str, globals._dex, globals._int);
	}
	
	public void SetStats(int hp = -1, int str = -1, int dex = -1, int intel = -1)
	{
		if (hp != -1) {	_hp = hp; }
		if (str != -1) {	_str = str; }
		if (dex != -1) {	_dex = dex; }
		if (intel != -1) {	_int = intel; }
		
		GD.Print("Stats:");
		GD.Print("HP: " + _hp.ToString());
		GD.Print("Str: " + _str.ToString());
		GD.Print("Dex: " + _dex.ToString());
		GD.Print("Int: " + _int.ToString());
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
