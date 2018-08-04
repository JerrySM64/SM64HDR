using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhompKillBox : MonoBehaviour {
	private bool state = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool killState(){
		return state;
	}

	public void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			state = true;
		}
	}

	public void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			state = false;
		}
	}
}
