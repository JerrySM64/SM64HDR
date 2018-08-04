using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public GameObject MainInput;
    public GameObject AuxInput;
    public GameObject ControllerPreset;
    public GameObject BackButton;
    public GameObject CloseButton;

    public GameObject[] newButtons;

    public Image[] redCoins;
	
    public void TurnOn()
    {
        for (int i = 0; i < newButtons.Length; i++)
        {
            newButtons[i].SetActive(true);
        }

        MainInput.SetActive(false);
        AuxInput.SetActive(false);
        ControllerPreset.SetActive(false);
        BackButton.SetActive(false);
        CloseButton.SetActive(true);
    }

    public void TurnOff()
    {
        for (int i = 0; i < newButtons.Length; i++)
        {
            newButtons[i].SetActive(false);
        }

        MainInput.SetActive(true);
        AuxInput.SetActive(true);
        ControllerPreset.SetActive(true);
        BackButton.SetActive(true);
        CloseButton.SetActive(false);
    }

    public void Update()
    {
        for (int i = 0; i < GameObject.FindObjectOfType<GameMaster>().currentRed; i++)
        {
            redCoins[i].gameObject.SetActive(true);
        }
    }
}
