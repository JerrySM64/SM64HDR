using UnityEngine;
using System.Collections;

public class ProximityCameraShaker : MonoBehaviour {

    [SerializeField]
    float minShakeDistance = 2.0f;

    [SerializeField]
    float maxShakeDistance = 10.0f;

    [SerializeField]
    float maxMagnitude = 0.4f;

    private MarioVerySmartCamera smartCamera;

	// Use this for initialization
	void Start () {
        smartCamera = Camera.main.GetComponent<MarioVerySmartCamera>();
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(smartCamera.target.position, transform.position);

        if (distance < maxShakeDistance)
        {
            float magnitude = Mathf.Lerp(maxMagnitude, 0, Mathf.InverseLerp(minShakeDistance, maxShakeDistance, distance));

            smartCamera.ConstantShake(magnitude);
        }
	}
}
