using Godot;
using System;

public class GlobalVariables : Node
{
	public int _hp = 0;
	public int _str = 0;
	public int _dex = 0;
	public int _int = 0;

	public SpriteFrames _nextHazardPlacement;

	public int level = 1;

	public int gameState = 0;
	public int health = 40;
}
