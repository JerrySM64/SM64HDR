using UnityEngine;
using System.Collections;

public class BlueSwitch : TriggerableObject {

    public GameObject Effect;

	public GameObject[] Coin;

    public float DropHeight = 0.5f;

    private int currentPounds = 0;

    private float lastPounded;

    public override bool GroundPound()
    {
        if (SuperMath.Timer(lastPounded, 0.4f) && currentPounds < 1)
        {
            lastPounded = Time.time;

			Drop ();

			for (int i = 0; i < Coin.Length; i++) {
				Coin [i].SetActive (true);
			}

            return true;
        }

        return false;
    }

	void Drop()
	{
		Instantiate(Effect, transform.position + transform.forward * ((DropHeight / 1) * currentPounds + 0.2f), Quaternion.identity);

		transform.position -= transform.forward * DropHeight / 1;

		currentPounds++;
	}
}
