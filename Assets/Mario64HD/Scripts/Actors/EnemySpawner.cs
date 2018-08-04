using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public Color SpawnColor = Color.grey;
    public GameObject SpawnedEnemy;

    public float SpawnDistance = 50.0f;
    public float SpawnTime = 2.0f;

    private Transform target;
    private bool patronDead;
    private float patronDeathTime;

    private bool firstSpawn = true;

	// Use this for initialization
	void Start () {
        target = GameObject.FindWithTag("Player").transform;

        Spawn();
	}
	
	// Update is called once per frame
	void Update () {
        if (patronDead && Time.time > patronDeathTime + SpawnTime)
        {
            if (Vector3.Distance(target.position, transform.position) > SpawnDistance)
            {
                Spawn();
            }
        }
	}

    void Spawn()
    {
        patronDead = false;

        RaycastHit hit;

        Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity);

        var machine = ((GameObject)Instantiate(SpawnedEnemy, hit.point, Quaternion.identity)).GetComponent<EnemyMachine>();

        machine.target = target;
        machine.server = this;

        if (!firstSpawn)
            machine.canDropObjectOnDeath = false;

        firstSpawn = false;
    }

    public void PatronDeath()
    {
        patronDead = true;
        patronDeathTime = Time.time;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = SpawnColor;
        Gizmos.DrawCube(transform.position, new Vector3(1,1,1));
    }
}
