using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Projector))]
public class DynamicShadow : MonoBehaviour {

    public LayerMask Ground;

    public float MinSize = 0.4f;
    public float MinSizeDistance = 3.0f;
    public float MaxSizeDistance = 20.0f;

    private Projector projector;

    private float initialSize;

    [HideInInspector]
    public float Scale = 1.0f;

    void Start()
    {
        projector = GetComponent<Projector>();

        initialSize = projector.orthographicSize;
    }

	void LateUpdate () {

        RaycastHit hit;

        Physics.SphereCast(transform.position + Vector3.up * 0.02f, initialSize, -Vector3.up, out hit, Mathf.Infinity, Ground);

        var lerpValue = Mathf.InverseLerp(MinSizeDistance, MaxSizeDistance, hit.distance);
        var size = Mathf.Lerp(initialSize * MinSize, initialSize, 1 - lerpValue);

        projector.orthographicSize = size * Scale;
	}
}
