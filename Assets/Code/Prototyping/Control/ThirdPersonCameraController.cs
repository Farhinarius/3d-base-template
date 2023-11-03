using Godot;

namespace dbasetemplate.Assets.Code.Prototyping.Control;

public partial class ThirdPersonCameraController : Node
{
    [Export]
    private Node3D _cameraSpring;
    [Export]
    private float _cameraSensivity = 0.002f;       // default is 0.005f

    public Vector2 _mouseOffset = Vector2.Zero;
    private Vector3 _cameraRotation;

    public override void _UnhandledInput(InputEvent inputEvent)
    {
        if (Input.MouseMode != Input.MouseModeEnum.Captured) return;
        if (inputEvent is not InputEventMouseMotion mouseMotionEvent) return;

        _mouseOffset = mouseMotionEvent.Relative * _cameraSensivity;

        // rotate camera based on mouse motion
        // rotate around Y with Horizontal motion (MouseMotion.X)
        // rotate around X with Vertical motion (MouseMotion.Y)
        _cameraSpring.RotateY(-_mouseOffset.X);
        _cameraSpring.RotateObjectLocal(Vector3.Right, -_mouseOffset.Y);

        _cameraRotation = _cameraSpring.Rotation;
        _cameraRotation.X = Mathf.Clamp(_cameraRotation.X, -Mathf.Pi / 2, Mathf.Pi / 2);
        _cameraSpring.Rotation = _cameraRotation;
    }
}
