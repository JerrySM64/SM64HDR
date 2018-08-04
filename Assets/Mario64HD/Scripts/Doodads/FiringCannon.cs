using UnityEngine;
using System.Collections;

public class FiringCannon : MonoBehaviour {

    public Transform Turret;
    public Transform FireTarget;
    public GameObject FireParticle;
    public GameObject Projectile;
    public float TurretAngle = 45.0f;
    public float TurnSpeed = 35.0f;
    public float TargetWaitTime = 1.0f;
    public float AfterShotWaitTime = 3.0f;

    public float CameraShakeDistance = 20.0f;

    public float[] FireTargetAngles;

    private Quaternion initialRotation;

    private int nextFireTargetAngle = 0;

    private MarioVerySmartCamera smartCamera;

	void Start () {
        Turret.rotation = Quaternion.AngleAxis(TurretAngle, Turret.forward) * Turret.rotation;

        initialRotation = transform.rotation;

        smartCamera = Camera.main.GetComponent<MarioVerySmartCamera>();

        StartCoroutine(MoveToAndFire(FireTargetAngles[nextFireTargetAngle]));
	}

    IEnumerator MoveToAndFire(float angle)
    {
        Quaternion targetRotation = Quaternion.AngleAxis(angle, transform.up) * initialRotation;

        GetComponent<AudioSource>().Play();

        while (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);
            yield return 0;
        }

        GetComponent<AudioSource>().Stop();

        yield return new WaitForSeconds(TargetWaitTime);

        GetComponent<Animation>().Play();

        float distance = Vector3.Distance(smartCamera.transform.position, FireTarget.position);

        if (distance < CameraShakeDistance)
        {
            float magnitude = Mathf.Lerp(0.4f, 0, Mathf.InverseLerp(5.0f, CameraShakeDistance, distance));

            smartCamera.Shake(magnitude, 20.0f, 0.5f);
        }

        Instantiate(FireParticle, FireTarget.position, Turret.rotation);

        Instantiate(Projectile, FireTarget.position, Quaternion.LookRotation(Turret.up));

        yield return new WaitForSeconds(AfterShotWaitTime + GetComponent<Animation>().clip.length);

        nextFireTargetAngle = (nextFireTargetAngle + 1) % FireTargetAngles.Length;

        StartCoroutine(MoveToAndFire(FireTargetAngles[nextFireTargetAngle]));
    }
}
