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
// GE_OrbitCamera class
// Handles mouse and touch inputs for orbiting the camera around the target object.
// ######################################################################

public class GE_OrbitCameraUI : MonoBehaviour
{

	// ########################################
	// Variables
	// ########################################

	#region Variables

	// Unity UI elements
	Toggle m_ToggleYaw = null;
	Toggle m_TogglePitch = null;
	Toggle m_ToggleZoom = null;
	Toggle m_ToggleHelp = null;
	Toggle m_ToggleDetails = null;
	Button m_PinchZoom = null;
	Button m_VScrollZoom = null;

	GUIAnimFREE m_PanelSettings = null;
	GUIAnimFREE m_ButtonSettings = null;

	GUIAnimFREE m_PanelHelp1 = null;
	GUIAnimFREE m_PanelHelp2 = null;
	GUIAnimFREE m_PanelDetails = null;

	GE_OrbitCamera m_GE_OrbitCamera = null;

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

		// Set GUIAnimSystemFREE.Instance.m_AutoAnimation to false, 
		// this will let you control all GUI Animator elements in the scene via scripts.
		if (enabled)
		{
			GUIAnimSystemFREE.Instance.m_GUISpeed = 1.0f;
			GUIAnimSystemFREE.Instance.m_AutoAnimation = false;
		}

		m_GE_OrbitCamera = GameObject.FindObjectOfType<GE_OrbitCamera>();

