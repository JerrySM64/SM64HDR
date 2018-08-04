using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whompWeak : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			if (GameObject.FindObjectOfType<MarioMachine> ().pounding == true){
				GameObject.FindObjectOfType<KingWhomp> ().hurtSelf ();
			}
		}
	}
}
