using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Text;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour {
    public bool DebugGUI;

    private int redCoinStarCount;
    private int raceSoundCount = 0;

    public float FadeInTime = 0.3f;
    public float StarAniTime = 4f;
    public float ExitFadeOutTime = 0.5f;

    public bool raceStarted;
    public bool raceEnded = false;
    public bool marioWon;
    public bool enterCastle;
    public bool exitCastle;
    public bool whompsEnter;
    public bool bobOmbEnter;
    public bool stopTimer = false;

    public GameObject Appear;
    public GameObject AppearCoin;
    public Renderer AppearCoinRender;
	public GameObject AppearRed;
	public GameObject AppearRing;
	public GameObject topGoombas;

    public AudioSource MusicSource;
    public AudioSource SoundSource;

    public MarioInput MarioIn;
    public KeybindingInputHandler Handler;

    public GameObject DefaultInputs;

    private Vector3 ApperPossition;
    public Transform MarioTransform;

    public GameObject PauseMenu;
    public GameObject PauseCamera;
    public GameObject MarioCamera;
    public GameObject starAsk;
	public GameObject Player;
    public AudioClip raceFanfare;
    public AudioClip raceMusic;
    public AudioClip coinContinue;
    public AudioClip CoinSound;
    public AudioClip RedSound;
    public AudioClip StarSound;
	public AudioClip CollectedStarSound;
    public AudioClip StarAppear;
    public AudioClip PauseSound;
    public AudioClip BowserLaugh;
    public AudioClip enterSound;
    public AudioClip LivesSound;
    public MatteFade WhiteMatte;
    public MatteFade BlackMatte;
    public BowserMask DeathMask;
    public Text FramerateText;
    public int GoldMarioCoinAmount;
    public int overed;

    public int currentCoins = 0;
    public static int currentStars = 0;
    public static int currentLives = 4;
    private int savedStars = 0;
    public int currentRed = 0;
    public int currentRing = 0;
    public int ringStar = 0;
    public int enterPlay = 0;
	public int redPlay = 0;
    private CoinTextHandler coinTextHandler;
    private StarTextHandler starTextHandler;
    private LivesTextHandler livesTextHandler;

    private bool paused;
    private bool addable;
    public bool pausable = true;

    private InputManager inputManager;

    public Camera mainCamera;
    public ChangeBGColor skybox;

    public bool wf = false;
	public bool ps = false;

    public MyStats stats;
    public string path;
    public string jsonString;

	int scanLength = 120;
	int [] starCollected = new int[120];
	int currentStarID;
	bool starAction;

    void Awake()
    {
		starAction = false;
		redPlay = 0;
        if (Application.isEditor)
        {
            path = Application.persistentDataPath + "/save.sm64hdrsave";
            Debug.Log(path);
        } else
        {
            path = Application.streamingAssetsPath + "/save.sm64hdrsave";
        }
        

        /*if (PlayerPrefs.HasKey("savedStars"))
        {
            savedStars = PlayerPrefs.GetInt("savedStars");
            currentStars = savedStars;
        }*/
		AppearRed.SetActive(false);

        starAsk.SetActive(false);

        if (File.Exists(path))
        {
            Load();
			currentStars = stats.Stars;
        }

        wf = false;
        pausable = true;
        Application.targetFrameRate = 150;

        redCoinStarCount = 0;
        ringStar = 0;
        enterPlay = 0;
        overed = 0;

        raceStarted = false;
        enterCastle = false;
        exitCastle = false;
        bobOmbEnter = false;
        whompsEnter = false;

        // There can be only one!
        if (GameObject.FindObjectsOfType<GameMaster>().Length > 1)
        {
            Debug.LogError("Multiple GameMaster components detected in the scene. Limit 1 GameMaster per scene");
        }

        coinTextHandler = GetComponent<CoinTextHandler>();

        coinTextHandler.UpdateValue(currentCoins);

        starTextHandler = GetComponent<StarTextHandler>();

        starTextHandler.UpdateValue(currentStars);

        livesTextHandler = GetComponent<LivesTextHandler>();

        livesTextHandler.UpdateValue(currentLives);

        inputManager = GameObject.FindObjectOfType<InputManager>();

        if (inputManager == null)
        {
            inputManager = ((GameObject)Instantiate(DefaultInputs, Vector3.zero, Quaternion.identity)).GetComponent<InputManager>();
        }

        MarioIn.input = inputManager;
        Handler.input = inputManager;

        PauseMenu.SetActive(false);
        PauseCamera.SetActive(false);

        mainCamera = Camera.main;

        WhiteMatte.FadeIn(FadeInTime);

        if (!DebugGUI)
            FramerateText.gameObject.SetActive(false);

        MusicSource.timeSamples = (int)(1 * MusicSource.clip.frequency);

        starTextHandler.UpdateValue(savedStars);

        skybox.Awakeit();

        GameObject.FindObjectOfType<DiscordController>().onSetClock();
        GameObject.FindObjectOfType<DiscordController>().currentLives = currentLives;
        GameObject.FindObjectOfType<DiscordController>().currentStars = currentStars;
        GameObject.FindObjectOfType<DiscordController>().OnClick();
    }

    private float lastFrameRateUpdate;

	public void recover (){
		currentLives = 4;
	}

//	public void starCollect(int ID){
//		if (currentStarID == 0){
//			AddStar ();
//			starCollected [currentStarID] = ID;
//			currentStarID ++;
//		} else {
//			for (int i = 0; i < scanLength; i++) {
//				if (ID == starCollected [i]) {
//					AddCollectedStar ();
//					starAction = true;
//					print ("detected");
//				}
//			}
//			if (!starAction) {
//				AddStar ();
//				starAction = true;s
//			}
//		}
//	}

    void Update()
    {
        starTextHandler.UpdateValue(currentStars);
        livesTextHandler.UpdateValue(currentLives);
		if (!wf && !ps) {
			if (GameObject.FindObjectOfType<MarioMachine> ().transform.position.y <= -10 && overed == 0) {
				GameOver ();
				overed++;
			}
		} else if (wf && !ps) {
			if (GameObject.FindObjectOfType<MarioMachine> ().transform.position.y <= -10 && overed == 0) {
				GameOver ();
				overed++;
			}
		} else if (ps) {
			if (GameObject.FindObjectOfType<MarioMachine> ().transform.position.y <= 0 && overed == 0) {
				GameOver ();
				overed++;
			}
		}
        if (currentCoins >= GoldMarioCoinAmount && redCoinStarCount == 0)
        {
            //AppearCoin.SetActive(true);
            AppearCoinRender.enabled = true;
            Instantiate(AppearCoin, new Vector3(MarioTransform.position.x, MarioTransform.position.y + 2.2f, MarioTransform.position.z), Quaternion.Euler(new Vector3(270, 90, 90)));
            if (redCoinStarCount == 0) {
                SoundSource.PlayOneShot(StarAppear);
            }
            redCoinStarCount += 1;

        }
        if (currentRed == 8)
        {
            // Instantiate(Appear, new Vector3(57, 10.26f, 21.15f), Quaternion.Euler(new Vector3(270, 90, 90)));
		    AppearRed.SetActive(true);
            SoundSource.PlayOneShot(StarAppear);
            currentRed++;

        }
        //print (wf);

        if (currentRing == 5)
        {
			//AppearRing.SetActive (true);
            Instantiate(Appear, new Vector3(50.7f, 15, -12.65f), Quaternion.Euler(new Vector3(270, 90, 90)));
            SoundSource.PlayOneShot(StarAppear);
            currentRing++;

        }

        if (enterCastle == true) {
            if (enterPlay == 0) {
                SoundSource.PlayOneShot(enterSound);
                enterPlay++;
            }
            MarioIn.enabled = false;
            TeleportToInsideCastle();
            //ExitToMainMenu ();
        }

        if (exitCastle == true) {
            if (enterPlay == 0) {
                SoundSource.PlayOneShot(enterSound);
                enterPlay++;
            }
            MarioIn.enabled = false;
            TeleportToOutsideCastle();
            //ExitToMainMenu ();
        }

        if (bobOmbEnter == true) {
            if (enterPlay == 0) {
                SoundSource.PlayOneShot(enterSound);
                enterPlay++;
            }
            MarioIn.enabled = false;
            TeleportToBobombBattlefield();
            GameObject.FindObjectOfType<MarioVerySmartCamera>().canMove = false;
        }

        if (whompsEnter == true) {
            if (enterPlay == 0) {
                SoundSource.PlayOneShot(enterSound);
                enterPlay++;
            }
            MarioIn.enabled = false;
            TeleportToWhompsFortress();
            GameObject.FindObjectOfType<MarioVerySmartCamera>().canMove = false;
        }

        if (inputManager.PauseDown() && pausable == true) {
            if (paused)
                Unpause();
            else
                Pause();
        }
        if ((float)MusicSource.timeSamples / (float)MusicSource.clip.frequency > 140.7f)
        {
            MusicSource.timeSamples = (int)(72.775f * MusicSource.clip.frequency);
        }

        if (DebugGUI && SuperMath.Timer(lastFrameRateUpdate, 0.25f))
        {
            lastFrameRateUpdate = Time.time;
            FramerateText.text = (1.0f / Time.deltaTime).ToString("F0");
        }
		for (int i = 0; i < scanLength; i++)
			starCollected[i] = stats.deadStars[i];
    }

    bool[] wasPlaying;

    public void Pause()
    {
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

        MarioIn.enabled = false;

        Time.timeScale = 0;
        paused = true;
        PauseMenu.SetActive(true);
        PauseCamera.SetActive(true);
        mainCamera.enabled = false;
        inputManager.UpdateKeyBindings();
		if (!pausable)
			Unpause ();

        SoundSource.PlayOneShot(PauseSound);
    }

    public void Unpause()
    {
        AudioSource[] allSources = GameObject.FindObjectsOfType<AudioSource>();

        for (int i = 0; i < allSources.Length; i++)
        {
            var source = allSources[i];

            if (wasPlaying[i])
            {
                source.Play();
            }
        }

        MarioIn.enabled = true;

        Time.timeScale = 1;
        paused = false;
        PauseMenu.SetActive(false);
        PauseCamera.SetActive(false);
        mainCamera.enabled = true;

        SoundSource.PlayOneShot(PauseSound);
    }

    public void starContinue()
    {
        MarioIn.enabled = true;
        pausable = true;
        GameObject.FindObjectOfType<MarioMachine>().starred = false;
        starAsk.SetActive(false);
        SoundSource.clip = coinContinue;
        SoundSource.loop = true;
        SoundSource.volume = 0.3f;
        SoundSource.Play();


    }


    private void pauseAudio() {
		SoundSource.clip = coinContinue;
		SoundSource.volume = 1.0f;
		SoundSource.loop = false;
		SoundSource.Stop();

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

    private void resumeAudio() {
		SoundSource.clip = raceMusic;
		SoundSource.loop = false;
		SoundSource.Stop();
		StartCoroutine(waitForSoundToPlay());

    }

    public void ClosePauseMenu()
    {
        Unpause();
    }

    public void TeleportToInsideCastle()
    {
        StartCoroutine(TeleportToInside());
    }

    public void TeleportToOutsideCastle()
    {
        StartCoroutine(TeleportToOutside());
    }

    public void TeleportToWhompsFortress()
    {
        StartCoroutine(TeleportToWhomps());
    }

    public void TeleportToBobombBattlefield()
    {
        StartCoroutine(TeleportToBobomb());
    }

    public void ExitToMainMenu()
    {
        StartCoroutine(ExitToMenu());
    }

    public void GameOver()
    {
        StartCoroutine(EndGame());
    }

    public void quitCastleButton()
    {
        StartCoroutine(quitCastle());
    }

	public void quitGameButton()
	{
		StartCoroutine(quitGame());
	}

    public void quitInsideButton()
    {
        StartCoroutine(quitInside());
    }

    IEnumerator EndGame()
    {
		MarioIn.enabled = false;

		yield return new WaitForSeconds(1.0f);

		SoundSource.PlayOneShot(BowserLaugh);

		DeathMask.PlayMask(1.5f);

        pausable = false;

		StartCoroutine(FadeOutMusic(1.7f));

		yield return new WaitForSeconds(1.5f);

		BlackMatte.gameObject.SetActive(true);

		yield return new WaitForSeconds(1.0f);

        currentLives--;
   
		if (currentLives >= 0) {
			SceneManager.LoadScene("InsideScene");
		} else {
			SceneManager.LoadScene("gameOver");
		}
    }
    IEnumerator quitInside()
    {
        currentRed = 0;

        Time.timeScale = 1;

        if (enterCastle == false) {
            SoundSource.PlayOneShot(PauseSound);
        }

        BlackMatte.FadeOut(ExitFadeOutTime);

        yield return new WaitForSeconds(ExitFadeOutTime);

        SceneManager.LoadScene("Castle");
    }
    IEnumerator quitCastle()
    {
        currentRed = 0;

        Time.timeScale = 1;

        if (enterCastle == false) {
            SoundSource.PlayOneShot(PauseSound);
        }

        BlackMatte.FadeOut(ExitFadeOutTime);

        yield return new WaitForSeconds(ExitFadeOutTime);

		Application.LoadLevel ("StartMenu");
    }

	IEnumerator quitGame()
	{
		currentRed = 0;

		Time.timeScale = 1;

		if (enterCastle == false) {
			SoundSource.PlayOneShot(PauseSound);
		}

		BlackMatte.FadeOut(ExitFadeOutTime);

		yield return new WaitForSeconds(ExitFadeOutTime);

		Application.Quit ();
	}
    IEnumerator FadeOutMusic(float time)
    {
        float i = 0;

        float initialVolume = MusicSource.volume;

        while (i < 1)
        {
            MusicSource.volume = Mathf.Lerp(initialVolume, 0, i);

            i += Time.deltaTime / time;

            yield return 0;
        }
    }

    public void raceStart() {
        raceStarted = true;
		topGoombas.SetActive (true);
        pauseAudio();
        SoundSource.PlayOneShot(raceFanfare);
        StartCoroutine(waitForSoundToPlay());
    }
    public void raceEnd() {
        if (raceSoundCount == 0 && raceStarted == true) {
            SoundSource.PlayOneShot(raceFanfare);
            raceSoundCount += 1;
        }
    }

    public void AddCoin()
    {
        currentCoins = Mathf.Clamp(currentCoins + 1, 0, 999);

        SoundSource.PlayOneShot(CoinSound);

        coinTextHandler.UpdateValue(currentCoins);

        GameObject.FindObjectOfType<DiscordController>().OnClick();

        if (currentCoins == 100 | currentCoins == 200 | currentCoins == 300 | currentCoins == 400 | currentCoins == 500 | currentCoins == 600 | currentCoins == 700 | currentCoins == 800 | currentCoins == 900 | currentCoins == 999)
        {
            currentLives++;
        }
        if (currentCoins >= 10000000000)
        {
            SoundSource.PlayOneShot(StarAppear);
            GameObject.FindObjectOfType<MarioMachine>().GoldMarioUpgrade();
            GameObject machine = ((GameObject)Instantiate(Appear, new Vector3(59, 3, 67), Quaternion.identity));
        }
    }

    public void AddLives()
    {
        currentLives = Mathf.Clamp(currentLives + 1, 0, 100);
        livesTextHandler.UpdateValue(currentLives);
        SoundSource.PlayOneShot(LivesSound);
        GameObject.FindObjectOfType<DiscordController>().currentLives = currentLives;
        GameObject.FindObjectOfType<DiscordController>().OnClick();
        Analytics.CustomEvent("stats", new Dictionary<string, object>
        {
            { "stars", currentStars },
            { "coins", currentCoins },
            { "lives", currentLives }
        });
    }

    public void AddStar()
    {
        currentStars = Mathf.Clamp(currentStars + 1, 0, 120);
        starTextHandler.UpdateValue(currentStars);
        /*PlayerPrefs.SetInt("savedStars", currentStars);
        PlayerPrefs.Save();*/
        Save();
        GameObject.FindObjectOfType<DiscordController>().currentStars = currentStars;
        GameObject.FindObjectOfType<DiscordController>().OnClick();
        Analytics.CustomEvent("stats", new Dictionary<string, object>
        {
            { "stars", currentStars },
            { "coins", currentCoins },
            { "lives", currentLives }
        });
        GameObject.FindObjectOfType<DiscordController>().OnClick();
        SoundSource.PlayOneShot(StarSound);
        StartCoroutine(StarExit());
    }

	public void AddCollectedStar()
	{
		currentStars = Mathf.Clamp(currentStars, 0, 120);
		starTextHandler.UpdateValue(currentStars);
		/*PlayerPrefs.SetInt("savedStars", currentStars);
        PlayerPrefs.Save();*/
		Save();
		GameObject.FindObjectOfType<DiscordController>().currentStars = currentStars;
		GameObject.FindObjectOfType<DiscordController>().OnClick();
		Analytics.CustomEvent("stats", new Dictionary<string, object>
			{
				{ "stars", currentStars },
				{ "coins", currentCoins },
				{ "lives", currentLives }
			});
		GameObject.FindObjectOfType<DiscordController>().OnClick();
		SoundSource.PlayOneShot(StarSound);
		StartCoroutine(StarExit());
	}

    public void AddStarCoin()
    {
        currentStars = Mathf.Clamp(currentStars + 1, 0, 120);
        starTextHandler.UpdateValue(currentStars);
        /*PlayerPrefs.SetInt("savedStars", currentStars);
        PlayerPrefs.Save();*/
        Save();
        GameObject.FindObjectOfType<DiscordController>().currentStars = currentStars;
        GameObject.FindObjectOfType<DiscordController>().OnClick();
        Analytics.CustomEvent("stats", new Dictionary<string, object>
        {
            { "stars", currentStars },
            { "coins", currentCoins },
            { "lives", currentLives }
        });
        GameObject.FindObjectOfType<DiscordController>().OnClick();
        SoundSource.PlayOneShot(StarSound);
        StartCoroutine(coinStarExit());
    }


    public void AddCoin(int coins)
    {
        StartCoroutine(AddMultipleCoins(coins));
    }

    public void addRed(int coins) {
        StartCoroutine(AddRedCoins(coins));
		redPlay = 0;
    }

    public void FadeWhiteMatteOut(float time)
    {
        WhiteMatte.FadeOut(time);
    }



    public void FadeWhiteMatteIn(float time)
    {
        WhiteMatte.FadeIn(time);
    }

    public void Panic() {
        //Application.LoadLevel ("StartMenu");
		SceneManager.LoadScene("StartMenu");
    }

    IEnumerator TeleportToInside()
    {
        currentRed = 0;

        Time.timeScale = 1;

        if (enterCastle == false) {
            SoundSource.PlayOneShot(PauseSound);
        }

        BlackMatte.FadeOut(ExitFadeOutTime);

        yield return new WaitForSeconds(ExitFadeOutTime);

        SceneManager.LoadScene("InsideScene");
    }
    IEnumerator TeleportToOutside()
    {
        currentRed = 0;

        Time.timeScale = 1;

        if (exitCastle == false) {
            SoundSource.PlayOneShot(PauseSound);
        }

        BlackMatte.FadeOut(ExitFadeOutTime);

        yield return new WaitForSeconds(ExitFadeOutTime);

        SceneManager.LoadScene("Castle");
    }

    IEnumerator TeleportToWhomps()
    {
        currentRed = 0;

        Time.timeScale = 1;

        if (whompsEnter == false) {
            SoundSource.PlayOneShot(PauseSound);
        }
        ExitFadeOutTime = 1.0f;
        BlackMatte.FadeOut(ExitFadeOutTime);

        yield return new WaitForSeconds(ExitFadeOutTime);

        SceneManager.LoadScene("WhompsMenu");
    }

    IEnumerator TeleportToBobomb()
    {
        currentRed = 0;

        Time.timeScale = 1;

        if (bobOmbEnter == false)
        {
            SoundSource.PlayOneShot(PauseSound);
        }
        ExitFadeOutTime = 1.0f;
        BlackMatte.FadeOut(ExitFadeOutTime);

        yield return new WaitForSeconds(ExitFadeOutTime);

        SceneManager.LoadScene("BobombMenu");
    }

    IEnumerator ExitToMenu()
    {
        starAsk.SetActive(false);
		Player.SetActive (false);
        currentRed = 0;

        Time.timeScale = 1;

        if (bobOmbEnter == false) {
            SoundSource.PlayOneShot(PauseSound);
        }

        BlackMatte.FadeOut(ExitFadeOutTime);

        yield return new WaitForSeconds(ExitFadeOutTime);

        SceneManager.LoadScene("InsideScene");
    }

    IEnumerator waitForSoundToPlay()
    {
        yield return new WaitForSeconds(2.8f);
        MusicSource.clip = raceMusic;
        MusicSource.loop = true;
        MusicSource.Play();
    }

	IEnumerator waitForSoundToContinue()
	{
		yield return new WaitForSeconds(2.8f);
		SoundSource.clip = coinContinue;
		SoundSource.loop = true;
		SoundSource.volume = 0.3f;
		SoundSource.Play();
	}

    IEnumerator StarExit()
    {

        currentRed = 0;

        currentRing = 0;

		SoundSource.clip = coinContinue;
		SoundSource.volume = 1.0f;
		SoundSource.loop = false;
		SoundSource.Stop();

        GameObject.FindObjectOfType<MarioMachine>().stopMoving();
        GameObject.FindObjectOfType<MarioMachine>().starred = true;

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

        MusicSource.clip = raceMusic;
        MusicSource.loop = false;
        MusicSource.Stop();

        MarioIn.enabled = false;
        starAsk.SetActive(false);


        Time.timeScale = 1;

        SoundSource.PlayOneShot(StarSound);

        yield return new WaitForSeconds(StarAniTime);

        BlackMatte.FadeOut(ExitFadeOutTime);

        yield return new WaitForSeconds(ExitFadeOutTime);

        SceneManager.LoadScene("InsideScene");
    }

	IEnumerator CollectedStarExit()
	{

		currentRed = 0;

		currentRing = 0;

		SoundSource.clip = coinContinue;
		SoundSource.volume = 1.0f;
		SoundSource.loop = false;
		SoundSource.Stop();

		GameObject.FindObjectOfType<MarioMachine>().stopMoving();
		GameObject.FindObjectOfType<MarioMachine>().starred = true;

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

		MusicSource.clip = raceMusic;
		MusicSource.loop = false;
		MusicSource.Stop();

		MarioIn.enabled = false;
		starAsk.SetActive(false);


		Time.timeScale = 1;

		SoundSource.PlayOneShot(CollectedStarSound);

		yield return new WaitForSeconds(StarAniTime);

		BlackMatte.FadeOut(ExitFadeOutTime);

		yield return new WaitForSeconds(ExitFadeOutTime);

		SceneManager.LoadScene("InsideScene");
	}

    IEnumerator coinStarExit()
    {

        GameObject.FindObjectOfType<MarioMachine>().stopMoving();
        GameObject.FindObjectOfType<MarioMachine>().starred = true;
        MarioIn.enabled = false;

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

        MusicSource.clip = raceMusic;
        MusicSource.loop = false;
        MusicSource.Stop();


        Time.timeScale = 1;

        SoundSource.PlayOneShot(StarSound);

        yield return new WaitForSeconds(StarAniTime);

        starAsk.SetActive(true);
    }

    IEnumerator AddMultipleCoins(int coins)
    {
        int remainingCoins = coins;


        float delay = 0.02f;

        float i = 1.1f;

        while (remainingCoins > 0)
        {
            while (i < 1.0f)
            {
                i += Time.deltaTime / delay;

                yield return 0;
            }

            SoundSource.PlayOneShot(CoinSound);

            remainingCoins--;
            currentCoins = Mathf.Clamp(currentCoins + 1, 0, 999);

            coinTextHandler.UpdateValue(currentCoins);

            if (currentCoins == 50 | currentCoins == 100 | currentCoins == 150 | currentCoins == 200 | currentCoins == 250 | currentCoins == 300 | currentCoins == 350 | currentCoins == 400 | currentCoins == 450 | currentCoins == 500 | currentCoins == 550 | currentCoins == 600 | currentCoins == 650 | currentCoins == 700 | currentCoins == 750 | currentCoins == 800 | currentCoins == 850 | currentCoins == 900 | currentCoins == 950)
            {
                currentLives++;
            }

            if (currentCoins == GoldMarioCoinAmount)
            {
                GameObject.FindObjectOfType<MarioMachine>().GoldMarioUpgrade();
            }

            i = 0;
        }
    }

    IEnumerator AddRedCoins(int coins)
    {
        int remainingCoins = coins;


        float delay = 0.02f;

        float i = 1.1f;

        while (remainingCoins > 0)
        {
            while (i < 1.0f)
            {
                i += Time.deltaTime / delay;

                yield return 0;
            }
			if (redPlay <= 0) {
				SoundSource.PlayOneShot (RedSound);
				redPlay++;
			}

            remainingCoins--;
            currentCoins = Mathf.Clamp(currentCoins + 1, 0, 999);

            coinTextHandler.UpdateValue(currentCoins);

            if (currentCoins == GoldMarioCoinAmount)
            {
                GameObject.FindObjectOfType<MarioMachine>().GoldMarioUpgrade();
            }

            i = 0;
			//redPlay = 0;
        }
    }

    public void Save()
    {
        stats.Stars = currentStars;
		//stats.savedKeys = GameObject.FindObjectOfType<custom_inputs> ().inputKey;

//		for (int i = 0; i < starCollected.Length; i++)
//			stats.deadStars[i] = starCollected[i];

        jsonString = JsonUtility.ToJson(stats);

        if (File.Exists(path))
        {
            File.WriteAllText(path, jsonString);
        } else
        {
            File.Create(path);
            File.WriteAllText(path, jsonString);
        }

    }

    public void Load()
    {
        jsonString = File.ReadAllText(path);
        if(jsonString.Contains("{"))
        {
            stats = JsonUtility.FromJson<MyStats>(jsonString);
        } else
        {
            File.Delete(path);
        }
		//GameObject.FindObjectOfType<custom_inputs> ().inputKey = stats.savedKeys;
        
    }

	public void erase(){
		stats.Stars = 0;
		currentStars = 0;
		Save ();
	}
}

[Serializable]
public class MyStats {

    public int Stars;
    public int Lives;
	public int [] deadStars = new int[120];
	public KeyCode [] savedKeys = new KeyCode [12];

}
