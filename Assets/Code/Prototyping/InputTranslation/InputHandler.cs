using Godot;

namespace Code.Prototyping.InputTranslation;

public partial class InputHandler : Node
{
    public Vector2 LeftCross { get; private set; } = Vector2.Zero;
    public bool ConfirmPressed { get; private set; } = false;
    public bool RetryPressed { get; private set; } = false;

    public override void _Ready()
    {
        Input.MouseMode = Input.MouseModeEnum.Captured;
    }

    public override void _UnhandledKeyInput(InputEvent inputEvent)
    {
        if (Input.IsActionJustPressed(InputMapping.Cancel))
        {
            if (Input.MouseMode == Input.MouseModeEnum.Captured)
            {
                Input.MouseMode = Input.MouseModeEnum.Visible;
                return;
            }

            Input.MouseMode = Input.MouseModeEnum.Captured;
        }
    }

    public override void _Process(double delta)
    {
        LeftCross = Input.GetVector(InputMapping.LeftCrossHorizontalNegative,
            InputMapping.LeftCrossHorizontalPositive,
            InputMapping.LeftCrossVerticalNegative,
            InputMapping.LeftCrossVerticalPositive);

        ConfirmPressed = Input.IsActionJustPressed(InputMapping.Confirm);
        RetryPressed = Input.IsActionJustPressed(InputMapping.Retry); 
    }
}
