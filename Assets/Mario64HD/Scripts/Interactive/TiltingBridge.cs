using UnityEngine;
using System.Collections;

public class TiltingBridge : TriggerableObject {

    public float TiltSpeed = 3.0f;
    public float TiltAcceleration = 1.0f;
    public float TiltDecceleration = 2.0f;
    public float MaxTilt = 45.0f;
    public float TiltSlowBarrier = 10.0f;
    public Transform Bridge;

    private Vector3 tiltPlane;

    private float currentSpeed;
    private float currentRotation;

    private float lastTiltTime;

    private const float tiltSlowTime = 0.1f;

    private Quaternion initialRotation;

	// Use this for initialization
	void Start () {
        initialRotation = Bridge.rotation;

        tiltPlane = Bridge.forward;
	}

    void FixedUpdate()
    {
        if (Mathf.Abs(currentRotation) > MaxTilt - TiltSlowBarrier && Mathf.Sign(currentSpeed) == Mathf.Sign(currentRotation))
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, TiltDecceleration * Time.fixedDeltaTime);
        }

        if (Mathf.Abs(currentRotation) > MaxTilt && Mathf.Sign(currentSpeed) == Mathf.Sign(currentRotation))
        {
            currentSpeed = 0;
            currentRotation = MaxTilt * Mathf.Sign(currentRotation);
            GetComponent<AudioSource>().Stop();
        }

        if (currentRotation != 0 && SuperMath.Timer(lastTiltTime, tiltSlowTime))
        {
            var lerpValue = Mathf.InverseLerp(0, TiltSlowBarrier * Mathf.Sign(currentRotation), currentRotation);
            var tiltSpeed = Mathf.Lerp(0, TiltSpeed, lerpValue);

            currentSpeed = Mathf.MoveTowards(currentSpeed, tiltSpeed * -Mathf.Sign(currentRotation), TiltDecceleration * Time.fixedDeltaTime);

            if (Mathf.Abs(currentRotation) < 0.1f)
            {
                currentRotation = 0;
            }
        }

        if (currentRotation == 0)
        {
            GetComponent<AudioSource>().Stop();
        }

        currentRotation += currentSpeed * Time.fixedDeltaTime;

        Bridge.rotation = Quaternion.AngleAxis(currentRotation, Bridge.right) * initialRotation;
    }

    public override bool StandingOn(Vector3 position)
    {
        lastTiltTime = Time.time;

        int direction = SuperMath.PointAbovePlane(tiltPlane, Bridge.position, position) ? 1 : -1;

        if (Mathf.Abs(currentRotation) < MaxTilt - TiltSlowBarrier || direction != Mathf.Sign(currentRotation))
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, TiltSpeed * direction, TiltAcceleration * Time.deltaTime);
        }

        return false;
    }
}
