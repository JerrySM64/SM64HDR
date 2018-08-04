using UnityEngine;
using System.Collections;

/// <summary>
/// Modify the Rotation value to add an additive rotation to a skinned animated bone object. Rotating skinned
/// animated bone objects in Update causes them to be reset before the animation is evaluated
/// </summary>
public class AdditiveTransform : MonoBehaviour
{
    [HideInInspector]
    public Quaternion Rotation;

    void Start()
    {
        Rotation = Quaternion.identity;
    }

    void LateUpdate()
    {
        transform.localRotation *= Rotation;
    }
}