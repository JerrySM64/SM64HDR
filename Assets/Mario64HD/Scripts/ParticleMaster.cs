using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Attach this to any object that is either a ParticleSystem, or has one or more ParticleSystems
/// as child objects. After all ParticleSystems (including the children and this object's) have finished emitting
/// the object will self-destruct, or alternatively if an audio source is playing will self-destruct after both it
/// and the particle systems have finished playing
/// </summary>
public class ParticleMaster : MonoBehaviour {

    [SerializeField]
    bool waitForAudioSource;

    private List<ParticleSystem> particles;

    void Start()
    {
        particles = new List<ParticleSystem>();

        foreach (Transform child in transform)
        {
            if (child.GetComponent<ParticleSystem>() != null)
            {
                particles.Add(child.GetComponent<ParticleSystem>());
            }
        }

        if (gameObject.GetComponent<ParticleSystem>() != null)
        {
            particles.Add(gameObject.GetComponent<ParticleSystem>());
        }
    }

    public void Emit(bool emit)
    {
        foreach (var particle in particles)
        {
            particle.loop = emit;
        }
    }

    void Update()
    {
        if (waitForAudioSource && GetComponent<AudioSource>() && GetComponent<AudioSource>().isPlaying)
            return;

        foreach (var particle in particles)
        {
            if (particle.IsAlive())
            {
                return;
            }
        }

        Destroy(gameObject);
    }
}
