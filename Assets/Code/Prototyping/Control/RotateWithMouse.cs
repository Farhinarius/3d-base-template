using Code.Prototyping.InputTranslation;
using dbasetemplate.Assets.Code.Prototyping.Control;
using Godot;

public partial class RotateWithMouse : Node3D
{
    [Export]
    private CubeController _cubeController;

    [Export]
    private float _rotationSensivity = 0.002f;       // default is 0.005f
    private Vector3 _cameraRotation;
    public Vector2 _mouseOffset = Vector2.Zero;

    public override void _Ready()
    {
        Input.MouseMode = Input.MouseModeEnum.Captured;
    }

    public override void _UnhandledInput(InputEvent inputEvent)
    {
        // determine mouse mode 
        if (inputEvent.IsActionPressed(InputMapping.Cancel))
        {
            if (Input.MouseMode == Input.MouseModeEnum.Captured)
            {
                Input.MouseMode = Input.MouseModeEnum.Visible;
            }
            else
            {
                Input.MouseMode = Input.MouseModeEnum.Captured;
            }
        }

        if (Input.MouseMode == Input.MouseModeEnum.Visible) return;
        if (inputEvent is not InputEventMouseMotion mouseMotionEvent) return;

        _mouseOffset = mouseMotionEvent.Relative * _rotationSensivity;

        // rotate camera based on mouse motion
        // rotate around Y with Horizontal motion (MouseMotion.X)
        // rotate around X with Vertical motion (MouseMotion.Y) based on Y Rotation
        _cubeController.RotateY(-_mouseOffset.X);
        RotateObjectLocal(Vector3.Right, -_mouseOffset.Y);

        _cameraRotation = Rotation;
        _cameraRotation.X = Mathf.Clamp(_cameraRotation.X, -Mathf.Pi / 2, Mathf.Pi / 2);
        Rotation = _cameraRotation;
    }

}
