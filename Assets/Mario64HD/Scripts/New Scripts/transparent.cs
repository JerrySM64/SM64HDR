using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Transparent : MonoBehaviour {

	private Text text;

	void Start ()
	{
		text = gameObject.GetComponent<Text>();
	}
		
	void Update()
	{
		text.color = new Color(text.color.r,text.color.g,text.color.b, Mathf.Sin(Time.time *2));
	}

}