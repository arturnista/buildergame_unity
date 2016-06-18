using UnityEngine;
using System.Collections;

public class DayCycleEvent : MonoBehaviour {

	public float timeScale = 60f;

	private GameObject sun;
	private GameObject entities;

	void Awake () {
		entities = GameObject.Find("Entities");
		sun = GameObject.Find("Sun");
	}

	void Update () {
		float rot = Time.deltaTime / 360f * timeScale;
		sun.transform.RotateAround(sun.transform.position, Vector3.forward, rot);
		Debug.LogWarning("DayCycleEvent not finished!");
		//entities.BroadcastMessage("OnDayChange", SendMessageOptions.DontRequireReceiver);
	}
}
