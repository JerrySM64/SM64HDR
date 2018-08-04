using UnityEngine;
using System;
using System.Collections;

public class CoinToss : MonoBehaviour {

    public enum CoinTossDirection { Up, Down }

    public CoinTossDirection Direction;

    public Transform Art;
    public GameObject DeathParticle;

    public float InitialVelocity = 4.0f;
    public float DeccelerationTime = 0.5f;
    public float SpinSpeed = 90.0f;

    private float currentVelocity;

	// Use this for initialization
	void Start () {
        currentVelocity = InitialVelocity;

        if (Direction == CoinTossDirection.Down)
        {
            Invoke("Death", DeccelerationTime);

            currentVelocity = -InitialVelocity;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Direction == CoinTossDirection.Up)
        {
            currentVelocity = Mathf.MoveTowards(currentVelocity, 0, InitialVelocity / DeccelerationTime * Time.deltaTime);

            if (currentVelocity == 0)
            {
                Death();
            }
        }

        transform.position += Vector3.up * currentVelocity * Time.deltaTime;

        Art.rotation *= Quaternion.AngleAxis(SpinSpeed * Time.deltaTime, transform.up);
	}

    void Death()
    {
        Instantiate(DeathParticle, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
