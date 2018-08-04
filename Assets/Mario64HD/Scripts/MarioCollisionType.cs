using UnityEngine;
using System.Collections;

public class MarioCollisionType : SuperCollisionType {

    public float SlideAngle = 30.0f;
    public float SlideContinueAngle = 30.0f;

    public bool Destructable;

    public void Trigger()
    {
        gameObject.SendMessage("OnCollisionTrigger", SendMessageOptions.DontRequireReceiver);
    }

    void Start()
    {
        SlideAngle = Mathf.Clamp(SlideAngle, SlideContinueAngle, Mathf.Infinity);
    }
}
