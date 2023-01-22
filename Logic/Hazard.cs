using Godot;
using System;

public class Hazard : Node
{
	
	public int _hp;
	public int _str;
	public int _dex;
	public int _int;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_hp = 0;
		_str = 0;
		_dex = 0;
		_int = 0;
		SetStats(1, 2, 3, 4);
	}
	
	public void SetStats(int hp = -1, int str = -1, int dex = -1, int intel = -1)
	{
		if (hp != -1) {	_hp = hp; }
		if (str != -1) {	_str = str; }
		if (dex != -1) {	_dex = dex; }
		if (intel != -1) {	_int = intel; }
	}
}
