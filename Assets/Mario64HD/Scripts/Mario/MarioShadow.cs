using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Projector))]
public class MarioShadow : MonoBehaviour {

    public MarioMachine mario;
    public Transform CenterOfGravity;

    private Transform target;
    private SuperCharacterController controller;
    private Projector projector;

    void Start()
    {
        target = mario.transform;
        controller = mario.GetComponent<SuperCharacterController>();
        projector = GetComponent<Projector>();
    }

	void LateUpdate () {
        transform.rotation = target.rotation * Quaternion.AngleAxis(90, target.right);

        Transform t = target;

        if (mario.StateCompare(MarioMachine.MarioStates.Climb))
        {
            t = CenterOfGravity;
        }

        transform.position = t.position + (controller.up * controller.radius);

        projector.farClipPlane = controller.currentGround.Hit.distance + controller.radius * 6;

	}
}
