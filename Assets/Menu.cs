using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void OnClick_Start(bool isPressed)
    {
        SceneManager.LoadScene("Castle", LoadSceneMode.Single);
    }

    public void OnClick_Options(bool isPressed)
    {
        SceneManager.LoadScene("Additive_OptionsMenu", LoadSceneMode.Additive);
    }

    public void OnClick_Credits(bool isPressed)
    {
        SceneManager.LoadScene("Additive_CreditsMenu", LoadSceneMode.Additive);
    }
}
