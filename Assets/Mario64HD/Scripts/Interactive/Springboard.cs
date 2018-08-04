using UnityEngine;
using System.Collections;

public class Springboard : TriggerableObject {

    public Transform AnimatedMesh;

	public GameObject thisSpring;
	public GameObject anotherSpring;

    public float velocity = 15.0f;
    public float lift = 50.0f;

    public float lastSpringTime;

	public bool turningSpring;
	public bool switchingSpring;

	private int turn = 0;
	private int turnState;
	public float turnMin;
	public float turnMax;

    public override bool StandingOn(Vector3 position)
    {
        if (SuperMath.Timer(lastSpringTime, 1.0f))
        {
            AnimatedMesh.GetComponent<Animation>().Play();

            GameObject.FindGameObjectWithTag("Player").GetComponent<MarioMachine>().MegaSpring(transform.forward, velocity, lift);

            GetComponent<AudioSource>().Play();

            lastSpringTime = Time.time;
        }

        return false;
    }
	void Update(){
		if (switchingSpring) {
			spinCount ();
			changeSpring ();
		}
	}
	public void spinCount(){
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

	public void Spin(){
		if (turnState == 1) {
			if (transform.rotation.y < turnMax)
				transform.Rotate (Vector3.up, 100 * Time.deltaTime);
		} else if (turnState == -1) {
			if (transform.rotation.y < turnMin) 
				transform.Rotate (Vector3.down, 100 * Time.deltaTime);
		}
	}

	public void changeSpring(){
		if (turnState == 1) {
			anotherSpring.SetActive (true);
			thisSpring.SetActive (false);
		} else if (turnState == -1) {
			anotherSpring.SetActive (false);
			thisSpring.SetActive (true);
		}
	}
}
