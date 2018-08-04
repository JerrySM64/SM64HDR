using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFlips : MonoBehaviour {

    public AudioSource SoundSource;
    public AudioClip GayBabyJail;

    void Start () {
		
	}

    public void GBJ()
    {
        StartCoroutine(COOL());
    }

    IEnumerator COOL()
    {
        yield return new WaitForSeconds(5.0f);

        SoundSource.PlayOneShot(GayBabyJail);
    }

}
