using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class StarTextHandler : MonoBehaviour {

    public ImageToNumber StarFirst;
    public ImageToNumber StarSecond;
    public ImageToNumber StarThird;

    // Star Counter
    public void UpdateValue(int value)
    {
        value = Mathf.Clamp(value, 0, 120);

        var stringValue = value.ToString();

        if (stringValue.Length == 1)
        {
            StarFirst.GetComponent<Image>().enabled = true;

			StarFirst.SetValue((int)Char.GetNumericValue(stringValue[0]));

			StarSecond.GetComponent<Image>().enabled = false;
			StarThird.GetComponent<Image>().enabled = false;
        }
        else if (stringValue.Length == 2)
        {
			StarFirst.GetComponent<Image>().enabled = true;
			StarSecond.GetComponent<Image>().enabled = true;

			StarFirst.SetValue((int)Char.GetNumericValue(stringValue[0]));
			StarSecond.SetValue((int)Char.GetNumericValue(stringValue[1]));

			StarThird.GetComponent<Image>().enabled = false;
        }
        else
        {
			StarFirst.GetComponent<Image>().enabled = true;
			StarSecond.GetComponent<Image>().enabled = true;
			StarThird.GetComponent<Image>().enabled = true;

			StarFirst.SetValue((int)Char.GetNumericValue(stringValue[0]));
			StarSecond.SetValue((int)Char.GetNumericValue(stringValue[1]));
            StarThird.SetValue((int)Char.GetNumericValue(stringValue[2]));
        }
    }
}
