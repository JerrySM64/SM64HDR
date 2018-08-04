using UnityEngine;
using System.Collections;

public class MarioStatus : MonoBehaviour {

    // Don't bother changing this in the inspector. Like you have a choice
    public int Health = 8;
    public HealthDisc Disc;

    public float InvicibleTime = 2.0f;
    public float FlickersPerSecond = 45.0f;

    [HideInInspector]
    public bool PermanentInvincibility;

    public int CurrentHealth { get; private set; }

    private Component[] renderers;
    private bool invincible;
    private MarioSound sound;
    private float lastHealTime;

    void Start()
    {
		print (CurrentHealth);

        CurrentHealth = Health;

        invincible = false;

        renderers = GetComponent<MarioMachine>().AnimatedMesh.GetComponentsInChildren(typeof(Renderer));

        sound = GetComponent<MarioSound>();
    }

    public void TakeDamage(int damage)
    {

        CurrentHealth = (int)Mathf.Clamp(CurrentHealth - damage, 0, Health);

        Disc.UpdateDisc(CurrentHealth);

        invincible = true;

        Disc.Maximize();
    }

    public void AddHealth(int health)
    {
        if (CurrentHealth != Health)
            sound.PlayGetLife();

        // Are we fully healing?
        if (CurrentHealth != Health && CurrentHealth + health >= Health)
            Disc.Minimize();

        CurrentHealth = (int)Mathf.Clamp(CurrentHealth + health, 0, Health);

        Disc.UpdateDisc(CurrentHealth);
    }

    public void StartInvincible()
    {
        if (invincible)
            StartCoroutine(Invicibility());
    }

    public bool Invincible()
    {
        if (PermanentInvincibility)
            return true;
        else
            return invincible;
    }

    public void EndInvincible()
    {
        StopAllCoroutines();
        invincible = false;
    }

    private IEnumerator Invicibility()
    {
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = false;
        }

        float i = 0;
        float lastFlicker = 0;
        float flickerFrequency = InvicibleTime / FlickersPerSecond;

        while (i < InvicibleTime)
        {
            if (i > lastFlicker + flickerFrequency)
            {
                foreach (Renderer renderer in renderers)
                {
                    renderer.enabled = !renderer.enabled;
                }

                lastFlicker = i;
            }

            i += Time.deltaTime;

            yield return 0;
        }

        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = true;
        }

        invincible = false;

        yield return null;
    }
}
