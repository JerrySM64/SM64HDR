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
// GA_FREE_Demo01 class
// - Animates all GUIAnimFREE elements in the scene.
// - Responds to user mouse click or tap on buttons.
//
// Note this class is attached with "-SceneController-" object in "GA FREE JS - Demo01 (960x600px)" scene.
// ######################################################################

class GA_FREE_JS_Demo01 extends MonoBehaviour {

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
	
   // GUIAnim objects of TopLeft buttons
    var m_TopLeft_A : GUIAnimFREE;
    var m_TopLeft_B : GUIAnimFREE;
	
   // GUIAnim objects of BottomLeft buttons
    var m_BottomLeft_A : GUIAnimFREE;
    var m_BottomLeft_B : GUIAnimFREE;
	
   // GUIAnim objects of RightBar buttons
    var m_RightBar_A : GUIAnimFREE;
    var m_RightBar_B : GUIAnimFREE;
    var m_RightBar_C : GUIAnimFREE;

   // Toggle state of TopLeft, BottomLeft and BottomLeft buttons
    protected var m_TopLeft_IsOn : boolean= false;
    protected var m_BottomLeft_IsOn : boolean= false;
    protected var m_RightBar_IsOn : boolean= false;

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

            // MoveIn m_Title1 and m_Title2
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
	
        // MoveIn m_Title1 and m_Title2
        function MoveInTitleGameObjects () : IEnumerator {
            yield WaitForSeconds(1.0f);

            // MoveIn m_Title1 and m_Title2
            m_Title1.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);
            m_Title2.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);
		
            // MoveIn all primary buttons
            StartCoroutine(MoveInPrimaryButtons());
        }
	
            // MoveIn all primary buttons
            function MoveInPrimaryButtons () : IEnumerator {
                yield  WaitForSeconds(1.0f);

                // MoveIn all primary buttons
                m_TopLeft_A.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);
                m_BottomLeft_A.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);
                m_RightBar_A.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);

                // Enable all scene switch buttons
                StartCoroutine(EnableAllDemoButtons());
            }

                // MoveOut all primary buttons
                function HideAllGUIs () {
                    m_TopLeft_A.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    m_BottomLeft_A.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    m_RightBar_A.MoveOut(GUIAnimSystemFREE.eGUIMove.Self);
		
                    if(m_TopLeft_IsOn == true)
                        m_TopLeft_B.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    if(m_BottomLeft_IsOn == true)
                        m_BottomLeft_B.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    if(m_RightBar_IsOn == true)
                        m_RightBar_B.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
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
	
                            function OnButton_TopLeft () {
                                // Disable m_TopLeft_A, m_RightBar_A, m_RightBar_C, m_BottomLeft_A for a few seconds
                                StartCoroutine(DisableButtonForSeconds(m_TopLeft_A.gameObject, 0.3f));
                                StartCoroutine(DisableButtonForSeconds(m_RightBar_A.gameObject, 0.6f));
                                StartCoroutine(DisableButtonForSeconds(m_RightBar_C.gameObject, 0.6f));
                                StartCoroutine(DisableButtonForSeconds(m_BottomLeft_A.gameObject, 0.3f));

                                // Toggle m_TopLeft
                                ToggleTopLeft();

                                // Toggle other buttons
                                if(m_BottomLeft_IsOn==true)
                                {
                                    ToggleBottomLeft();
                                }
                                if(m_RightBar_IsOn==true)
                                {
                                    ToggleRightBar();
                                }
                            }

                            function OnButton_BottomLeft () {
                                // Disable m_TopLeft_A, m_RightBar_A, m_RightBar_C, m_BottomLeft_A for a few seconds
                                StartCoroutine(DisableButtonForSeconds(m_TopLeft_A.gameObject, 0.3f));
                                StartCoroutine(DisableButtonForSeconds(m_RightBar_A.gameObject, 0.6f));
                                StartCoroutine(DisableButtonForSeconds(m_RightBar_C.gameObject, 0.6f));
                                StartCoroutine(DisableButtonForSeconds(m_BottomLeft_A.gameObject, 0.3f));

                                // Toggle m_BottomLeft
                                ToggleBottomLeft();
		
                                // Toggle other buttons
                                if(m_TopLeft_IsOn==true)
                                {
                                    ToggleTopLeft();
                                }
                                if(m_RightBar_IsOn==true)
                                {
                                    ToggleRightBar();
                                }
		
                            }
	
                            function OnButton_RightBar () {
                                // Disable m_TopLeft_A, m_RightBar_A, m_RightBar_C, m_BottomLeft_A for a few seconds
                                StartCoroutine(DisableButtonForSeconds(m_TopLeft_A.gameObject, 0.3f));
                                StartCoroutine(DisableButtonForSeconds(m_RightBar_A.gameObject, 0.6f));
                                StartCoroutine(DisableButtonForSeconds(m_RightBar_C.gameObject, 0.6f));
                                StartCoroutine(DisableButtonForSeconds(m_BottomLeft_A.gameObject, 0.3f));

                                // Toggle m_RightBar
                                ToggleRightBar();
		
                                // Toggle other buttons
                                if(m_TopLeft_IsOn==true)
                                {
                                    ToggleTopLeft();
                                }
                                if(m_BottomLeft_IsOn==true)
                                {
                                    ToggleBottomLeft();
                                }

                            }
		
	// ########################################
	// Toggle button functions
	// ########################################
	
                            // Toggle TopLeft buttons
                            function ToggleTopLeft () {
                                m_TopLeft_IsOn = !m_TopLeft_IsOn;
                                if(m_TopLeft_IsOn==true)
                                {
                                    // m_TopLeft_B moves in
                                    m_TopLeft_B.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                }
                                else
                                {
                                    // m_TopLeft_B moves out
                                    m_TopLeft_B.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                }
                            }
	
                            // Toggle BottomLeft buttons
                            function ToggleBottomLeft () {
                                m_BottomLeft_IsOn = !m_BottomLeft_IsOn;
                                if(m_BottomLeft_IsOn==true)
                                {
                                    // m_BottomLeft_B moves in
                                    m_BottomLeft_B.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                }
                                else
                                {
                                    // m_BottomLeft_B moves out
                                    m_BottomLeft_B.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                }
                            }
	
                            // Toggle RightBar buttons
                            function ToggleRightBar () {
                                m_RightBar_IsOn = !m_RightBar_IsOn;
                                if(m_RightBar_IsOn==true)
                                {
                                    // m_RightBar_A moves out
                                    m_RightBar_A.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                    // m_RightBar_B moves in
                                    m_RightBar_B.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                }
                                else
                                {
                                    // m_RightBar_A moves in
                                    m_RightBar_A.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                    // m_RightBar_B moves out
                                    m_RightBar_B.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                }
                            }
                        }