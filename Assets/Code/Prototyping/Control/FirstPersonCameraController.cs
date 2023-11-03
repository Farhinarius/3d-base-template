using Godot;

public partial class FirstPersonCameraController : Node
{
    [Export]
    private Node3D _camera;
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
        _camera.RotateY(-_mouseOffset.X);
        _camera.RotateObjectLocal(Vector3.Right, -_mouseOffset.Y);

        _cameraRotation = _camera.Rotation;
        _cameraRotation.X = Mathf.Clamp(_cameraRotation.X, -Mathf.Pi / 2, Mathf.Pi / 2);
        _camera.Rotation = _cameraRotation;
    }

}
