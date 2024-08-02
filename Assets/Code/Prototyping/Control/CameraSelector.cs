using Godot;
using dbasetemplate.Assets.Code.Common.Utils;
using Code.Prototyping.InputTranslation;
using dbasetemplate.Assets.Code.Prototyping.Control;
using System.Diagnostics;

public partial class CameraSelector : Node
{
	[Export]
	private Node3D _camera;
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
        _camera.Set();
		_cubeController.RotationLeader = _camera;
    }

    public override void _Process(double delta)
    {
		if (Input.IsActionJustPressed(InputMapping.Focus))
		{

		}



    }


}
