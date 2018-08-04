using UnityEngine;
using System.Collections;

public class RollingBallPathSpawner : MonoBehaviour {

    public Color SpawnColor = Color.grey;
    public string SpawnPath = "RollingBallPath";
    public bool WallBouncer = false;
    public GameObject SpawnedObject;
    public float SpawnInterval = 6.0f;

    private bool canSpawn = true;

	// Use this for initialization
	void Start () {
        Spawn();
	}

    void Spawn()
    {
        if (canSpawn)
        {
            RollingBallPath path = (Instantiate(SpawnedObject, transform.position, Quaternion.identity) as GameObject).GetComponent<RollingBallPath>();

            path.PathName = SpawnPath;
            path.WallBouncer = WallBouncer;
        }

        Invoke("Spawn", SpawnInterval);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = SpawnColor;
        Gizmos.DrawSphere(transform.position, 1.75f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            canSpawn = false;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            canSpawn = true;
        }
    }
}
