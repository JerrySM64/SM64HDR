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
// GA_FREE_DemoPlaySound class
// This class plays AudioClip and button sounds.
// ######################################################################

class GA_FREE_JS_DemoPlaySound extends MonoBehaviour {

	// ########################################
	// Variables
	// ########################################
	
    var m_AudioSourceCount : int= 2;
	
    protected var m_AudioSource : AudioSource[]= null;
	
    var m_Audio_Button1 : AudioClip= null;
    var m_Audio_Button2 : AudioClip= null;

	// ########################################
	// MonoBehaviour Functions
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.html
	// ########################################
	
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
   function Start () {

       // Create AudioSource list
       if(m_AudioSource==null)
       {
           m_AudioSource = new AudioSource[m_AudioSourceCount];
			
           for( var i : int=0;i<m_AudioSource.Length;i++)
           {
                var pAudioSource : AudioSource=  this.gameObject.AddComponent(AudioSource);
               pAudioSource.rolloffMode = AudioRolloffMode.Linear;
               m_AudioSource[i] = pAudioSource;
           }
   }
    }
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
    function Update () {
		
    }

	// ########################################
	// Play sound Functions
	// ########################################
	
    // Play AudioClip
    function PlayOneShot ( pAudioClip : AudioClip  ) {

        for( var i : int=0;i<m_AudioSource.Length;i++)
        {
			if(m_AudioSource[i].isPlaying == false)
        {
				m_AudioSource[i].PlayOneShot(pAudioClip);
				break;
        }
}
}

// Play m_Audio_Button1 audio clip
function PlaySoundButton1 () {
    PlayOneShot(m_Audio_Button1);
}
	
// Play m_Audio_Button2 audio clip
function PlaySoundButton2 () {
    PlayOneShot(m_Audio_Button2);
}
}

