using UnityEngine;
using System.Collections;

public class RollingBallGoldDestroy : MonoBehaviour {

    public GameObject DeathParticle;
    public GameObject ObjectSpawnedOnDeath;

	public void BlowUp () {
        Instantiate(DeathParticle, transform.position, Quaternion.identity);
        Instantiate(ObjectSpawnedOnDeath, transform.position, Quaternion.identity);

        SendMessage("DestroySmokeEffect", SendMessageOptions.DontRequireReceiver);

        Destroy(gameObject);
	}
}
