using UnityEngine;
using System.Collections;

public class ShaderSwapper : MonoBehaviour
{
    public Shader NewShader;

    private Shader oldShader;
    private Renderer[] renderers;

    void Start()
    {
        renderers = gameObject.GetComponentsInChildren<Renderer>();

        oldShader = renderers[0].material.shader;
    }

    public void SwapNew()
    {
        foreach (var r in renderers)
        {
            r.material.shader = NewShader;
        }
    }

    public void SwapOriginal()
    {
        foreach (var r in renderers)
        {
            r.material.shader = oldShader;
        }
    }

    public void UpdateShaders(Shader originalShader, Shader secondaryShader)
    {
        oldShader = originalShader;
        NewShader = secondaryShader;
    }
}
