using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThwompScript : MonoBehaviour {

    public GameObject Face1;
    public GameObject Face2;
	public GameObject squishZone;
    private Vector3 pos2;
    private Vector3 origPoint;
    float distance;

	public Transform Mario;
    bool up = false;
    bool down = true;
    bool waited = true;
	bool canPlay = false;
	bool canKill = false;

    public float YCordinate = 3.52f;

    public void Start() {
        origPoint = transform.position;
        pos2 = transform.position;
        pos2.y -= YCordinate;
    }

    void Update () {
		if (canKill)
			squishZone.SetActive (true);
		else
			squishZone.SetActive (false);
		GameObject.FindObjectOfType<MarioMachine> ().squishable = canKill;
		checkSound ();
        if (up)
        {
            if(waited)
            {
                distance = Vector3.Distance(transform.position, pos2);
                Face2.SetActive(true);
                Face1.SetActive(false);
                if (distance > .1)
                {
                    transform.position = Vector3.MoveTowards(transform.position, pos2, .2f);
					canKill = true;
                }
                else
                {
					canKill = false;
                    up = false;
                    down = true;
                    StartCoroutine(waitdown());
					if (canPlay == true) {
						AudioSource crush = GetComponent<AudioSource> ();
						crush.Play ();
					}
                }
            }
        } else if(down) {
            if(waited)
            {
                distance = Vector3.Distance(transform.position, origPoint);
                Face1.SetActive(true);
                Face2.SetActive(false);
                if (distance > .1)
                {
                    transform.position = Vector3.MoveTowards(transform.position, origPoint, .05f);
                }
                else
                {
                    up = true;
                    down = false;
                    StartCoroutine(waitup());

                }
            }
        }
    }

	void checkSound(){
		if (Vector3.Distance (transform.position, Mario.position) < 40.0f) {
			canPlay = true;
		} else {
			canPlay = false;
		}
	}

    IEnumerator waitup()
    {
        up = false;
        down = false;
        waited = false;
        yield return new WaitForSeconds(2.0f);
        waited = true;
        up = true;
    }

    IEnumerator waitdown()
    {
        up = false;
        down = false;
        waited = false;
        yield return new WaitForSeconds(2.0f);
        waited = true;
        down = true;
    }
}
