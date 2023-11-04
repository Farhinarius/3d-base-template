using Godot;

namespace dbasetemplate.Assets.Code.Common.Utils;

public static class Node3DExtensions
{
    public static void Set(this Node3D node3d, bool state = true)
    {
        node3d.SetProcess(state);
        node3d.SetPhysicsProcess(state);
        node3d.SetProcessInput(state);
        node3d.SetProcessUnhandledInput(state);
        node3d.SetProcessUnhandledKeyInput(state);
        node3d.Visible = state;
    }
}
