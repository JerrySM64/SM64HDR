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
// GA_FREE_Demo02 class
// - Animates all GUIAnimFREE elements in the scene.
// - Responds to user mouse click or tap on buttons.
//
// Note this class is attached with "-SceneController-" object in "GA FREE JS - Demo02 (960x600px)" scene.
// ######################################################################

class GA_FREE_JS_Demo02 extends MonoBehaviour {

	// ########################################
	// Variables
	// ########################################

    // Canvas
    var m_Canvas : Canvas;
	
	// GUIAnim objects of Title text
	 var m_Title1 : GUIAnimFREE;
	 var m_Title2 : GUIAnimFREE;
	
	// GUIAnim objects of Top and bottom
	 var m_TopBar : GUIAnimFREE;
	 var m_BottomBar : GUIAnimFREE;
	
	// GUIAnim object of Dialog
	 var m_Dialog : GUIAnimFREE;
	
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
		
            // MoveIn m_Dialog
            StartCoroutine(ShowDialog());
        }
	
            // MoveIn m_Dialog
            function ShowDialog () : IEnumerator {
                yield  WaitForSeconds(1.0f);
		
                // MoveIn m_Dialog
                m_Dialog.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                // Enable all scene switch buttons
                StartCoroutine(EnableAllDemoButtons());
            }
	
                // MoveOut m_Dialog
                function HideAllGUIs () {
                    // MoveOut m_Dialog
                    m_Dialog.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
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
	
                            function OnButton_UpperEdge () {
                                // MoveOut m_Dialog
                                m_Dialog.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);

                                // MoveIn m_Dialog from top
                                StartCoroutine(DialogMoveIn(GUIAnimFREE.ePosMove.UpperScreenEdge));
                            }
	
                            function OnButton_LeftEdge () {
                                // MoveOut m_Dialog
                                m_Dialog.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                                // MoveIn m_Dialog from left
                                StartCoroutine(DialogMoveIn(GUIAnimFREE.ePosMove.LeftScreenEdge));
                            }
	
                            function OnButton_RightEdge () {
                                // MoveOut m_Dialog
                                m_Dialog.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                                // Disable all buttons for a few seconds
                                StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
                                // MoveIn m_Dialog from right
                                StartCoroutine(DialogMoveIn(GUIAnimFREE.ePosMove.RightScreenEdge));
                            }
	
                            function OnButton_BottomEdge () {
                                // MoveOut m_Dialog
                                m_Dialog.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                                // Disable all buttons for a few seconds
                                StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
                                // MoveIn m_Dialog from bottom
                                StartCoroutine(DialogMoveIn(GUIAnimFREE.ePosMove.BottomScreenEdge));
                            }
	
                            function OnButton_UpperLeft () {
                                // MoveOut m_Dialog
                                m_Dialog.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                                // Disable all buttons for a few seconds
                                StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
                                // MoveIn m_Dialog from upper left
                                StartCoroutine(DialogMoveIn(GUIAnimFREE.ePosMove.UpperLeft));
                            }
	
                            function OnButton_UpperRight () {
                                // MoveOut m_Dialog
                                m_Dialog.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                                // Disable all buttons for a few seconds
                                StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
                                // MoveIn m_Dialog from upper right
                                StartCoroutine(DialogMoveIn(GUIAnimFREE.ePosMove.UpperRight));
                            }
	
                            function OnButton_BottomLeft () {
                                // MoveOut m_Dialog
                                m_Dialog.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                                // Disable all buttons for a few seconds
                                StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
                                // MoveIn m_Dialog from bottom left
                                StartCoroutine(DialogMoveIn(GUIAnimFREE.ePosMove.BottomLeft));
                            }
	
                            function OnButton_BottomRight () {
                                // MoveOut m_Dialog
                                m_Dialog.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
                                // Disable all buttons for a few seconds
                                StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
                                // MoveIn m_Dialog from bottom right
                                StartCoroutine(DialogMoveIn(GUIAnimFREE.ePosMove.BottomRight));
                            }
	
                            function OnButton_Center () {
                                // MoveOut m_Dialog
                                m_Dialog.MoveOut(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);

                                // Disable all buttons for a few seconds
                                StartCoroutine(DisableAllButtonsForSeconds(2.0f));
		
                                // MoveIn m_Dialog from center of screen
                                StartCoroutine(DialogMoveIn(GUIAnimFREE.ePosMove.MiddleCenter));
                            }
	
	// ########################################
	// Move dialog functions
	// ########################################
	
                            // MoveIn m_Dialog by position
                            function DialogMoveIn ( PosMoveIn : GUIAnimFREE.ePosMove  ) : IEnumerator {
                                yield  WaitForSeconds(1.5f);
		
                                //Debug.Log("PosMoveIn="+PosMoveIn);
                                switch(PosMoveIn)
                                {
                                    // Set m_Dialog to move in from upper
                                    case GUIAnimFREE.ePosMove.UpperScreenEdge:
                                        m_Dialog.m_MoveIn.MoveFrom = GUIAnimFREE.ePosMove.UpperScreenEdge;
                                        m_Dialog.m_MoveOut.MoveTo = GUIAnimFREE.ePosMove.MiddleCenter;
                                        break;
                                        // Set m_Dialog to move in from left
                                    case GUIAnimFREE.ePosMove.LeftScreenEdge:
                                        m_Dialog.m_MoveIn.MoveFrom = GUIAnimFREE.ePosMove.LeftScreenEdge;
                                        m_Dialog.m_MoveOut.MoveTo = GUIAnimFREE.ePosMove.MiddleCenter;
                                        break;
                                        // Set m_Dialog to move in from right
                                    case GUIAnimFREE.ePosMove.RightScreenEdge:
                                        m_Dialog.m_MoveIn.MoveFrom = GUIAnimFREE.ePosMove.RightScreenEdge;
                                        m_Dialog.m_MoveOut.MoveTo = GUIAnimFREE.ePosMove.MiddleCenter;
                                        break;
                                        // Set m_Dialog to move in from bottom
                                    case GUIAnimFREE.ePosMove.BottomScreenEdge:
                                        m_Dialog.m_MoveIn.MoveFrom = GUIAnimFREE.ePosMove.BottomScreenEdge;
                                        m_Dialog.m_MoveOut.MoveTo = GUIAnimFREE.ePosMove.MiddleCenter;
                                        break;
                                        // Set m_Dialog to move in from upper left
                                    case GUIAnimFREE.ePosMove.UpperLeft:	
                                        m_Dialog.m_MoveIn.MoveFrom = GUIAnimFREE.ePosMove.UpperLeft;
                                        m_Dialog.m_MoveOut.MoveTo = GUIAnimFREE.ePosMove.MiddleCenter;
                                        break;
                                        // Set m_Dialog to move in from upper right
                                    case GUIAnimFREE.ePosMove.UpperRight:
                                        m_Dialog.m_MoveIn.MoveFrom = GUIAnimFREE.ePosMove.UpperRight;
                                        m_Dialog.m_MoveOut.MoveTo = GUIAnimFREE.ePosMove.MiddleCenter;
                                        break;
                                        // Set m_Dialog to move in from bottom left
                                    case GUIAnimFREE.ePosMove.BottomLeft:
                                        m_Dialog.m_MoveIn.MoveFrom = GUIAnimFREE.ePosMove.BottomLeft;
                                        m_Dialog.m_MoveOut.MoveTo = GUIAnimFREE.ePosMove.MiddleCenter;
                                        break;
                                        // Set m_Dialog to move in from bottom right
                                    case GUIAnimFREE.ePosMove.BottomRight:
                                        m_Dialog.m_MoveIn.MoveFrom = GUIAnimFREE.ePosMove.BottomRight;
                                        m_Dialog.m_MoveOut.MoveTo = GUIAnimFREE.ePosMove.MiddleCenter;
                                        break;
                                        // Set m_Dialog to move in from center
                                    case GUIAnimFREE.ePosMove.MiddleCenter:
/*
                                        m_Dialog.m_MoveIn.MoveFrom = GUIAnimFREE.ePosMove.MiddleCenter;
                                        m_Dialog.m_MoveOut.MoveTo = GUIAnimFREE.ePosMove.MiddleCenter;
*/
                                        break;
                                    default:
                                        m_Dialog.m_MoveIn.MoveFrom = GUIAnimFREE.ePosMove.MiddleCenter;
                                        m_Dialog.m_MoveOut.MoveTo = GUIAnimFREE.ePosMove.MiddleCenter;
                                        break;
                                }

                                // Reset m_Dialog
                                m_Dialog.Reset();

                                // MoveIn m_Dialog by position
                                m_Dialog.MoveIn(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
                            }
	
                            }