using UnityEngine;
using System.Collections;

public class BobOmbBuddy : MonoBehaviour {

    public Transform AnimatedMesh;
    public AdditiveTransform WindTransform;

    public float SightDistance = 10.0f;
    public float SightAngle = 10.0f;
    public float TurnSpeed = 270.0f;

    private float windRotation;
    private Transform target;

	// Use this for initialization
	void Start () {
        AnimatedMesh.GetComponent<Animation>().Play("idle");

        target = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = Math3d.ProjectVectorOnPlane(transform.up, (target.position - transform.position).normalized);

        if (Vector3.Distance(target.position, transform.position) < SightDistance && Vector3.Angle(direction, transform.forward) > SightAngle)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), TurnSpeed * Time.deltaTime);

            if (!AnimatedMesh.GetComponent<Animation>().IsPlaying("turn"))
            {
                AnimatedMesh.GetComponent<Animation>().Play("turn");

                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            if (!AnimatedMesh.GetComponent<Animation>().isPlaying)
            {
                AnimatedMesh.GetComponent<Animation>().Play("idle");
            }
        }

        windRotation = SuperMath.ClampAngle(windRotation + 360.0f * Time.deltaTime);

        WindTransform.Rotation = Quaternion.Euler(new Vector3(0, 0, windRotation));
	}
}
