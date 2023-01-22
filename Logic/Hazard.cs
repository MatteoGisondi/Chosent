using Godot;
using System;
namespace Chosent.Logic
{
	public class Hazard : StaticBody2D
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
			ResetStats();
		}

		public void ResetStats()
		{
			var sprite = (AnimatedSprite)GetNode("Sprite");
			if (sprite.Frames == ResourceLoader.Load("res://assets/Bat.tres", "SpriteFrames"))
			{
				GD.Print("Bat");
				SetStats(1, 1, 3, 1);
			}
			else if (sprite.Frames == ResourceLoader.Load("res://assets/BatBlue.tres", "SpriteFrames"))
			{
				GD.Print("BatBlue");
				SetStats(1, 1, 1, 3);
			}
			else if (sprite.Frames == ResourceLoader.Load("res://assets/BatGreen.tres", "SpriteFrames"))
			{
				GD.Print("BatGreen");
				SetStats(3, 1, 1, 1);
			}
			else if (sprite.Frames == ResourceLoader.Load("res://assets/BatRed.tres", "SpriteFrames"))
			{
				GD.Print("BatRed");
				SetStats(1, 3, 1, 1);
			}
			else
			{
				GD.Print("Other");
				SetStats(1, 1, 1, 1);
			}
		}

		public void SetStats(int hp = -1, int str = -1, int dex = -1, int intel = -1)
		{
			if (hp != -1) { _hp = hp; }
			if (str != -1) { _str = str; }
			if (dex != -1) { _dex = dex; }
			if (intel != -1) { _int = intel; }
		}
	}
}
