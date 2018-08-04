using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingWhomp : MonoBehaviour {

	public GameObject mainBox;
	public GameObject killbox;
	public GameObject checkbox;
	public GameObject weakbox;
	public GameObject reward;
	public GameObject [] deathEffects;
	public GameObject [] toDestroy;

	public Transform Target;
	public Transform Center;

	public AudioClip Step;
	public AudioClip Slam;
	public AudioClip Star;
	public AudioClip Hurt;

	public int health = 3;
	int walkXCount = 0;
	int walkYCount = 0;
	int slamCount = 0;
	float chaseSpeed = 0;
	float startX;
	float startY;
	float startZ;

	bool playable = false;
	bool played = false;
	bool slamplayed = false;
	bool slamming = false;
	bool onEdge = false;
	bool backing = false;
	bool hurtable = true;
	bool onPlayer = false;

	void Start () {
		killbox.SetActive (false);
		checkbox.SetActive (false);
		weakbox.SetActive (false);
		reward.SetActive (false);
		startX = transform.eulerAngles.x;
		startY = transform.eulerAngles.y;
		startZ = transform.eulerAngles.z;
	}

	void Update () {
		whompAI ();
		onPlayer = GameObject.FindObjectOfType<WhompKillBox> ().killState();
		if (onPlayer)
			mainBox.SetActive (false);
		else
			mainBox.SetActive (true);
	}

	public void whompAI(){
		checkPlay ();
		checkBound ();
		if (!slamming)
			walkAnim ();
		if (Vector3.Distance (transform.position, Target.position) >= 4.5f && !slamming && !onEdge && !backing) {
			walkAnim ();
			chase ();
		} else if (!onEdge && !backing) {
			if (GameObject.FindObjectOfType<whompScanner> ().face == true || slamming)
				faceSlam ();
			else
				rotateTowardsTarget ();
		} else if (onEdge && !slamming){
			walkAnim ();
			moveBack ();
		}
	}
		
	public void walkAnim(){
		walkX ();
		walkY ();
		walkZ ();
	}

	public void chase(){
		if (Vector3.Distance (transform.position, Target.position) < 15.0f 
			&& Vector3.Distance (transform.position, Target.position)>4.5f) {
			moveTowardsTarget ();
			rotateTowardsTarget ();
		}
	}

	public void faceSlam(){
		slamming = true;
		mainBox.SetActive (false);
		transform.eulerAngles = new Vector3(5f, transform.eulerAngles.y, transform.eulerAngles.z); 
		slamCount++;
		if (slamCount <= 30) {
			killbox.SetActive (true);
			checkbox.SetActive (true);
			slamplayed = false;
			transform.Rotate (0, 0, -3);
		} else if (slamCount > 30 && slamCount <= 150) {
			weakbox.SetActive (true);
			transform.Rotate (0, 0, 0);
			if (!slamplayed) {  
				GetComponent<AudioSource> ().PlayOneShot (Slam);
				slamplayed = true;
			}
			if (slamCount >= 33)
				mainBox.SetActive (true);
		} else if (slamCount > 150 && slamCount <= 180) {
			transform.Rotate (0, 0, 3);
			killbox.SetActive (false);
			weakbox.SetActive (false);
			mainBox.SetActive (true);
		} else {
			reset ();
			checkbox.SetActive (false);
			slamCount = 0;
			hurtable = true;
			slamming = false;
		}
	}

	public void moveBack (){
		chaseSpeed = 1.5f * Time.deltaTime;
		backing = true;
		if (transform.position.x < Center.transform.position.x) {
			transform.position = new Vector3 (transform.position.x + chaseSpeed, transform.position.y, transform.position.z);
		}
		else if (transform.position.x > Center.transform.position.x) {
			transform.position = new Vector3 (transform.position.x - chaseSpeed, transform.position.y, transform.position.z);
		}
		if (transform.position.z < Center.transform.position.z) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + chaseSpeed);
		}
		else if (transform.position.z > Center.transform.position.z) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - chaseSpeed);
		}
		if (Vector3.Distance (transform.position, Center.position) < 1.0f) {
			backing = false;
			onEdge = false;
		}
	}

	public void hurtSelf(){
		if (hurtable) {
			health--;
			if (health > 0)
				GetComponent<AudioSource> ().PlayOneShot (Hurt);
			hurtable = false;
		}
		if (health <= 0) {
			reward.SetActive (true);
			GetComponent<AudioSource> ().PlayOneShot (Hurt);
			GetComponent<AudioSource> ().PlayOneShot (Star);
			for (int i = 0; i < toDestroy.Length; i++)
				Destroy (toDestroy[i]);
			for (int i = 0; i < deathEffects.Length; i++)
				deathEffects [i].SetActive (true);
			Destroy (this);
		}
	}

	public void checkPlay(){
		if (Vector3.Distance (transform.position, Target.position) < 15.0f) {
			playable = true;
		} else {
			playable = false;
		}
	}

	public void checkBound(){
		if (GameObject.FindObjectOfType<boundCollider> ().collided == true && !slamming) {
			onEdge = true;
		}
	}

	public void reset(){
		walkXCount = 0;
		walkYCount = 0;
		transform.eulerAngles = new Vector3(startX, startY, startZ); 
	}

	//Sub-Action Block
	public void walkX(){
		walkXCount++;
		if (walkXCount <= 20) {
			transform.Rotate (1, 0, 0);
			played = false;
		} else if (walkXCount > 20 && walkXCount <= 40) {
			transform.Rotate (0, 0, 0);
			if (playable && !played) {  
				GetComponent<AudioSource> ().PlayOneShot (Step, 0.5f);
				played = true;
			}
		} else if (walkXCount > 40 && walkXCount <= 60) {
			transform.Rotate (-1, 0, 0);
			played = false;
		} else if (walkXCount > 60 && walkXCount <= 80) {
			transform.Rotate (0, 0, 0);
			if (playable && !played) {  
				GetComponent<AudioSource> ().PlayOneShot (Step, 0.5f);
				played = true;
			}
		}
		else
			walkXCount = 0;
	}

	public void walkY(){
		walkYCount++;
		if (walkYCount <= 20) 
			transform.Rotate (0, 0, 0);
		else if (walkYCount > 20 && walkYCount <= 40) 
			transform.Rotate (0, -1, 0);
		else if (walkYCount > 40 && walkYCount <= 60)
			transform.Rotate (0, 0, 0);
		else if (walkYCount > 60 && walkYCount <= 80)
			transform.Rotate (0, 1, 0);
		else
			walkYCount = 0;
	}

	public void walkZ(){
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0); 
	}

	public void moveTowardsTarget(){
		chaseSpeed = 1.5f * Time.deltaTime;
		if (transform.position.x < Target.transform.position.x) {
			transform.position = new Vector3 (transform.position.x + chaseSpeed, transform.position.y, transform.position.z);
		}
		else if (transform.position.x > Target.transform.position.x) {
			transform.position = new Vector3 (transform.position.x - chaseSpeed, transform.position.y, transform.position.z);
		}
		if (transform.position.z < Target.transform.position.z) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + chaseSpeed);
		}
		else if (transform.position.z > Target.transform.position.z) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - chaseSpeed);
		}
	}
	public void rotateTowardsTarget(){
		if (GameObject.FindObjectOfType<whompScanner> ().face == true) {
			//transform.Rotate (0, 0, 0);
			print ("front");
		} else if (GameObject.FindObjectOfType<leftScanner> ().face == true) {
			transform.Rotate (0, 2.5f, 0);
			print ("left");
		} else if (GameObject.FindObjectOfType<rightScanner> ().face == true) {
			transform.Rotate (0, -2.5f, 0);
			print ("right");
		} else {
			transform.Rotate (0, 2.5f, 0);
			print ("back");
		}
	}
	//Sub-Action Block
}