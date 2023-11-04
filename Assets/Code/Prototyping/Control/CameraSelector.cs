using Godot;
using dbasetemplate.Assets.Code.Common.Utils;
using Code.Prototyping.InputTranslation;
using dbasetemplate.Assets.Code.Prototyping.Control;
using System.Diagnostics;

public partial class CameraSelector : Node
{
	[Export]
	private Node3D _firstPersonCamera;
	[Export]
	private Node3D _thirdPersonCameraSpring;
	[Export]
	private Node3D _thirdPersonCamera;
	[Export]
	private CubeController _cubeController;

	private enum CameraSelection
	{
		FirstPerson,
		ThirdPerson
	}

	private CameraSelection _cameraSelected;

    public override void _Ready()
    {
		_cameraSelected = CameraSelection.FirstPerson;
        _thirdPersonCamera.Set(false);
        _thirdPersonCameraSpring.Set(false);
        _firstPersonCamera.Set();
		_cubeController.RotationLeader = _firstPersonCamera;
    }

    public override void _Process(double delta)
    {
		if (!Input.IsActionJustPressed(InputMapping.Focus)) return;

		if (_cameraSelected == CameraSelection.FirstPerson)
		{
			Debug.WriteLine("Switch from FPC to TPC");
			// enable third person camera
			_cameraSelected = CameraSelection.ThirdPerson;
			_firstPersonCamera.Set(false);
			_thirdPersonCameraSpring.Set();
			_thirdPersonCamera.Set();
			_cubeController.RotationLeader = _thirdPersonCameraSpring;

        }
		else
		{
            Debug.WriteLine("Switch from TPC to FPC");
            // enable first person camera
            _cameraSelected = CameraSelection.FirstPerson;
			_thirdPersonCamera.Set(false);
			_thirdPersonCameraSpring.Set(false);
			_firstPersonCamera.Set();
			_cubeController.RotationLeader = _firstPersonCamera;
		}

    }


}
