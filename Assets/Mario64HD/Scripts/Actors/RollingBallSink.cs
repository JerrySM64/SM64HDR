using UnityEngine;
using System.Collections;

public class RollingBallSink : MonoBehaviour {

    public LayerMask Ground;
    public Transform Ball;

    public float RotationSpeed = 60.0f;
    public float Acceleration = 8.0f;
    public float Decceleration = 8.5f;

    public bool Forwards = true;

    private float currentSpeed;
    private float radius;

    void Start()
    {
        currentSpeed = Acceleration;

        radius = GetComponent<SphereCollider>().radius * transform.localScale.x;
    }

	void Update () {

        Vector3 right = Forwards ? transform.right : -transform.right;

        RaycastHit hit;

        Physics.SphereCast(transform.position + 1.0f * Vector3.up, radius, -Vector3.up, out hit, Mathf.Infinity, Ground);

        transform.position -= (hit.distance - 1.0f) * Vector3.up;

        Vector3 direction = Vector3.Cross(right, hit.normal);

        transform.position += currentSpeed * direction * Time.deltaTime;

        float angle = Vector3.Angle(direction, Vector3.up);

        if (Vector3.Angle(hit.normal, Vector3.up) < 5)
        {
        } 
        else if (angle < 90)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, Decceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, Acceleration, Acceleration * Time.deltaTime);
        }

        if (currentSpeed == 0)
        {
            Forwards = !Forwards;
        }

        int rotationDirection = Forwards ? 1 : -1;

        Ball.Rotate(new Vector3(currentSpeed / Acceleration * RotationSpeed * rotationDirection * Time.deltaTime, 0, 0), Space.Self);

	}
}
