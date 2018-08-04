using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUpMushroom : MonoBehaviour {
    
    public bool UniformHeight = true;
    public float PlacementHeight = 0.6f;
    public GameObject DeathEffect;
    public Transform Art;

    public bool OnTouched = false;

    void Awake()
    {
        RaycastHit hit;

        if (UniformHeight && Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity))
        {
            transform.position = hit.point + Vector3.up * PlacementHeight;
        }
    }

    void Update()
    {
        if (OnTouched)
        {
            Debug.Log(gameObject.name);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            OnTouched = true;
            Death();
        }
    }

    void Death()
    {
        GameObject.FindObjectOfType<GameMaster>().AddLives();

        if (DeathEffect)
        {
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
        }

        Debug.Log(gameObject.name);
        Debug.Log("is Destroyed!");
        Destroy(this.gameObject);
    }
}
