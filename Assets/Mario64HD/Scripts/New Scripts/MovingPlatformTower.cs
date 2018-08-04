using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformTower : MonoBehaviour {

    public GameObject toObject;
    public Vector3 origPoint;
    public float perSec = 0.15f;
    float distance;
    public bool reached = false;
    public bool marioOn;

    public void Start()
    {
        origPoint = transform.position;
        marioOn = false;
    }

    public void Update()
    {
        if (!reached)
        {
            distance = Vector3.Distance(transform.position, toObject.transform.position);
            if (distance > .1)
            {
                if (marioOn) {
                    move(transform.position, toObject.transform.position);
                }
            }
            else
            {
                reached = true;
            }
        }

        if(reached && !marioOn)
        {
            distance = Vector3.Distance(transform.position, origPoint);
            if (distance > .1)
            {
                move(transform.position, origPoint);
            }
            else
            {
                reached = false;
            }
        }
    }

    void move(Vector3 pos, Vector3 towards)
    {
        transform.position = Vector3.MoveTowards(pos, towards, perSec);
    }
}
