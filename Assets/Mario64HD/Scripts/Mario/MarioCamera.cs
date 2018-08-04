using UnityEngine;
using System.Collections;

public class MarioCamera : MonoBehaviour {

    [SerializeField]
    Transform target;

    [SerializeField]
    float scrollSpeed = 20.0f;

    [SerializeField]
    float xSensitivity = 20.0f;

    [SerializeField]
    float ySensitivity = 20.0f;

    [SerializeField]
    float maxDistance = 10.0f;

    [SerializeField]
    float minDistance = 1.0f;

    [SerializeField]
    float height = 1.0f;

    private float rotationX = 0f;
    private float rotationY = 0f;
    private float currentDistance;

	// Use this for initialization
	void Start () {
        currentDistance = (maxDistance + minDistance) / 2;
	}
	
	// Update is called once per frame
	void LateUpdate () {

			currentDistance -= Input.GetAxis ("Mouse ScrollWheel") * scrollSpeed;

			currentDistance = Mathf.Clamp (currentDistance, minDistance, maxDistance);

			rotationX += Input.GetAxis ("Mouse X") * xSensitivity;
			rotationY += Input.GetAxis ("Mouse Y") * ySensitivity;

			Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
			Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);

			transform.rotation = xQuaternion * yQuaternion;

			transform.position = target.position - (transform.forward * currentDistance) + (target.up * height);
	}

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
