using Code.Prototyping.InputTranslation;
using dbasetemplate.Assets.Code.Prototyping.DataContainers.ContainerStructures;
using Godot;

namespace dbasetemplate.Assets.Code.Prototyping.Control;

public partial class CubeController : CharacterBody3D
{
    [Export]
    private CharacterData _playerData;
    [Export]
    public Node3D RotationLeader;

    private Vector2 _leftCross = Vector2.Zero;
    private bool _confirmPressed = false; 
    
    private Vector3 _moveDirection = Vector3.Zero;
    private Vector3 _targetVelocity = Vector3.Zero;
    private Vector3 _rotation = Vector3.Zero;

    public override void _Process(double delta)
    {
        _leftCross = Input.GetVector(InputMapping.LeftCrossHorizontalNegative,
            InputMapping.LeftCrossHorizontalPositive,
            InputMapping.LeftCrossVerticalNegative,
            InputMapping.LeftCrossVerticalPositive);

        _confirmPressed = Input.IsActionJustPressed(InputMapping.Confirm);
    }

    public override void _PhysicsProcess(double delta)
    {
        // get move direction
        _moveDirection.X = _leftCross.X;
        _moveDirection.Z = _leftCross.Y;
        _moveDirection = _moveDirection.Rotated(Vector3.Up, RotationLeader.Rotation.Y).Normalized();

        // get movement velocity
        _targetVelocity = _moveDirection * _playerData.Speed;

        // get jump velocity
        if (IsOnFloor() && _confirmPressed)
        {
            _targetVelocity.Y = _playerData.JumpStrength;
        }

        // get gravity velocity
        if (!IsOnFloor())
        {
            _targetVelocity.Y -= _playerData.FallAcceleration * (float)delta;
        }

        // apply target velocity
        Velocity = _targetVelocity;
        MoveAndSlide();
    }

}
