using Godot;
using System;

public class CharacterCreation : Control
{
	private static int InitialPoints = 10;
	
	RichTextLabel _pointsRemaining;
	int _points;
	TextureButton _hpDown;
	TextureButton _hpUp;
	RichTextLabel _hpValue;
	int _hp;
	TextureButton _strDown;
	TextureButton _strUp;
	RichTextLabel _strValue;
	int _str;
	TextureButton _dexDown;
	TextureButton _dexUp;
	RichTextLabel _dexValue;
	int _dex;
	TextureButton _intDown;
	TextureButton _intUp;
	RichTextLabel _intValue;
	int _int;
	
	Button _continueButton;
	
	public override void _Ready()
	{
		_points = InitialPoints;
		_hp = 1;
		_str = 1;
		_dex = 1;
		_int = 1;
		
		_pointsRemaining = (RichTextLabel)GetNode("PointsRemaining");
		_pointsRemaining = (RichTextLabel)GetNode("PointsRemaining");
		var statBlock = (HBoxContainer)GetNode("StatBlock");
		var statDowns = (VBoxContainer)statBlock.GetNode("StatDowns");
		var statValues = (VBoxContainer)statBlock.GetNode("StatValues");
		var statUps = (VBoxContainer)statBlock.GetNode("StatUps");
		
		// Down buttons
		_hpDown = (TextureButton)statDowns.GetNode("HPButtonDown");
		_strDown = (TextureButton)statDowns.GetNode("StrButtonDown");
		_dexDown = (TextureButton)statDowns.GetNode("DexButtonDown");
		_intDown = (TextureButton)statDowns.GetNode("IntButtonDown");
		_hpDown.Connect("pressed", this, nameof(HPDown));
		_strDown.Connect("pressed", this, nameof(StrDown));
		_dexDown.Connect("pressed", this, nameof(DexDown));
		_intDown.Connect("pressed", this, nameof(IntDown));
		
		// Labels
		_hpValue = (RichTextLabel)statValues.GetNode("HPValue");
		_strValue = (RichTextLabel)statValues.GetNode("StrValue");
		_dexValue = (RichTextLabel)statValues.GetNode("DexValue");
		_intValue = (RichTextLabel)statValues.GetNode("IntValue");
		
		// Up buttons
		_hpUp = (TextureButton)statUps.GetNode("HPButtonUp");
		_strUp = (TextureButton)statUps.GetNode("StrButtonUp");
		_dexUp = (TextureButton)statUps.GetNode("DexButtonUp");
		_intUp = (TextureButton)statUps.GetNode("IntButtonUp");
		_hpUp.Connect("pressed", this, nameof(HPUp));
		_strUp.Connect("pressed", this, nameof(StrUp));
		_dexUp.Connect("pressed", this, nameof(DexUp));
		_intUp.Connect("pressed", this, nameof(IntUp));
		
		_continueButton = (Button)GetNode("ContinueButton");
		_continueButton.Connect("pressed", this, nameof(StartGame));
		
		UpdateLabels();
	}
	
	private void UpdateLabels()
	{
		_pointsRemaining.Text = "You have " + _points.ToString() + " remaining!";
		_hpValue.Text = _hp.ToString();
		_strValue.Text = _str.ToString();
		_dexValue.Text = _dex.ToString();
		_intValue.Text = _int.ToString();
		
		_continueButton.Disabled = (_points != 0);
		_hpDown.Disabled = (_hp <= 1);
		_hpUp.Disabled = (_points <= 0);
		_strDown.Disabled = (_str <= 1);
		_strUp.Disabled = (_points <= 0);
		_dexDown.Disabled = (_dex <= 1);
		_dexUp.Disabled = (_points <= 0);
		_intDown.Disabled = (_int <= 1);
		_intUp.Disabled = (_points <= 0);
	}
	
	private void HPDown()
	{
		if (_hp > 1)
		{
			_hp--;
			_points++;
			UpdateLabels();
		}
		UpdateLabels();
	}
	private void HPUp()
	{
		if (_points > 0)
		{
			_hp++;
			_points--;
		}
		UpdateLabels();
	}
	private void StrDown()
	{
		if (_str > 1)
		{
			_str--;
			_points++;
		}
		UpdateLabels();
	}
	private void StrUp()
	{
		if (_points > 0)
		{
			_str++;
			_points--;
		}
		UpdateLabels();
	}
	private void DexDown()
	{
		if (_dex > 1)
		{
			_dex--;
			_points++;
		}
		UpdateLabels();
	}
	private void DexUp()
	{
		if (_points > 0)
		{
			_dex++;
			_points--;
		}
		UpdateLabels();
	}
	private void IntDown()
	{
		if (_int > 1)
		{
			_int--;
			_points++;
		}
		UpdateLabels();
	}
	private void IntUp()
	{
		if (_points > 0)
		{
			_int++;
			_points--;
		}
		UpdateLabels();
	}
	
	private void StartGame()
	{
		//var globals = (GlobalVariables)GetTree().GetRoot().GetNode("/root/autoload/GlobalVariables");
		var globals = GetNode<GlobalVariables>("/root/GlobalVariables");
		globals._hp = _hp;
		globals._str = _str;
		globals._dex = _dex;
		globals._int = _int;
		//GD.Print("End of Character Creation!");
		GetTree().ChangeScene("res://Levels/MainLevel.tscn");
	}
}
