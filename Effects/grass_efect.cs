using Godot;
using System;

public partial class grass_efect : Node2D
{
	AnimatedSprite2D animatedSprite;
	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		animatedSprite.Play("Animate");
	}

	private void OnAnimatedSprite2dAnimationFinished()
	{
		QueueFree();
	}

}
