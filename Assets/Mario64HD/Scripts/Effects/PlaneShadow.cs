using UnityEngine;
using System.Collections;

public class PlaneShadow : MonoBehaviour {

    public LayerMask Ground;
    public float Tolerance = 0.01f;

    public bool Static = true;

    private Transform target;

    private Vector3 initialOffset;
    private Quaternion initialRotation;

	// Use this for initialization
	void Start () {

        initialRotation = transform.rotation;

        if (!Static)
        {
            target = transform.parent;

            transform.parent = null;

            initialOffset = transform.position - target.position;
        }

        ClampToGround();
	}
	
	// Update is called once per frame
	void Update () {
        if (!Static)
        {
            if (target == null)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = target.position + initialOffset;

                ClampToGround();
            }
        }
	}

    void ClampToGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity, Ground))
        {
            transform.position = hit.point += Vector3.up * Tolerance;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal) * initialRotation;
        }
    }
}
