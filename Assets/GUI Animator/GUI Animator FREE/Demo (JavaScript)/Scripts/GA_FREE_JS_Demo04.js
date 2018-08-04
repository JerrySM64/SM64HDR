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
// GA_FREE_Demo04 class
// - Animates all GUIAnimFREE elements in the scene.
// - Responds to user mouse click or tap on buttons.
//
// Note this class is attached with "-SceneController-" object in "GA FREE JS - Demo04 (960x600px)" scene.
// ######################################################################

class GA_FREE_JS_Demo04 extends MonoBehaviour {

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
	
   // GUIAnim object of dialogs
    var m_Dialog1 : GUIAnimFREE;
    var m_Dialog2 : GUIAnimFREE;
    var m_Dialog3 : GUIAnimFREE;
    var m_Dialog4 : GUIAnimFREE;
	
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
        }
	
            // MoveIn dialogs
            function MoveInPrimaryButtons () : IEnumerator {
                yield  WaitForSeconds(1.0f);
		
                // MoveIn dialogs
                m_Dialog1.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);		
                m_Dialog2.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);		
                m_Dialog3.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);		
                m_Dialog4.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                // Enable all scene switch buttons
                StartCoroutine(EnableAllDemoButtons());
            }
	
                function HideAllGUIs () {
                    // MoveOut dialogs
                    m_Dialog1.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    m_Dialog2.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    m_Dialog3.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    m_Dialog4.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
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
                        GUIAnimSystemFREE.Instance.SetGraphicRaycasterEnable(m_Canvas, true);
                    }

                        // Disable a button for a few seconds
                        function DisableButtonForSeconds ( GO : GameObject ,   DisableTime : float  ) : IEnumerator {
                            // Disable all buttons
                            GUIAnimSystemFREE.Instance.EnableButton(GO.transform, false);
		
                            yield  WaitForSeconds(DisableTime);
		
                            // Enable all buttons
                            GUIAnimSystemFREE.Instance.EnableButton(GO.transform, true);
                        }
	
	// ########################################
	// UI Responder functions
	// ########################################
	
                            function OnButton_Dialog1 () {
                                // MoveOut m_Dialog1
                                m_Dialog1.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                                // Disable m_Dialog1 for a few seconds
                                StartCoroutine(DisableButtonForSeconds(m_Dialog1.gameObject, 2.0f));
		
                                // Moves m_Dialog1 back to screen
                                StartCoroutine(Dialog1_MoveIn());
                            }
	
                            function OnButton_Dialog2 () {
                                // MoveOut m_Dialog2
                                m_Dialog2.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                                // Disable m_Dialog2 for a few seconds
                                StartCoroutine(DisableButtonForSeconds(m_Dialog2.gameObject, 2.0f));
		
                                // Moves m_Dialog2 back to screen
                                StartCoroutine(Dialog2_MoveIn());
                            }
	
                            function OnButton_Dialog3 () {
                                // MoveOut m_Dialog3
                                m_Dialog3.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                                // Disable m_Dialog3 for a few seconds
                                StartCoroutine(DisableButtonForSeconds(m_Dialog3.gameObject, 2.0f));
		
                                // Moves m_Dialog3 back to screen
                                StartCoroutine(Dialog3_MoveIn());
                            }
	
                            function OnButton_Dialog4 () {
                                // MoveOut m_Dialog4
                                m_Dialog4.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                                // Disable m_Dialog4 for a few seconds
                                StartCoroutine(DisableButtonForSeconds(m_Dialog4.gameObject, 2.0f));
		
                                // Moves m_Dialog4 back to screen
                                StartCoroutine(Dialog4_MoveIn());
                            }
	
                            function OnButton_MoveOutAllDialogs () {
		
                                // Disable m_Dialog1, m_Dialog2, m_Dialog3, m_Dialog4 for a few seconds
                                StartCoroutine(DisableButtonForSeconds(m_Dialog1.gameObject, 2.0f));
                                StartCoroutine(DisableButtonForSeconds(m_Dialog2.gameObject, 2.0f));
                                StartCoroutine(DisableButtonForSeconds(m_Dialog3.gameObject, 2.0f));
                                StartCoroutine(DisableButtonForSeconds(m_Dialog4.gameObject, 2.0f));

                                if(m_Dialog1.m_MoveOut.Began==false && m_Dialog1.m_MoveOut.Done==false)
                                {
                                    // Move m_Dialog1 out
                                    m_Dialog1.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                    // Move m_Dialog1 back to screen with Coroutines
                                    StartCoroutine(Dialog1_MoveIn());
                                }
                                if(m_Dialog2.m_MoveOut.Began==false && m_Dialog2.m_MoveOut.Done==false)
                                {
                                    // Move m_Dialog2 out
                                    m_Dialog2.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                    // Move m_Dialog2 back to screen with Coroutines
                                    StartCoroutine(Dialog2_MoveIn());
                                }
                                if(m_Dialog3.m_MoveOut.Began==false && m_Dialog3.m_MoveOut.Done==false)
                                {
                                    // Move m_Dialog3 out
                                    m_Dialog3.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                    // Move m_Dialog3 back to screen with Coroutines
                                    StartCoroutine(Dialog3_MoveIn());
                                }
                                if(m_Dialog4.m_MoveOut.Began==false && m_Dialog4.m_MoveOut.Done==false)
                                {
                                    // Move m_Dialog4 out
                                    m_Dialog4.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                    // Move m_Dialog4 back to screen with Coroutines
                                    StartCoroutine(Dialog4_MoveIn());
                                }
                            }
	
	// ########################################
	// Move dialog functions
	// ########################################
	
                            // MoveIn m_Dialog1
                            function Dialog1_MoveIn () : IEnumerator {
                                yield  WaitForSeconds(1.5f);
		
                                // Reset children of m_Dialog1
                                m_Dialog1.ResetAllChildren();
		
                                // Moves m_Dialog1 back to screen
                                m_Dialog1.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                            }
	
                                // MoveIn m_Dialog2
                                function Dialog2_MoveIn () : IEnumerator {
                                    yield  WaitForSeconds(1.5f);
		
                                    // Reset children of m_Dialog2
                                    m_Dialog2.ResetAllChildren();
		
                                    // Moves m_Dialog1 back to screen
                                    m_Dialog2.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                }
	
                                    // MoveIn m_Dialog3
                                    function Dialog3_MoveIn () : IEnumerator {
                                        yield  WaitForSeconds(1.5f);
		
                                        // Reset children of m_Dialog3
                                        m_Dialog3.ResetAllChildren();
		
                                        // Moves m_Dialog1 back to screen
                                        m_Dialog3.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                    }
	
                                        // MoveIn m_Dialog4
                                        function Dialog4_MoveIn () : IEnumerator {
                                            yield  WaitForSeconds(1.5f);
		
                                            // Reset children of m_Dialog4
                                            m_Dialog4.ResetAllChildren();
		
                                            // Moves m_Dialog1 back to screen to screen
                                            m_Dialog4.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                        }
                                        }
