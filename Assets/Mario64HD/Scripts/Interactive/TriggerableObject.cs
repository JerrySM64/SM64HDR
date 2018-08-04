using UnityEngine;
using System.Collections;

public abstract class TriggerableObject : MonoBehaviour {

    public virtual bool GroundPound()
    {
        return false;
    }

    public virtual bool BottomHit()
    {
        return false;
    }

    public virtual bool Strike()
    {
        return false;
    }

    public virtual bool StandingOn()
    {
        return false;
    }

    public virtual bool StandingOn(Vector3 position)
    {
        return false;
    }

    public virtual bool Explosion()
    {
        return false;
    }
}
