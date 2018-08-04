using UnityEngine;
using System.Collections;

public class KeybindingInputHandler : MonoBehaviour {

    public InputManager input;

    public void ButtonPushed(ButtonKeyBinding button)
    {
        input.ButtonPushed(button);
    }

    public void UpdateMoveDeadZone(float value)
    {
        if (input != null)
            input.UpdateMoveDeadZone(value);
    }

    public void UpdateCameraDeadZone(float value)
    {
        if (input != null)
            input.UpdateCameraDeadZone(value);
    }

    public void SetPreset(int preset)
    {
        input.SetPreset(preset);
    }
}
