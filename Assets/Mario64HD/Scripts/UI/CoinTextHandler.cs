using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class CoinTextHandler : MonoBehaviour {

    public ImageToNumber CoinFirst;
    public ImageToNumber CoinSecond;
    public ImageToNumber CoinThird;

    // Dear god this is an ugly way to do this c'mon Erik you gotta be less lazy
    public void UpdateValue(int value)
    {
        value = Mathf.Clamp(value, 0, 999);

        var stringValue = value.ToString();

        if (stringValue.Length == 1)
        {
            CoinFirst.GetComponent<Image>().enabled = true;

            CoinFirst.SetValue((int)Char.GetNumericValue(stringValue[0]));

            CoinSecond.GetComponent<Image>().enabled = false;
            CoinThird.GetComponent<Image>().enabled = false;
        }
        else if (stringValue.Length == 2)
        {
            CoinFirst.GetComponent<Image>().enabled = true;
            CoinSecond.GetComponent<Image>().enabled = true;

            CoinFirst.SetValue((int)Char.GetNumericValue(stringValue[0]));
            CoinSecond.SetValue((int)Char.GetNumericValue(stringValue[1]));

            CoinThird.GetComponent<Image>().enabled = false;
        }
        else
        {
            CoinFirst.GetComponent<Image>().enabled = true;
            CoinSecond.GetComponent<Image>().enabled = true;
            CoinThird.GetComponent<Image>().enabled = true;

            CoinFirst.SetValue((int)Char.GetNumericValue(stringValue[0]));
            CoinSecond.SetValue((int)Char.GetNumericValue(stringValue[1]));
            CoinThird.SetValue((int)Char.GetNumericValue(stringValue[2]));
        }
    }
}
