using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    public Transform Target;

    private bool waitUntilLeave;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (col.gameObject.GetComponent<MarioMachine>().Velocity() == Vector3.zero)
            {
                waitUntilLeave = true;
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            waitUntilLeave = false;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (!waitUntilLeave && col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<MarioMachine>().Teleport(Target.position);
        }
    }
}
