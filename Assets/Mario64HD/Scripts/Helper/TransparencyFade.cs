using UnityEngine;
using System.Collections;

public class TransparencyFade : MonoBehaviour {

    private Renderer[] renderers;

	void Start () {
        renderers = gameObject.GetComponentsInChildren<Renderer>();
	}


    public void FadeIn(float time)
    {
        StopAllCoroutines();
        StartCoroutine(FadeInCoroutine(time));
    }

    public void FadeOut(float time)
    {
        StopAllCoroutines();
        StartCoroutine(FadeOutCoroutine(time));
    }

	IEnumerator FadeInCoroutine(float time)
    {
        float i = 0;

        float alpha = 0;

        while (i < 1)
        {
            foreach (var r in renderers)
            {
                alpha = Mathf.Lerp(0, 1.0f, i);

                r.material.color = new Color(r.material.color.r, r.material.color.g, r.material.color.b, alpha);

                i += Time.deltaTime / time;

                yield return 0;
            }
        }

        foreach (var r in renderers)
        {
            r.material.color = new Color(r.material.color.r, r.material.color.g, r.material.color.b, 1);
        }
	}

    IEnumerator FadeOutCoroutine(float time)
    {
        float i = 0;

        float alpha = 1;

        while (i < 1)
        {
            foreach (var r in renderers)
            {
                alpha = Mathf.Lerp(0, 1.0f, 1 - i);

                r.material.color = new Color(r.material.color.r, r.material.color.g, r.material.color.b, alpha);

                i += Time.deltaTime / time;

                yield return 0;
            }
        }

        foreach (var r in renderers)
        {
            r.material.color = new Color(r.material.color.r, r.material.color.g, r.material.color.b, 0);
        }
    }
}
