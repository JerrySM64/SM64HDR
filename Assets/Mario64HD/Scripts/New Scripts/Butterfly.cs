using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour {

    public Vector3 target;
    public float timer;
    public int sec;
    public Transform form;

    void Start()
    {
        target = ResetTarget();
        sec = ResetSec();
    }

    void Update () {
        timer += Time.deltaTime;
        if (timer > sec)
        {
            target = ResetTarget();
            sec = ResetSec();
        }

        if (transform.position.y + target.y <= 22)
        {
            target = ResetTarget();
            sec = ResetSec();
        }
        transform.Translate(target * 1 * Time.deltaTime);
    }

    public Vector3 ResetTarget()
    {
        Vector3 vec = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f));
        return vec;
    }

    public int ResetSec()
    {
        timer = 0;
        return Random.Range(1, 3);
    }
}