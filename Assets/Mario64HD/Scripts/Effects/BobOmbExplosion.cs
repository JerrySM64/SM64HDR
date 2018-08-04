using UnityEngine;
using System.Collections;

public class BobOmbExplosion : MonoBehaviour {

    public float Duration = 0.5f;
    public float Radius = 3.0f;
    public float Delay = 0.05f;
    public float CameraShakeDistance = 10.0f;

    private float startTime;

	void Start () {
        startTime = Time.time;
        
        Invoke("Death", Duration);

        float distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        if (distance < CameraShakeDistance)
        {
            float magnitude = Mathf.Lerp(0.4f, 0, Mathf.InverseLerp(5.0f, CameraShakeDistance, distance));

            Camera.main.GetComponent<MarioVerySmartCamera>().Shake(magnitude, 20.0f, 0.5f);
        }
	}
	
	void Update () {

        if (SuperMath.Timer(startTime, Delay))
        {
            // Haha I still can't get over "PlayerMask"
            Collider[] cols = Physics.OverlapSphere(transform.position, Radius);

            foreach (var col in cols)
            {
                if (col.gameObject.tag == "Player")
                {
                    col.gameObject.GetComponent<MarioMachine>().HeavyDamage(2, transform.position);
                }

                var trigger = col.gameObject.GetComponent<TriggerableObject>();

                if (trigger)
                {
                    trigger.Explosion();
                }

                var machine = col.gameObject.GetComponent<EnemyMachine>();

                if (machine)
                {
                    machine.Explosion();
                }
            }
        }
	}

    void Death()
    {
        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
