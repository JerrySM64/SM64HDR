using UnityEngine;
using System.Collections;

public class StarGraphic : MonoBehaviour {

    public ParticleSystem HoverParticles;

    public float ScaleAmount = 1.2f;
    public float ScaleTime = 0.5f;
    public float RotationSpeed = 360.0f;

    public bool Hovered { get; set; }

    private Vector3 initialScale;
    private float currentRotation;

    private bool animating;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {



			
    }

    public void StartLevelAnimation()
    {
        StartCoroutine(SpinAnimation());
    }

    IEnumerator SpinAnimation()
    {
        animating = true;

        float acceleration = 0;

        while (true)
        {
            acceleration += 700.0f * Time.deltaTime;
            currentRotation = SuperMath.ClampAngle(currentRotation + acceleration * Time.deltaTime);
            transform.rotation = Quaternion.AngleAxis(currentRotation, Vector3.down);

            yield return 0;
        }
    }
}
