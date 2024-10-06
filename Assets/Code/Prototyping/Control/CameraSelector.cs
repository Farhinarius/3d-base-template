using Godot;
using Code.Prototyping.InputTranslation;
using dbasetemplate.Assets.Code.Prototyping.Control;

public partial class CameraSelector : Node
{
	[Export]
	private Node3D _camera;
    [Export]
	private Vector3 _firstPersonCamPosition;
    [Export]
    private Vector3 _firstPersonCamRotation;
	[Export]
	private Vector3 _thirdPersonCamPosition;
	[Export]
	private Vector3 _thirdPersonCamRotation;

	private enum CameraSelection
	{
		FirstPerson,
		ThirdPerson
	}

	[Export]
	private CameraSelection _cameraSelected;

    public override void _Ready()
    {
        if (_cameraSelected == CameraSelection.FirstPerson)
            PickFirstPerson();
        else
            PickThirdPerson();
    }

    public override void _Process(double delta)
    {
		if (Input.IsActionJustPressed(InputMapping.Focus))
		{
            if (_cameraSelected == CameraSelection.FirstPerson)
                PickThirdPerson();
            else
                PickFirstPerson();

            // test camera rotation after pivot rotation for first person
            // may be enable disable rotate behaviour on pivot - check later
        }

    }

    private void PickFirstPerson()
    {
        _cameraSelected = CameraSelection.FirstPerson;
        _camera.Position = _firstPersonCamPosition;
        _camera.Rotation = _firstPersonCamRotation;
    }

    private void PickThirdPerson()
    {
        _cameraSelected = CameraSelection.ThirdPerson;
        _camera.Position = _thirdPersonCamPosition;
        _camera.Rotation = _thirdPersonCamRotation;
    }


}
