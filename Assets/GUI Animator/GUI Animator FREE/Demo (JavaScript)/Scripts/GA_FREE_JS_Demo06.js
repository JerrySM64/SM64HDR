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

// ######################################################################
// GA_FREE_Demo06 class
// - Animates all GUIAnimFREE elements in the scene.
// - Responds to user mouse click or tap on buttons.
//
// Note this class is attached with "-SceneController-" object in "GA FREE JS - Demo06 (960x600px)" scene.
// ######################################################################

class GA_FREE_JS_Demo06 extends MonoBehaviour {

	// ########################################
	// Variables
	// ########################################

    // Canvas
    var m_Canvas : Canvas;
	
   // GUIAnim objects of title text
    var m_Title1 : GUIAnimFREE;
    var m_Title2 : GUIAnimFREE;
	
   // GUIAnim objects of top and bottom bars
    var m_TopBar : GUIAnimFREE;
    var m_BottomBar : GUIAnimFREE;
	
   // GUIAnim objects of primary buttons
    var m_PrimaryButton1 : GUIAnimFREE;
    var m_PrimaryButton2 : GUIAnimFREE;
    var m_PrimaryButton3 : GUIAnimFREE;
    var m_PrimaryButton4 : GUIAnimFREE;
    var m_PrimaryButton5 : GUIAnimFREE;

   // GUIAnim objects of secondary buttons
    var m_SecondaryButton1 : GUIAnimFREE;
    var m_SecondaryButton2 : GUIAnimFREE;
    var m_SecondaryButton3 : GUIAnimFREE;
    var m_SecondaryButton4 : GUIAnimFREE;
    var m_SecondaryButton5 : GUIAnimFREE;
	
   // Toggle state of buttons
    protected var m_Button1_IsOn : boolean= false;
    protected var m_Button2_IsOn : boolean= false;
    protected var m_Button3_IsOn : boolean= false;
    protected var m_Button4_IsOn : boolean= false;
    protected var m_Button5_IsOn : boolean= false;
	
	// ########################################
	// MonoBehaviour Functions
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.html
	// ########################################
	
	// Awake is called when the script instance is being loaded.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html
   function Awake () {
       if(enabled)
       {
           // Set GUIAnimSystemFREE.Instance.m_AutoAnimation to false in Awake() will let you control all GUI Animator elements in the scene via scripts.
			GUIAnimSystemFREE.Instance.m_AutoAnimation = false;
       }
   }
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
        function Start () {
            // MoveIn m_TopBar and m_BottomBar
            m_TopBar.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
            m_BottomBar.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
            // MoveIn m_Title1 m_Title2
            StartCoroutine(MoveInTitleGameObjects());
		
            // Disable all scene switch buttons
		// http://docs.unity3d.com/Manual/script-GraphicRaycaster.html
            GUIAnimSystemFREE.Instance.SetGraphicRaycasterEnable(m_Canvas, false);
        }
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
        function Update () {
		
        }

	// ########################################
	// MoveIn/MoveOut functions
	// ########################################
	
