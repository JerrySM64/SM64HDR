using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
		public Vector3 v;
	// Use this for initialization
	void Awake () {
				transform.position = v;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
