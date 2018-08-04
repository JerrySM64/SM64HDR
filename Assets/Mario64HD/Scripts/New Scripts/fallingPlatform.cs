using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour {

	bool falling = false;
	float fallSpeed;
	int fallCount;
    Vector3 startPos;

	void Start () {
		falling = false;
		fallSpeed = 0;
		fallCount = 0;
        startPos = gameObject.transform.position;
	}

	void Update () {
		if (falling == true) {
			fall ();
		}
        
        if (gameObject.transform.position.y < 0f)
        {
            falling = false;
            gameObject.transform.position = startPos;
        }
	}

	public void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			falling = true;
		}
	}

	void fall(){
		fallSpeed = 0.1f;
		fallCount++;
		if (fallCount >= 15) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - fallSpeed, transform.position.z);
		}
	}
}
