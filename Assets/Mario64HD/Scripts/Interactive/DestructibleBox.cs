using UnityEngine;
using System.Collections;

public class DestructibleBox : TriggerableObject {

    public GameObject DeathParticle;
    public GameObject Debris;

    public GameObject ObjectSpawnedOnDeath;

    public override bool GroundPound()
    {
        Explode();

        return true;
    }

    public override bool Strike()
    {
        Explode();

        return true;
    }

    private void Explode()
    {
        Instantiate(DeathParticle, transform.position, Quaternion.identity);

        if (Debris)
            Instantiate(Debris, transform.position, Quaternion.AngleAxis(Random.Range(-360, 360), Vector3.up));

        if (ObjectSpawnedOnDeath)
            Instantiate(ObjectSpawnedOnDeath, transform.position, Quaternion.identity);

        DestroyImmediate(gameObject);
    }
}
