using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koopaPath : MonoBehaviour {

		public Transform[] target;
		public float speed;
		private int current;

	void Start () {
				current = 0;
	}
	
	void Update () {
				
				GameObject.FindObjectOfType<SuperCharacterController> ().debugMove = new Vector3(1+speed,1+speed,1+speed);
	}

		void Race(){
				if (transform.position != target [current].position) {
						print ("try to chase");
						transform.Translate(0,0,speed*Time.deltaTime);
						transform.LookAt (target[current]);				}
		else 
		{
						current = (current + 1) % target.Length;
		}
    }
}
