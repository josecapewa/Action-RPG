using Godot;
using System;

public partial class Player : CharacterBody2D
{
	const float ACCELERATION = 500;
	const float MAX_SPEED = 80;
	const float FRICTION = 500;
	
	Vector2 velocity = Vector2.Zero;
	
	AnimationPlayer animationPlayer;
	AnimationTree animationTree;
	AnimationNodeStateMachinePlayback animationState;
	
	public override void _Ready(){
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		animationTree = GetNode<AnimationTree>("AnimationTree");
		animationState = animationTree.Get("parameters/playback").Obj as AnimationNodeStateMachinePlayback;;
	}
		
	public override void _PhysicsProcess(double delta)
	{
		var input = Vector2.Zero;
		input.X = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
		input.Y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
		input = input.Normalized();
		
		if(input!=Vector2.Zero){
			animationTree.Set("parameters/Idle/blend_position", input);
			animationTree.Set("parameters/Run/blend_position", input);
			animationState.Travel("Run");
			velocity = velocity.MoveToward(input * MAX_SPEED, ACCELERATION * (float)delta);
		} else{
			animationState.Travel("Idle");
			velocity = velocity.MoveToward(Vector2.Zero, FRICTION * (float)delta);
		}
		
		Velocity = velocity;
		MoveAndSlide();
	}
}
