using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springSwitcher : MonoBehaviour {

	public GameObject thisSpring;
	public GameObject anotherSpring;

	private int turn = 0;
	private int turnState;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switchCount ();
		changeSpring ();
	}

	public void switchCount(){
		turn += 1;
		if (turn <= 45) {
			//transform.Rotate (Vector3.up, 100 * Time.deltaTime);
			turnState = 1;
		} else if (turn > 45 && turn <= 135) {
			turnState = 0;
		} else if (turn > 135 && turn <= 180) {
			//transform.Rotate (Vector3.down, 100 * Time.deltaTime);
			turnState = -1;
		} else if (turn > 180 && turn <= 270) {
			turnState = 0;
		} else {
			turn = 0;
		}
	}

	public void changeSpring(){
		if (turnState == 1) {
			GameObject.FindObjectOfType<Springboard> ().lastSpringTime = 0;
			anotherSpring.SetActive (true);
			thisSpring.SetActive (false);
		} else if (turnState == -1) {
			GameObject.FindObjectOfType<Springboard> ().lastSpringTime = 0;
			anotherSpring.SetActive (false);
			thisSpring.SetActive (true);
		}
	}
}
