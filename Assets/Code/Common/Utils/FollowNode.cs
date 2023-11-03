using Godot;

namespace dbasetemplate.Assets.Code.Common.Utils;

public partial class FollowNode : Node
{
    [Export]
    private Node3D _nodeFollower;
    [Export]
    private Node3D _nodeToFollow;
    [Export]
    private Vector3 _offset;

    public override void _Process(double delta)
    {
        _nodeFollower.Position = _nodeToFollow.Position + _offset;
    }

}
