using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhompFortressTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.FindObjectOfType<GameMaster> ().wf = true;
	}
}
