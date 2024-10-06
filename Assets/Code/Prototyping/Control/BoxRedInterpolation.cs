using Godot;
using System;

public partial class BoxRedInterpolation : CsgBox3D
{
	[Export]
	private Node3D _nodeToFollow;
	[Export]
	private float _followSpeed = 4.0f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Position = Position.Lerp(_nodeToFollow.Position, (float)delta * _followSpeed);
	}


}
