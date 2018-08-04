using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningScript : MonoBehaviour {
	int spinTime = 0;
    
    void Update()
    {
		spin ();
    }
    public void spin()
    {
		spinTime++;
		if (spinTime <= 350) {
			transform.Rotate (Vector3.back, -15 * Time.deltaTime);
		} else if (spinTime >= 400 && spinTime <= 750) {
			transform.Rotate (Vector3.back, -15 * Time.deltaTime);
		} else if (spinTime > 800 && spinTime <= 1150) {
			transform.Rotate (Vector3.back, 15 * Time.deltaTime);
		} else if (spinTime > 1200 && spinTime <= 1550) {
			transform.Rotate (Vector3.back, 15 * Time.deltaTime);
		} else if (spinTime > 1600){
			spinTime = 0;
		}
			
    }
}
