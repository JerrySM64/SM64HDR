using UnityEngine;
using System.Collections;

public class WaterBombProjectile : MonoBehaviour {

    public float Life = 2.0f;
    public float Speed = 50.0f;

    void Start()
    {
        Invoke("Death", Life);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * Speed * Time.deltaTime;
	}

    void Death()
    {
        Destroy(gameObject);
    }
}
