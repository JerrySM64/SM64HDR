using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnalogDeadZoneVisualizer : MonoBehaviour {

    public enum VisualizerType { Movement, Camera }

    public VisualizerType visualizerType = VisualizerType.Movement;

    public InputManager Inputs;
    public RectTransform Dot;
    public float MaxDotDistance = 50.0f;
    public Slider slider;

    private RectTransform rect;

	// Use this for initialization
	void Start () {
        rect = GetComponent<RectTransform>();

        if (!Inputs)
            Inputs = GameObject.FindObjectOfType<InputManager>();

        if (visualizerType == VisualizerType.Movement)
        {
            slider.value = Inputs.MoveDeadZone;
        }
        else if (visualizerType == VisualizerType.Camera)
        {
            slider.value = Inputs.CameraDeadZone;
        }
	}
	
	// Update is called once per frame
	void Update () {
        rect.localScale = new Vector3(slider.value, slider.value, 1);

        Vector2 input = Vector2.zero;

        if (visualizerType == VisualizerType.Movement)
        {
            input = Inputs.MovementInputDeadZoned();
        }
        else if (visualizerType == VisualizerType.Camera)
        {
            input = Inputs.CameraInputDeadZoned();
        }

        Vector2 moveInput = Vector2.ClampMagnitude(input, 1.0f);

        Dot.localPosition = new Vector3(moveInput.x * MaxDotDistance, moveInput.y * MaxDotDistance, 0);
	}
}
