using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

    public Transform LeftDoor;
    public Transform RightDoor;

    public float OpenSpeed = 55.0f;
    public float OpenAngle = 95.0f;

    private bool opened = false;
    private float rotated;

    void Start()
    {
    }

    void FixedUpdate()
    {
        if (opened)
        {
            if (rotated < OpenAngle)
            {
                rotated += OpenSpeed * Time.fixedDeltaTime;

                LeftDoor.rotation *= Quaternion.AngleAxis(OpenSpeed * Time.fixedDeltaTime, Vector3.forward);
                RightDoor.rotation *= Quaternion.AngleAxis(-OpenSpeed * Time.fixedDeltaTime, Vector3.forward);
            }
        }
    }

    void Update()
    {
    }

    public void Open()
    {
        if (opened)
            return;

        GetComponent<AudioSource>().Play();

        opened = true;
    }
}
