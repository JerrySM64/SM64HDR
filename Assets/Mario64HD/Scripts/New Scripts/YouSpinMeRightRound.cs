using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouSpinMeRightRound : MonoBehaviour {

	public Transform Art;
	public float SpinSpeed = 360.0f;
	
	void Update () {

		Art.Rotate (Vector3.forward, SpinSpeed * Time.deltaTime);

	}

}
