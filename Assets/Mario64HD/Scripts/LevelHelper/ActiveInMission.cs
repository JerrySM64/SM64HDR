using UnityEngine;
using System.Collections;
using System.Linq;
public class ActiveInMission : MonoBehaviour {
	public int[] activeIn = {0};
	void Awake () {
		if(activeIn.Contains(MissionMaster.mission))
		{
				gameObject.SetActive(true);
		}
		else{
			gameObject.SetActive(false);
		}
	}
}
