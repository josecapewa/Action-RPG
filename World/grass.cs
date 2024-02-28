using Godot;
using System;

public partial class grass : Node2D
{
	private void CreateGrassEffect(){
		var GrassEffect = GD.Load<PackedScene>("res://Effects/grass_efect.tscn");
		var grassEffect = GrassEffect.Instantiate() as Node2D;
		var world = GetTree().CurrentScene;
		world.AddChild(grassEffect);
		grassEffect.GlobalPosition = GlobalPosition;
	}

	private void OnHurtBoxAreaEntered(Area2D area)
	{
		CreateGrassEffect();
		QueueFree();
	}
}
