using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHeartScript : MonoBehaviour {

    public Transform Art;
    public AudioClip HealthSound;
    public float SpinSpeed = 180.0f;
    bool onTouched = false;

    void Update()
    {
        if(!onTouched)
        {
            Art.Rotate(Vector3.up, SpinSpeed * Time.deltaTime);
        } else
        {
            Art.Rotate(Vector3.up, SpinSpeed * 2 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onTouched = true;
            StartCoroutine(healTime());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onTouched = false;
        }
    }

    IEnumerator healTime()
    {
        GameObject.FindObjectOfType<MarioStatus>().AddHealth(1);
        GameObject.FindObjectOfType<GameMaster>().SoundSource.PlayOneShot(HealthSound);
        yield return new WaitForSeconds(0.5f);
        GameObject.FindObjectOfType<MarioStatus>().AddHealth(1);
        GameObject.FindObjectOfType<GameMaster>().SoundSource.PlayOneShot(HealthSound);
        yield return new WaitForSeconds(0.5f);
        GameObject.FindObjectOfType<MarioStatus>().AddHealth(1);
        GameObject.FindObjectOfType<GameMaster>().SoundSource.PlayOneShot(HealthSound);
    }
}
