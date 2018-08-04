using UnityEngine;
using System.Collections;

public class MissionMaster : MonoBehaviour {

	public static int mission = 0;

	public void SetMission(int number)
	{
		mission=number;
	}
}
