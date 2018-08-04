using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class StarMenu : MonoBehaviour {

    public GameObject DefaultInputs;
    
    public MatteFade WhiteMatte;
    public MatteFade BlackMatte;

    public float InitialWait = 1.0f;
    public float FadeInTime = 0.6f;
    public float FadeOutTime = 1.0f;

    public AudioClip EnterLevel;
    public AudioClip LetsAGo;
    public AudioClip ClickButton;

    public GameObject QuitButtonExe;

    public string LevelName;

    private InputManager inputManager;

	public bool startable = false;

	public GameObject titleText;
	public GameObject quit;
    public GameObject saveEditor;
    public GameObject exitEditor;
    public Button deleteSave;

    private bool saveExists;

    private string Path;

    public void Awake()
    {
		titleText.SetActive (false);
		quit.SetActive (false);
        saveEditor.SetActive (false);
        exitEditor.SetActive (false);
        deleteSave.gameObject.SetActive (false);

        inputManager = GameObject.FindObjectOfType<InputManager>();

		startable = false;

        if (!inputManager)
        {
            inputManager = ((GameObject)Instantiate(DefaultInputs, Vector3.zero, Quaternion.identity)).GetComponent<InputManager>();
        }

        if (Application.isEditor)
        {
            Path = Application.persistentDataPath + "/save.sm64hdrsave";
        }
        else
        {
            Path = Application.streamingAssetsPath + "/save.sm64hdrsave";
        }
    }

    public void Start()
    {
        inputManager.UpdateKeyBindings();

        StartCoroutine(FadeIntoMenu());

        if (Application.isWebPlayer)
        {
            QuitButtonExe.SetActive(false);
        }
    }

	void Update(){
		if (Input.GetKeyDown (KeyCode.Return) && startable==true) {
			StartLevel ();
			startable = false;
		}

        if (exitEditor.active)
        {
            if (File.Exists(Path))
            {
                deleteSave.interactable = true;
            }
            else
            {
                deleteSave.interactable = false;
            }
        }
	}

    IEnumerator FadeIntoMenu()
    {
        yield return new WaitForSeconds(InitialWait);

        BlackMatte.FadeIn(FadeInTime);

        yield return new WaitForSeconds(InitialWait * 2);

        WhiteMatte.FadeIn(FadeInTime);
		WhiteMatte.FadeOut(FadeInTime);
		startable = true;
		titleText.SetActive (true);
		quit.SetActive (true);
        saveEditor.SetActive (true);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(LevelName);
    }

    public void OpenControlsMenu()
    {
        GetComponent<AudioSource>().PlayOneShot(ClickButton);
    }

    public void CloseControlsMenu()
    {
        GetComponent<AudioSource>().PlayOneShot(ClickButton);
    }

    public void ExitGame()
    {
        GetComponent<AudioSource>().PlayOneShot(ClickButton);

		Application.LoadLevel(0);
    }

    public void DeleteSave()
    {
        //File.Delete(Path);
		GameObject.FindObjectOfType<GameMaster>().erase();
    }

	public void EndGame()
	{
		GetComponent<AudioSource>().PlayOneShot(ClickButton);
		Application.Quit();
	}

    public void StartLevel()
    {
		stopSound ();
        WhiteMatte.FadeIn(FadeOutTime);
		titleText.SetActive (false);
		quit.SetActive (false);
        saveEditor.SetActive (false);

        GetComponent<AudioSource>().PlayOneShot(EnterLevel);
        GetComponent<AudioSource>().PlayOneShot(LetsAGo);

        Invoke("LoadLevel", FadeOutTime);
    }

	public void stopSound(){
		bool[] wasPlaying;
		AudioSource[] allSources = GameObject.FindObjectsOfType<AudioSource>();

		wasPlaying = new bool[allSources.Length];

		for (int i = 0; i < allSources.Length; i++)
		{
			var source = allSources[i];

			if (source.isPlaying)
			{
				wasPlaying[i] = true;
				source.Pause();
			}
		}
	}
}
