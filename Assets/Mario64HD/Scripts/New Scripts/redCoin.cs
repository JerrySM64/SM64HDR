using UnityEngine;
using System.Collections;

public class redCoin : MonoBehaviour {

		public int Value = 1;
    public bool UniformHeight = true;
    public float PlacementHeight = 0.6f;
    public float SpinSpeed = 360.0f;
    public GameObject DeathEffect;
    public AudioClip CoinSound;
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
				if (OnTouched) {
						Debug.Log (gameObject.name);
				}
				try {
					Art.rotation *= Quaternion.AngleAxis (SpinSpeed * Time.deltaTime, transform.up);
				}catch{
						Debug.Log ("Art trans destroyed");
				}
//				Debug.Log ("Art.rotated");
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
		GameObject.FindObjectOfType<GameMaster>().addRed(Value);
		GameObject.FindObjectOfType<GameMaster> ().currentRed++;
        GameObject.FindObjectOfType<MarioStatus>().AddHealth(Value);

		if (DeathEffect) {
				Instantiate (DeathEffect, transform.position, Quaternion.identity);
		}

		Debug.Log (gameObject.name);
		Debug.Log ("is Destroyed!");
        Destroy(this.gameObject);
    }
}
