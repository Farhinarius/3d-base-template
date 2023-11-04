using Godot;

public partial class FollowNode : Node
{
    [Export]
    private Node3D _nodeFollower;
    [Export]
    private Node3D _nodeToFollow;
    [Export]
    private Vector3 _offset;

    private Node _someNode;

    public override void _Process(double delta)
    {
        _nodeFollower.Position = _nodeToFollow.Position + _offset;
    }
}
