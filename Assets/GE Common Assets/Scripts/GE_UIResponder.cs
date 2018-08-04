// GE Common Assets 1.0
// Free asssets for using in many packages of Gold Experience Team.
//
// Developer:			Gold Experience Team (https://www.assetstore.unity3d.com/en/#!/search/page=1/sortby=popularity/query=publisher:4162)

// Support:	geteamdev@gmail.com
//
// Please direct any bugs/comments/suggestions to geteamdev@gmail.com.

#region Namespaces

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

#endregion // Namespaces

// ######################################################################
// GE_UIResponder class
// Changes Title name and open webpage when user clicks on title name.
// ######################################################################

public class GE_UIResponder : MonoBehaviour
{

	// ########################################
	// Variables
	// ########################################

	#region Variables

	public string m_PackageTitle = "-";
	public string m_TargetURL = "www.unity3d.com";

	#endregion // Variables

	// ########################################
	// MonoBehaviour Functions
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.html
	// ########################################

	#region MonoBehaviour

	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
	void Start()
	{

		GameObject go = GameObject.Find("Text Package Title");
		if (go != null)
		{
			Text m_PackageText = go.GetComponent<Text>();
			m_PackageText.text = m_PackageTitle;
		}
	}

	// Update is called every frame, if the MonoBehaviour is enabled.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
	void Update()
	{
	}

	#endregion // MonoBehaviour

	// ########################################
	// UI Responder Functions
	// ########################################

	#region UI Responder

	// User click/touch on title name
	public void OnButton_AssetName()
	{
		// http://docs.unity3d.com/ScriptReference/Application.OpenURL.html
		Application.OpenURL(m_TargetURL);
	}

	#endregion // UI Responder
}
