using UnityEngine;
using System.Collections;

public class MaterialColorChanger : MonoBehaviour {

    public Renderer Render;
    public Color NewColor;

    private Color initialColor;

	// Use this for initialization
	void Start () {
        initialColor = Render.material.color;
	}

    public void FlickerColor(float flickerSpeed)
    {

        StopAllCoroutines();
        StartCoroutine(Flicker(flickerSpeed, NewColor));
    }

	public void FlickerColor(float flickerSpeed, Color newColor) {

        StopAllCoroutines();
        StartCoroutine(Flicker(flickerSpeed, newColor));
	}

    IEnumerator Flicker(float flickerSpeed, Color newColor)
    {
        while (true)
        {
            float i = 0;

            while (i < 1)
            {
                Render.material.color = Color.Lerp(initialColor, newColor, i);

                i += 1 / flickerSpeed * Time.deltaTime;

                yield return 0;
            }

            i = 0;

            while (i < 1)
            {
                Render.material.color = Color.Lerp(newColor, initialColor, i);

                i += 1 / flickerSpeed * Time.deltaTime;

                yield return 0;
            }
        }
    }
}
