using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour {

	public GameObject obj1;
	public GameObject obj2;
	
	// Update is called once per frame
	void Update () {
		if (obj1 == null)
			obj2.SetActive (true);
	}
}
