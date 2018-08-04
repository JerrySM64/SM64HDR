using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightScript : MonoBehaviour {

    Text text;
    
	void Start () {
        onToggled();
	}

    void onToggled ()
    {
        text = GetComponent<Text>();
        text.text = "Hello!";
    }


}
