using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
public class ChangeMixer : MonoBehaviour {
	public AudioMixer mixer;
	public float pitch = 1.00f;
	public int lowpass = 22000;
	// Use this for initialization
	void Awake () {
		mixer.SetFloat("Pitch",pitch);
		mixer.SetFloat("Lowpass",lowpass);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
