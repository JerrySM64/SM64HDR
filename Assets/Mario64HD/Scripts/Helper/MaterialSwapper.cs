using UnityEngine;
using System.Collections;

public class MaterialSwapper : MonoBehaviour {

    [SerializeField]
    Material newMaterial;

    private Renderer[] renderers;

	// Use this for initialization
	void Start () {
        renderers = gameObject.GetComponentsInChildren<Renderer>();
	}

    public void SwapNew()
    {
        foreach (var r in renderers)
        {
            r.material = newMaterial;
        }
    } 
}
