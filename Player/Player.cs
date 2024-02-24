using Godot;
using System;

public partial class Player : CharacterBody2D
{
	const float ACCELERATION = 500;
	const float MAX_SPEED = 80;
	const float FRICTION = 500;
	
	Vector2 velocity = Vector2.Zero;
	
	AnimationPlayer animationPlayer;
	
	public override void _Ready(){
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");;
	}
		
	public override void _PhysicsProcess(double delta)
	{
		var input = Vector2.Zero;
		input.X = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
		input.Y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
		input = input.Normalized();
		
		if(input!=Vector2.Zero){
			if(input.X > 0){
				animationPlayer.Play("RunRight");
			} else{
				animationPlayer.Play("RunLeft");
			}
			velocity = velocity.MoveToward(input * MAX_SPEED, ACCELERATION * (float)delta);
		} else{
			animationPlayer.Play("IdleRight");
			velocity = velocity.MoveToward(Vector2.Zero, FRICTION * (float)delta);
		}
		GD.Print(velocity);
		Velocity = velocity;
		MoveAndSlide();
	}
}
