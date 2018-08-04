// GUI Animator FREE
// Version: 1.1.5
// Compatilble: Unity 5.5.1 or higher, see more info in Readme.txt file.
//
// Developer:							Gold Experience Team (https://www.assetstore.unity3d.com/en/#!/search/page=1/sortby=popularity/query=publisher:4162)
//
// Unity Asset Store:					https://www.assetstore.unity3d.com/en/#!/content/58843
// See Full version:					https://www.assetstore.unity3d.com/en/#!/content/28709
//
// Please direct any bugs/comments/suggestions to geteamdev@gmail.com

#region Namespaces

using UnityEngine;
using System.Collections;

#endregion // Namespaces

// ######################################################################
// GA_FREE_OpenOtherScene class
// This class handles 8 buttons for changing scene.
// ######################################################################

public class GA_FREE_OpenOtherScene : MonoBehaviour
{
	
	// ########################################
	// MonoBehaviour Functions
	// ########################################
	
	#region MonoBehaviour
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
	void Start () {		
	}
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
	void Update () {		
	}
	
	#endregion // MonoBehaviour
	
	// ########################################
	// UI Responder functions
	// ########################################
	
	#region UI Responder
	
	// Open Demo Scene 1
	public void ButtonOpenDemoScene1 ()
	{
		// Disable all buttons
		GUIAnimSystemFREE.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
		GUIAnimSystemFREE.Instance.LoadLevel("GA FREE - Demo01 (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 2
	public void ButtonOpenDemoScene2 ()
	{
		// Disable all buttons
		GUIAnimSystemFREE.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
		GUIAnimSystemFREE.Instance.LoadLevel("GA FREE - Demo02 (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 3
	public void ButtonOpenDemoScene3 ()
	{
		// Disable all buttons
		GUIAnimSystemFREE.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
		GUIAnimSystemFREE.Instance.LoadLevel("GA FREE - Demo03 (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 4
	public void ButtonOpenDemoScene4 ()
	{
		// Disable all buttons
		GUIAnimSystemFREE.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
		GUIAnimSystemFREE.Instance.LoadLevel("GA FREE - Demo04 (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 5
	public void ButtonOpenDemoScene5 ()
	{
		// Disable all buttons
		GUIAnimSystemFREE.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
		GUIAnimSystemFREE.Instance.LoadLevel("GA FREE - Demo05 (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 6
	public void ButtonOpenDemoScene6 ()
	{
		// Disable all buttons
		GUIAnimSystemFREE.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
		GUIAnimSystemFREE.Instance.LoadLevel("GA FREE - Demo06 (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 7
	public void ButtonOpenDemoScene7 ()
	{
		// Disable all buttons
		GUIAnimSystemFREE.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
		GUIAnimSystemFREE.Instance.LoadLevel("GA FREE - Demo07 (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	// Open Demo Scene 8
	public void ButtonOpenDemoScene8 ()
	{
		// Disable all buttons
		GUIAnimSystemFREE.Instance.EnableAllButtons(false);

		// Waits 1.5 secs for Moving Out animation then load next level
		GUIAnimSystemFREE.Instance.LoadLevel("GA FREE - Demo08 (960x600px)", 1.5f);
		
		gameObject.SendMessage("HideAllGUIs");
	}
	
	#endregion // UI Responder
}
