using UnityEngine;
using System.Collections;

public class WaterBombSpawner : MonoBehaviour {

    public GameObject WaterBomb;
    public float Height = 20.0f;
    public float ReloadTime = 3.0f;

    private float lastSpawnTime;

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && SuperMath.Timer(lastSpawnTime, ReloadTime))
        {
            Vector3 targetPosition = col.transform.position + Math3d.ProjectVectorOnPlane(Vector3.up, col.GetComponent<MarioMachine>().Velocity());

            Instantiate(WaterBomb, targetPosition + Height * Vector3.up, Quaternion.identity);

            lastSpawnTime = Time.time;
        }
    }
}
