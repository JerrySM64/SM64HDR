using UnityEngine;
using System.Collections;

public class WoodenPost : TriggerableObject {

    public GameObject Effect;
    public GameObject ObjectDroppedOnLastPound;

    public int MaxPounds = 3;
    public float DropHeight = 1.5f;

    private int currentPounds = 0;

    private float lastPounded;

    public override bool GroundPound()
    {
        if (SuperMath.Timer(lastPounded, 0.4f) && currentPounds < MaxPounds)
        {
            Drop();

            lastPounded = Time.time;

            return true;
        }

        return false;
    }

    void Drop()
    {
        Instantiate(Effect, transform.position + transform.forward * ((DropHeight / MaxPounds) * currentPounds + 0.2f), Quaternion.identity);

        transform.position -= transform.forward * DropHeight / MaxPounds;

        currentPounds++;

        if (currentPounds == MaxPounds && ObjectDroppedOnLastPound)
        {
            Instantiate(ObjectDroppedOnLastPound, transform.position + transform.forward * ((DropHeight / MaxPounds) * currentPounds), Quaternion.identity);
        }
    }
}
