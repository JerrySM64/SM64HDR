using UnityEngine;
using System.Collections;

public class StarCoin : MonoBehaviour
{

    public int Value = 1;
    public bool UniformHeight = true;
    public float PlacementHeight = 0.6f;
    public float SpinSpeed = 360.0f;
    public GameObject DeathEffect;
    public AudioClip StarSound;
    public Transform Art;
    public float ScaleAmount = 1.2f;
    public float ScaleTime = 0.5f;
    public float RotationSpeed = 360.0f;
    private Vector3 initialScale;
    private float currentRotation;

    void Awake()
    {
        RaycastHit hit;

        if (UniformHeight && Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity))
        {
            transform.position = hit.point + Vector3.up * PlacementHeight;
        }
    }

    void Update()
    {

        Art.Rotate(Vector3.forward, SpinSpeed * Time.deltaTime);

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Death();
        }
    }

    void Death()
    {
        GameObject.FindObjectOfType<GameMaster>().AddStarCoin();

        if (DeathEffect)
            Instantiate(DeathEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
