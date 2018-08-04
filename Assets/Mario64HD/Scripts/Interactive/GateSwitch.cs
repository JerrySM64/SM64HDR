using UnityEngine;
using System.Collections;

public class GateSwitch : TriggerableObject {

    public Gate triggeredGate;

    public float TargetScale = 0.04f;
    public float ScaleSpeed = 6.0f;
    public float ActivateRadius = 1.2f;

    bool pushed = true;

    void FixedUpdate()
    {
        if (!pushed)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.MoveTowards(transform.localScale.z, TargetScale, ScaleSpeed * Time.fixedDeltaTime));
        }
    }

    public override bool StandingOn(Vector3 position)
    {
        if (!pushed)
            return false;

        if (Vector3.Distance(transform.position, Math3d.ProjectPointOnPlane(Vector3.up, transform.position, position)) > ActivateRadius)
            return false;

        triggeredGate.Open();

        GetComponent<AudioSource>().Play();

        pushed = false;

        return true;
    }
}
