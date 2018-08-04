using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundCollider : MonoBehaviour {

	public bool collided = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("whompExterior")) {
			collided = true;
			print ("edged");
		}
	}

	public void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("whompExterior")) {
			collided = false;
		}
	}
}