        // Move In m_Title1 and m_Title2
        function MoveInTitleGameObjects () : IEnumerator {
            yield  WaitForSeconds(1.0f);
		
            // Move In m_Title1 and m_Title2
            m_Title1.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);
            m_Title2.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);
		
            // MoveIn dialogs
            StartCoroutine(MoveInPrimaryButtons());
		
            // Enable all scene switch buttons
		// http://docs.unity3d.com/Manual/script-GraphicRaycaster.html
            GUIAnimSystemFREE.Instance.SetGraphicRaycasterEnable(m_Canvas, true);
        }
	
            // MoveIn all primary buttons
            function MoveInPrimaryButtons () : IEnumerator {
                yield  WaitForSeconds(1.0f);
		
                // MoveIn all primary buttons
                m_PrimaryButton1.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);	
                m_PrimaryButton2.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);	
                m_PrimaryButton3.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);	
                m_PrimaryButton4.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);

                m_PrimaryButton5.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);
		
                // Enable all scene switch buttons
                StartCoroutine(EnableAllDemoButtons());
            }
	
                // MoveOut all primary buttons
                function HideAllGUIs () {
                    // MoveOut all primary buttons
                    m_PrimaryButton1.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    m_PrimaryButton2.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    m_PrimaryButton3.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    m_PrimaryButton4.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    m_PrimaryButton5.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                    // MoveOut all secondary buttons
                    if(m_Button1_IsOn == true)
                        m_SecondaryButton1.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    if(m_Button2_IsOn == true)
                        m_SecondaryButton2.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    if(m_Button3_IsOn == true)
                        m_SecondaryButton3.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    if(m_Button4_IsOn == true)
                        m_SecondaryButton4.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    if(m_Button5_IsOn == true)
                        m_SecondaryButton5.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                    // MoveOut m_Title1 and m_Title2
                    StartCoroutine(HideTitleTextMeshes());
                }
	
                // MoveOut m_Title1 and m_Title2
                function HideTitleTextMeshes () : IEnumerator {
                    yield  WaitForSeconds(1.0f);
		
                    // MoveOut m_Title1 and m_Title2
                    m_Title1.MoveOut(GUIAnimSystemFREE.eGUIMove.Self);
                    m_Title2.MoveOut(GUIAnimSystemFREE.eGUIMove.Self);
		
                    // MoveOut m_TopBar and m_BottomBar
                    m_TopBar.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    m_BottomBar.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                }
	
	// ########################################
	// Enable/Disable button functions
	// ########################################
	
                    // Enable/Disable all scene switch Coroutine
                    function EnableAllDemoButtons () : IEnumerator {
                        yield  WaitForSeconds(1.0f);
		
                        // Enable all scene switch buttons
		// http://docs.unity3d.com/Manual/script-GraphicRaycaster.html
                        GUIAnimSystemFREE.Instance.SetGraphicRaycasterEnable(m_Canvas, true);
                    }

                        // Disable all buttons for a few seconds
                        function DisableAllButtonsForSeconds ( DisableTime : float  ) : IEnumerator {
                            // Disable all buttons
                            GUIAnimSystemFREE.Instance.EnableAllButtons(false);
		
                            yield  WaitForSeconds(DisableTime);
		
                            // Enable all buttons
                            GUIAnimSystemFREE.Instance.EnableAllButtons(true);
                        }
	
	// ########################################
	// UI Responder functions
	// ########################################
	
                            function OnButton_1 () {
                                // Disable all buttons for a few seconds
                                StartCoroutine(DisableAllButtonsForSeconds(0.6f));

                                // Toggle m_Button1
                                ToggleButton_1();
		
                                // Toggle other buttons
                                if(m_Button2_IsOn==true)
                                {
                                    ToggleButton_2();
                                }
                                if(m_Button3_IsOn==true)
                                {
                                    ToggleButton_3();
                                }
                                if(m_Button4_IsOn==true)
                                {
                                    ToggleButton_4();
                                }
                                if(m_Button5_IsOn==true)
                                {
                                    ToggleButton_5();
                                }
                            }
	
                            function OnButton_2 () {
                                // Disable all buttons for a few seconds
                                StartCoroutine(DisableAllButtonsForSeconds(0.6f));

                                // Toggle m_Button2
                                ToggleButton_2();
		
                                // Toggle other buttons
                                if(m_Button1_IsOn==true)
                                {
                                    ToggleButton_1();
                                }
                                if(m_Button3_IsOn==true)
                                {
                                    ToggleButton_3();
                                }
                                if(m_Button4_IsOn==true)
                                {
                                    ToggleButton_4();
                                }
                                if(m_Button5_IsOn==true)
                                {
                                    ToggleButton_5();
                                }
                            }
	
                            function OnButton_3 () {
                                // Disable all buttons for a few seconds
                                StartCoroutine(DisableAllButtonsForSeconds(0.6f));

                                // Toggle m_Button3
                                ToggleButton_3();
		
                                // Toggle other buttons
                                if(m_Button1_IsOn==true)
                                {
                                    ToggleButton_1();
                                }
                                if(m_Button2_IsOn==true)
                                {
                                    ToggleButton_2();
                                }
                                if(m_Button4_IsOn==true)
                                {
                                    ToggleButton_4();
                                }
                                if(m_Button5_IsOn==true)
                                {
                                    ToggleButton_5();
                                }
                            }
	
                            function OnButton_4 () {
                                // Disable all buttons for a few seconds
                                StartCoroutine(DisableAllButtonsForSeconds(0.6f));

                                // Toggle m_Button4
                                ToggleButton_4();
		
                                // Toggle other buttons
                                if(m_Button1_IsOn==true)
                                {
                                    ToggleButton_1();
                                }
                                if(m_Button2_IsOn==true)
                                {
                                    ToggleButton_2();
                                }
                                if(m_Button3_IsOn==true)
                                {
                                    ToggleButton_3();
                                }
                                if(m_Button5_IsOn==true)
                                {
                                    ToggleButton_5();
                                }
                            }
	
                            function OnButton_5 () {
                                // Disable all buttons for a few seconds
                                StartCoroutine(DisableAllButtonsForSeconds(0.6f));

                                // Toggle m_Button5
                                ToggleButton_5();
		
                                // Toggle other buttons
                                if(m_Button1_IsOn==true)
                                {
                                    ToggleButton_1();
                                }
                                if(m_Button2_IsOn==true)
                                {
                                    ToggleButton_2();
                                }
                                if(m_Button3_IsOn==true)
                                {
                                    ToggleButton_3();
                                }
                                if(m_Button4_IsOn==true)
                                {
                                    ToggleButton_4();
                                }
                            }
	
	// ########################################
	// Toggle button functions
	// ########################################
	
                            // Toggle m_Button1
                            function ToggleButton_1 () {
                                m_Button1_IsOn = !m_Button1_IsOn;
                                if(m_Button1_IsOn==true)
                                {
                                    // MoveIn m_SecondaryButton1
                                    m_SecondaryButton1.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                }
                                else
                                {
                                    // MoveOut m_SecondaryButton1
                                    m_SecondaryButton1.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                }
                            }
	
                            // Toggle m_Button2
                            function ToggleButton_2 () {
                                m_Button2_IsOn = !m_Button2_IsOn;
                                if(m_Button2_IsOn==true)
                                {
                                    // MoveIn m_SecondaryButton2
                                    m_SecondaryButton2.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                }
                                else
                                {
                                    // MoveOut m_SecondaryButton2
                                    m_SecondaryButton2.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                }
                            }
	
                            // Toggle m_Button3
                            function ToggleButton_3 () {
                                m_Button3_IsOn = !m_Button3_IsOn;
                                if(m_Button3_IsOn==true)
                                {
                                    // MoveIn m_SecondaryButton3
                                    m_SecondaryButton3.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                }
                                else
                                {
                                    // MoveOut m_SecondaryButton3
                                    m_SecondaryButton3.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                }
                            }
	
                            // Toggle m_Button4
                            function ToggleButton_4 () {
                                m_Button4_IsOn = !m_Button4_IsOn;
                                if(m_Button4_IsOn==true)
                                {
                                    // MoveIn m_SecondaryButton4
                                    m_SecondaryButton4.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                }
                                else
                                {
                                    // MoveOut m_SecondaryButton4
                                    m_SecondaryButton4.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                }
                            }
	
                            // Toggle m_Button5
                            function ToggleButton_5 () {
                                m_Button5_IsOn = !m_Button5_IsOn;
                                if(m_Button5_IsOn==true)
                                {
                                    // MoveIn m_SecondaryButton5
                                    m_SecondaryButton5.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                }
                                else
                                {
                                    // MoveOut m_SecondaryButton5
                                    m_SecondaryButton5.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                }
                            }
                        }
