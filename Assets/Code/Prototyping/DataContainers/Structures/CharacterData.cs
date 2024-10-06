using Godot;

namespace dbasetemplate.Assets.Code.Prototyping.DataContainers.ContainerStructures;

[Tool]
public partial class CharacterData : Resource
{
    [Export]
    public float Speed = 7.0f;
    [Export]
    public float JumpStrength = 25f;
    [Export]
    public float FallAcceleration = 50f;
}
