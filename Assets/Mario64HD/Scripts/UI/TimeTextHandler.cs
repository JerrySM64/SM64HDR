using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TimeTextHandler : MonoBehaviour {

	public ImageToNumber TimeSecOne;
	public ImageToNumber TimeSecTwo;
	public ImageToNumber TimeMin;

	public int looped = 0;

	// Dear god this is an ugly way to do this c'mon Erik you gotta be less lazy
	public void UpdateValue(float value)
	{
		value = Mathf.Clamp(value, 0, 999);

		var stringValue = value.ToString();

		if (stringValue.Length == 1)
		{
			TimeSecOne.SetValue((int)Char.GetNumericValue(stringValue[0]));

			TimeSecTwo.SetValue (0);
		}
		else if (stringValue == "60")
		{
			TimeMin.SetValue (looped + 1);
			GameObject.FindObjectOfType<SuperKoopaController> ().startTimer = Time.time;
			looped = looped + 1;
		}
		else if (stringValue.Length == 2)
		{
			TimeSecOne.SetValue((int)Char.GetNumericValue(stringValue[1]));
			TimeSecTwo.SetValue((int)Char.GetNumericValue(stringValue[0]));
		}
	}
}
