using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelMenu : MonoBehaviour {
    
    public MatteFade WhiteMatte;
    public MatteFade BlackMatte;

    public float InitialWait = 1.0f;
    public float FadeInTime = 0.6f;
    public float FadeOutTime = 1.0f;

	private bool play = false;

    public AudioClip EnterLevel;
    public AudioClip LetsAGo;
    public AudioClip ClickButton;

    public GameObject QuitButtonExe;

    public string [] LevelName;
    public StarGraphic [] Star;

    public void Start()
    {
		play = false;
        StartCoroutine(FadeIntoMenu());

        if (Application.isWebPlayer)
        {
            QuitButtonExe.SetActive(false);
        }
    }

	public void Update() {
		if (play) {
			if (Input.GetKeyDown ("j") || Input.GetKeyDown("joystick button 0")) {
				StartLevel (0);
				play = false;
			}
		}
	}

    IEnumerator FadeIntoMenu()
    {
        yield return new WaitForSeconds(InitialWait);

        BlackMatte.FadeIn(FadeInTime);

        yield return new WaitForSeconds(InitialWait * 2);

        WhiteMatte.FadeIn(FadeInTime);

        GetComponent<AudioSource>().Play();

		play = true;
    }

	IEnumerator LoadLevel(int i, float delayTime)
    {
		yield return new WaitForSeconds(delayTime);
        Application.LoadLevel(LevelName[i]);
    }
    
    public void ExitGame()
    {
        GetComponent<AudioSource>().PlayOneShot(ClickButton);

		Application.LoadLevel("InsideScene");
    }

	public void StartLevel(int levelIndex)
    {
        // Let's-a-Go!
        WhiteMatte.FadeOut(FadeOutTime);

        GetComponent<AudioSource>().PlayOneShot(EnterLevel);
        GetComponent<AudioSource>().PlayOneShot(LetsAGo);

		Star[levelIndex].StartLevelAnimation();

		StartCoroutine (LoadLevel (levelIndex, FadeOutTime));
    }
}
