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
// GA_FREE_Demo07 class
// - Animates all GUIAnimFREE elements in the scene.
// - Responds to user mouse click or tap on buttons.
//
// Note this class is attached with "-SceneController-" object in "GA FREE JS - Demo07 (960x600px)" scene.
// ######################################################################

class GA_FREE_JS_Demo07 extends MonoBehaviour {

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
    var m_Dialog : GUIAnimFREE;
    var m_DialogButtons : GUIAnimFREE;
	
   // GUIAnim objects of buttons
    var m_Button1 : GUIAnimFREE;
    var m_Button2 : GUIAnimFREE;
    var m_Button3 : GUIAnimFREE;
    var m_Button4 : GUIAnimFREE;
	
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
            yield  WaitForSeconds(1.0f);
		
            // MoveIn m_Title1 and m_Title2
            m_Title1.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);
            m_Title2.MoveIn(GUIAnimSystemFREE.eGUIMove.Self);
		
            // MoveIn all dialogs and buttons
            StartCoroutine(MoveInPrimaryButtons());
        }
	
            // MoveIn all dialogs and buttons
            function MoveInPrimaryButtons () : IEnumerator {
                yield  WaitForSeconds(1.0f);
		
                // MoveIn all dialogs
                m_Dialog.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                m_DialogButtons.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                // MoveIn all buttons
                m_Button1.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);	
                m_Button2.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);	
                m_Button3.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);	
                m_Button4.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                // Enable all scene switch buttons
                StartCoroutine(EnableAllDemoButtons());
            }
	
                // MoveOut all dialogs and buttons
                function HideAllGUIs () {
                    // MoveOut all dialogs
                    m_Dialog.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    m_DialogButtons.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                    // MoveOut all buttons
                    m_Button1.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    m_Button2.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    m_Button3.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                    m_Button4.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
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
                        function DisableButtonForSeconds ( GO : GameObject ,   DisableTime : float) {
                            // Disable all buttons
                            GUIAnimSystemFREE.Instance.EnableButton(GO.transform, false);
		
                            yield  WaitForSeconds(DisableTime);
		
                            // Enable all buttons
                            GUIAnimSystemFREE.Instance.EnableButton(GO.transform, true);
                        }
	
	// ########################################
	// UI Responder functions
	// ########################################
	
                            function OnButton_1 () {
                                // MoveOut m_Button1
                                MoveButtonsOut();
		
                                // Disable m_Button1, m_Button2, m_Button3, m_Button4 for a few seconds
                                StartCoroutine(DisableButtonForSeconds(m_Button1.gameObject, 2.0f));
                                StartCoroutine(DisableButtonForSeconds(m_Button2.gameObject, 2.0f));
                                StartCoroutine(DisableButtonForSeconds(m_Button3.gameObject, 2.0f));
                                StartCoroutine(DisableButtonForSeconds(m_Button4.gameObject, 2.0f));

                                // Set next move in of m_Button1 to new position
                                StartCoroutine(SetButtonMove(GUIAnimFREE.ePosMove.UpperScreenEdge, GUIAnimFREE.ePosMove.UpperScreenEdge));
                            }
	
                            function OnButton_2 () {
                                // MoveOut m_Button2
                                MoveButtonsOut();
		
                                // Disable m_Button1, m_Button2, m_Button3, m_Button4 for a few seconds
                                StartCoroutine(DisableButtonForSeconds(m_Button1.gameObject, 2.0f));
                                StartCoroutine(DisableButtonForSeconds(m_Button2.gameObject, 2.0f));
                                StartCoroutine(DisableButtonForSeconds(m_Button3.gameObject, 2.0f));
                                StartCoroutine(DisableButtonForSeconds(m_Button4.gameObject, 2.0f));
		
                                // Set next move in of m_Button2 to new position
                                StartCoroutine(SetButtonMove(GUIAnimFREE.ePosMove.LeftScreenEdge, GUIAnimFREE.ePosMove.LeftScreenEdge));
                            }
	
                            function OnButton_3 () {
                                // MoveOut m_Button3
                                MoveButtonsOut();
		
                                // Disable m_Button1, m_Button2, m_Button3, m_Button4 for a few seconds
                                StartCoroutine(DisableButtonForSeconds(m_Button1.gameObject, 2.0f));
                                StartCoroutine(DisableButtonForSeconds(m_Button2.gameObject, 2.0f));
                                StartCoroutine(DisableButtonForSeconds(m_Button3.gameObject, 2.0f));
                                StartCoroutine(DisableButtonForSeconds(m_Button4.gameObject, 2.0f));

                                // Set next move in of m_Button3 to new position
                                StartCoroutine(SetButtonMove(GUIAnimFREE.ePosMove.RightScreenEdge, GUIAnimFREE.ePosMove.RightScreenEdge));
                            }
	
                            function OnButton_4 () {
                                // MoveOut m_Button4
                                MoveButtonsOut();
		
                                // Disable m_Button1, m_Button2, m_Button3, m_Button4 for a few seconds
                                StartCoroutine(DisableButtonForSeconds(m_Button1.gameObject, 2.0f));
                                StartCoroutine(DisableButtonForSeconds(m_Button2.gameObject, 2.0f));
                                StartCoroutine(DisableButtonForSeconds(m_Button3.gameObject, 2.0f));
                                StartCoroutine(DisableButtonForSeconds(m_Button4.gameObject, 2.0f));
		
                                // Set next move in of m_Button3 to new position
                                StartCoroutine(SetButtonMove(GUIAnimFREE.ePosMove.BottomScreenEdge, GUIAnimFREE.ePosMove.BottomScreenEdge));
                            }
	
                            function OnDialogButton () {
                                // MoveOut m_Dialog
                                m_Dialog.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                m_DialogButtons.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                                // Disable m_DialogButtons for a few seconds
                                StartCoroutine(DisableButtonForSeconds(m_DialogButtons.gameObject, 2.0f));

                                // Moves m_Dialog back to screen
                                StartCoroutine(DialogMoveIn());
                            }
	
	// ########################################
	// Move Dialog/Button functions
	// ########################################
	
                            // MoveOut all buttons
                            function MoveButtonsOut () {
                                m_Button1.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                m_Button2.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                m_Button3.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                m_Button4.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                            }
	
                            // Set next move in of all buttons to new position
                            function SetButtonMove ( PosMoveIn : GUIAnimFREE.ePosMove ,   PosMoveOut : GUIAnimFREE.ePosMove  ) : IEnumerator {
                                yield  WaitForSeconds(2.0f);
		
                                // Set next MoveIn position of m_Button1 to PosMoveIn
                                m_Button1.m_MoveIn.MoveFrom = PosMoveIn;
                                // Reset m_Button1
                                m_Button1.Reset();
                                // MoveIn m_Button1
                                m_Button1.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                                // Set next MoveIn position of m_Button2 to PosMoveIn
                                m_Button2.m_MoveIn.MoveFrom = PosMoveIn;
                                // Reset m_Button2
                                m_Button2.Reset();
                                // MoveIn m_Button2
                                m_Button2.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                                // Set next MoveIn position of m_Button3 to PosMoveIn
                                m_Button3.m_MoveIn.MoveFrom = PosMoveIn;
                                // Reset m_Button3
                                m_Button3.Reset();
                                // MoveIn m_Button3
                                m_Button3.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                                // Set next MoveIn position of m_Button4 to PosMoveIn
                                m_Button4.m_MoveIn.MoveFrom = PosMoveIn;
                                // Reset m_Button4
                                m_Button4.Reset();
                                // MoveIn m_Button4
                                m_Button4.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                            }
	
                                // Moves m_Dialog back to screen
                                function DialogMoveIn () : IEnumerator {
                                    yield  WaitForSeconds(1.5f);
		
                                    m_Dialog.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                    m_DialogButtons.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                                }
                                }
