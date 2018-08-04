using UnityEngine;
using System.Collections;

public class Elevator : SimpleStateMachine {

    public bool Bottom;

    public float Rise = 6.0f;
    public float Horizontal = 3.0f;
    public float BoardingHeight = 1.0f;

    public float RiseSpeed = 1.0f;
    public float SwapSpeed = 2.0f;

    private enum ElevatorStates { Rotate, Descend, Ascend, Swap }

    private Vector3 ascendRoot;
    private Vector3 ascendTarget;
    private Vector3 flipTarget;
    private Vector3 descendRoot;

    private Vector3 flipOrigin;

    private Vector3 forward;

	public bool whompFortressFirst;


	void Start () {        

        forward = transform.forward;

        ascendRoot = transform.position;
        ascendTarget = ascendRoot + Vector3.up * Rise;
        flipTarget = ascendTarget + forward * Horizontal;
        descendRoot = flipTarget - Vector3.up * Rise;

        flipOrigin = ascendTarget + forward * Horizontal * 0.5f;

        if (Bottom)
        {
            currentState = ElevatorStates.Ascend;
        }
        else
        {
            currentState = ElevatorStates.Descend;
            transform.position = flipTarget;
        }
	}	

	void Update(){
		if (whompFortressFirst == true) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 45, 0));
		}
	}

	void Ascend_FixedUpdate () {

        if (transform.position == ascendTarget)
        {
            currentState = ElevatorStates.Rotate;
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, ascendTarget, RiseSpeed * Time.deltaTime);
	}

    float rot;

    void Rotate_EnterState()
    {
        rot = 0;
    }

    void Rotate_FixedUpdate()
    {
        rot += SwapSpeed * Time.deltaTime;

        transform.RotateAround(flipOrigin, transform.right, SwapSpeed * Time.deltaTime);

        if (rot > 180)
        {
            transform.position = flipTarget;
            transform.rotation = Quaternion.identity;
            currentState = ElevatorStates.Descend;
            return;
        }
    }

    void Descend_FixedUpdate()
    {

        if (transform.position == descendRoot)
        {
            currentState = ElevatorStates.Swap;
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, descendRoot, RiseSpeed * Time.deltaTime);
    }

    void Swap_FixedUpdate()
    {
        float time = 180 / SwapSpeed;
        float distance = Vector3.Distance(descendRoot, ascendRoot);

        float velocity = distance / time;

        transform.position -= forward * velocity * Time.deltaTime;

        if (Vector3.Distance(descendRoot, transform.position) > Horizontal)
        {
            transform.position = ascendRoot;
            currentState = ElevatorStates.Ascend;
            return;
        }
    }
}
