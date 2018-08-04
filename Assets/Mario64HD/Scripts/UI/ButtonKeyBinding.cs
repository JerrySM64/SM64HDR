using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonKeyBinding : MonoBehaviour {

    public int Index;

    private Button button;
    private Text text;

    void Awake()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<Text>();
    }

    public void DisableButton()
    {
        button.interactable = false;
    }

    public void EnableButton()
    {
        button.interactable = true;
    }

    public void EnableButton(string newText)
    {
        text.text = newText;
        EnableButton();
    }
}
