using UnityEngine;
using System.Collections;

public class GameTimeController : MonoBehaviour {

	public enum TimeStatus{
		Pause,
		Play,
		Forward
	}

	public static float timeMultiplier = 1f;
	public static float lastTimeMultiplier = 1f;
	public static TimeStatus timeStatus = TimeStatus.Play;

	public static float deltaTime{
		get{
			return Time.deltaTime * timeMultiplier;
		}
	}

	public static void Pause(){
		lastTimeMultiplier = timeMultiplier;
		timeMultiplier = 0f;
		timeStatus = TimeStatus.Pause;
	}

	public static void Play(){
		lastTimeMultiplier = timeMultiplier;
		timeMultiplier = 1f;
		timeStatus = TimeStatus.Play;
	}

	public static void FastForward(){
		lastTimeMultiplier = timeMultiplier;
		timeMultiplier += 2f;
		timeStatus = TimeStatus.Forward;
	}

}
