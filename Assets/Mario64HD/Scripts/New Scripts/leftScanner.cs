using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftScanner : MonoBehaviour {

	public bool face = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			face = true;
		}
	}

	public void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			face = false;
		}
	}
}
