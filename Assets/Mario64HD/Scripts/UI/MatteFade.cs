using UnityEngine;
using System.Collections;

public class MatteFade : MonoBehaviour {

    private CanvasGroup canvasGroup;

    public void FadeIn(float time)
    {
        gameObject.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(FadeMatteIn(time));
    }

    public void FadeOut(float time)
    {
        gameObject.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(FadeMatteOut(time));
    }

    IEnumerator FadeMatteIn(float time)
    {
        canvasGroup = GetComponent<CanvasGroup>();

        float i = 0;

        while (i < 1.0f)
        {
            canvasGroup.alpha = Mathf.Lerp(1, 0, i);
            i += Time.deltaTime / time;

            yield return 0;
        }

        gameObject.SetActive(false);
    }

    IEnumerator FadeMatteOut(float time)
    {
        canvasGroup = GetComponent<CanvasGroup>();

        float i = 0;

        while (i < 1.0f)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, i);
            i += Time.deltaTime / time;

            yield return 0;
        }
    }
}
