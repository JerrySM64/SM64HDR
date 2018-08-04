using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesTextHandler : MonoBehaviour {

    public ImageToNumber LivesFirst;
    public ImageToNumber LivesSecond;
    public ImageToNumber LivesThird;

    // Live Counter
    public void UpdateValue(int value)
    {
        value = Mathf.Clamp(value, 0, 100);

        var stringValue = value.ToString();

        if (stringValue.Length == 1)
        {
            LivesFirst.GetComponent<Image>().enabled = true;

            LivesFirst.SetValue((int)Char.GetNumericValue(stringValue[0]));

            LivesSecond.GetComponent<Image>().enabled = false;
            LivesThird.GetComponent<Image>().enabled = false;
        }
        else if (stringValue.Length == 2)
        {
            LivesFirst.GetComponent<Image>().enabled = true;
            LivesSecond.GetComponent<Image>().enabled = true;

            LivesFirst.SetValue((int)Char.GetNumericValue(stringValue[0]));
            LivesSecond.SetValue((int)Char.GetNumericValue(stringValue[1]));

            LivesThird.GetComponent<Image>().enabled = false;
        }
        else
        {
            LivesFirst.GetComponent<Image>().enabled = true;
            LivesSecond.GetComponent<Image>().enabled = true;
            LivesThird.GetComponent<Image>().enabled = true;

            LivesFirst.SetValue((int)Char.GetNumericValue(stringValue[0]));
            LivesSecond.SetValue((int)Char.GetNumericValue(stringValue[1]));
            LivesThird.SetValue((int)Char.GetNumericValue(stringValue[2]));
        }
    }
}
