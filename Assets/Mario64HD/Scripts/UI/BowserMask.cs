using UnityEngine;
using System.Collections;

public class BowserMask : MonoBehaviour {

    private Vector3 initialScale;

	// Use this for initialization
	void Awake () {
        initialScale = transform.localScale;
	}

    public void PlayMask(float time)
    {
        gameObject.SetActive(true);

        StartCoroutine(ScaleDown(time));
    }

    IEnumerator ScaleDown(float time)
    {
        float i = 0;

        while (i < 1)
        {
            transform.localScale = Vector3.Lerp(initialScale, new Vector3(1, 1, 1), i);

            i += Time.deltaTime / time;

            yield return 0;
        }
    }
}
