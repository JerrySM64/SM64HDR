using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
public class ChangeBGColor : MonoBehaviour {

    public Camera[] Cameras;
	public Color color;
	public AudioMixer mixer;

    public Material Skybox;
    
	void Awake () {

        for (int i = 0; i < Cameras.Length; i++)
        {
            Cameras[i].clearFlags = CameraClearFlags.Skybox;
        }

        RenderSettings.skybox = Skybox;

        //print("worked");

		/*ReflectionProbe[] probes = FindObjectsOfType(typeof(ReflectionProbe)) as ReflectionProbe[];

		foreach (ReflectionProbe probe in probes) {
			probe.backgroundColor = color;
		}*/

		mixer.SetFloat("Pitch",0.75f);
		mixer.SetFloat("Lowpass",2321);
	}

	public void Awakeit()
    {
        for (int i = 0; i < Cameras.Length; i++)
        {
            Cameras[i].clearFlags = CameraClearFlags.Skybox;
        }

        RenderSettings.skybox = Skybox;

        //print("worked");

        /*ReflectionProbe[] probes = FindObjectsOfType(typeof(ReflectionProbe)) as ReflectionProbe[];

		foreach (ReflectionProbe probe in probes) {
			probe.backgroundColor = color;
		}*/

        mixer.SetFloat("Pitch", 0.75f);
        mixer.SetFloat("Lowpass", 2321);
    }
}