		// Find Unity UI elements
		GameObject go = GameObject.Find("Toggle Invert X");
		if (go != null)
			m_ToggleYaw = go.GetComponent<Toggle>();
		go = GameObject.Find("Toggle Invert Y");
		if (go != null)
			m_TogglePitch = go.GetComponent<Toggle>();
		go = GameObject.Find("Toggle Invert Zoom");
		if (go != null)
			m_ToggleZoom = go.GetComponent<Toggle>();
		go = GameObject.Find("Toggle Help");
		if (go != null)
			m_ToggleHelp = go.GetComponent<Toggle>();
		go = GameObject.Find("Toggle Details");
		if (go != null)
			m_ToggleDetails = go.GetComponent<Toggle>();
		go = GameObject.Find("Button Pinch Zoom");
		if (go != null)
			m_PinchZoom = go.GetComponent<Button>();
		go = GameObject.Find("Button V-Scroll Zoom");
		if (go != null)
			m_VScrollZoom = go.GetComponent<Button>();
		go = GameObject.Find("Panel Settings");
		if (go != null)
			m_PanelSettings = go.GetComponent<GUIAnimFREE>();
		go = GameObject.Find("Button Settings");
		if (go != null)
			m_ButtonSettings = go.GetComponent<GUIAnimFREE>();
		if (m_ButtonSettings != null)
		{
			m_ButtonSettings.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);
		}

		go = GameObject.Find("Panel Help1");
		if (go != null)
			m_PanelHelp1 = go.GetComponent<GUIAnimFREE>();
		go = GameObject.Find("Panel Help2");
		if (go != null)
			m_PanelHelp2 = go.GetComponent<GUIAnimFREE>();
		go = GameObject.Find("Panel Details");
		if (go != null)
			m_PanelDetails = go.GetComponent<GUIAnimFREE>();
		if (m_ToggleHelp != null)
		{
			if (m_ToggleHelp.isOn == true)
			{
				if (m_PanelHelp1 != null)
				{
					m_PanelHelp1.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);
				}
				if (m_PanelHelp2 != null)
				{
					m_PanelHelp2.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);
				}
			}
		}
		if (m_ToggleDetails != null && m_PanelDetails != null)
		{
			if (m_ToggleDetails.isOn == true)
			{
				if (m_PanelDetails != null)
				{
					m_PanelDetails.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);
				}
			}
		}

		// Setup some Unity UI elements
		if (m_GE_OrbitCamera != null)
		{
			if (m_ToggleYaw != null)
				m_ToggleYaw.isOn = m_GE_OrbitCamera.m_XInvert;
			if (m_TogglePitch != null)
				m_TogglePitch.isOn = m_GE_OrbitCamera.m_YInvert;
			if (m_ToggleZoom != null)
				m_ToggleZoom.isOn = m_GE_OrbitCamera.m_ZoomInvert;
		}
		if (m_ToggleHelp != null)
			m_ToggleHelp.isOn = true;
		if (m_ToggleDetails != null)
			m_ToggleDetails.isOn = true;
		if (m_PinchZoom != null)
			m_PinchZoom.interactable = false;
		if (m_VScrollZoom != null)
			m_VScrollZoom.interactable = true;

	}

	// Update is called every frame, if the MonoBehaviour is enabled.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
	void Update()
	{
	}

	#endregion // MonoBehaviour

	// ########################################
	// UI Responder functions
	// ########################################

	#region UI Responder

	// Toggle Invert X axis
	public void OnToggle_InvertX()
	{
		if (m_ToggleYaw != null && m_GE_OrbitCamera != null)
		{
			m_GE_OrbitCamera.m_XInvert = m_ToggleYaw.isOn;
		}
	}

	// Toggle Invert Y axis
	public void OnToggle_InvertY()
	{
		if (m_TogglePitch != null && m_GE_OrbitCamera != null)
		{
			m_GE_OrbitCamera.m_YInvert = m_TogglePitch.isOn;
		}
	}

	// Toggle Invert Zoom
	public void OnToggle_InvertZoom()
	{
		if (m_ToggleZoom != null && m_GE_OrbitCamera != null)
		{
			m_GE_OrbitCamera.m_ZoomInvert = m_ToggleZoom.isOn;
		}
	}

	// Toggle show/hide Help panel
	public void OnToggle_Help()
	{
		if (m_ToggleHelp != null)
		{
			if (m_ToggleHelp.isOn == true)
			{
				if (m_PanelHelp1 != null)
				{
					m_PanelHelp1.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);
				}
				if (m_PanelHelp2 != null)
				{
					m_PanelHelp2.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);
				}
			}
			else
			{
				if (m_PanelHelp1 != null)
				{
					m_PanelHelp1.MoveOut(GUIAnimSystemFREE.eGUIMove.Self);
				}
				if (m_PanelHelp2 != null)
				{
					m_PanelHelp2.MoveOut(GUIAnimSystemFREE.eGUIMove.Self);
				}
			}
		}
	}

	// Toggle show/hide Details panel
	public void OnToggle_Details()
	{
		if (m_ToggleDetails != null && m_PanelDetails != null)
		{
			if (m_ToggleDetails.isOn == true)
			{
				m_PanelDetails.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);
			}
			else
			{
				m_PanelDetails.MoveOut(GUIAnimSystemFREE.eGUIMove.Self);
			}
		}
	}

	// Use pinch to zoom
	public void OnButton_PinchZoom()
	{
		if (m_PinchZoom != null)
		{
			m_PinchZoom.interactable = !m_PinchZoom.interactable;
		}
		if (m_VScrollZoom != null)
		{
			m_VScrollZoom.interactable = !m_VScrollZoom.interactable;
		}
	}

	// Use Two fingers verticle-scroll to zoom
	public void OnButton_VScrollZoom()
	{
		if (m_PinchZoom != null)
		{
			m_PinchZoom.interactable = !m_PinchZoom.interactable;
		}
		if (m_VScrollZoom != null)
		{
			m_VScrollZoom.interactable = !m_VScrollZoom.interactable;
		}
	}

	// User clicks on Settings button
	public void OnButton_Settings()
	{
		if (m_PanelSettings != null)
		{
			// Toggle show/hide m_PanelSettings
			if (m_PanelSettings.transform.localScale == new Vector3(0, 0, 0))
			{
				m_PanelSettings.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);
			}
			else
			{
				m_PanelSettings.MoveOut(GUIAnimSystemFREE.eGUIMove.Self);
			}
		}
	}

	#endregion // UI Responder
}
