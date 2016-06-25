using UnityEngine;
using System.Collections;

public class DayCycleEvent : MonoBehaviour {

	public float timeScale = 60f;

	private GameObject sun;
	private GameObject entities;

	void Awake () {
		entities = GameObject.Find("Entities");
		sun = GameObject.Find("Sun");
		Debug.LogWarning("DayCycleEvent not finished!");
	}

	void Update () {
		float rot = GameTimeController.deltaTime / 360f * timeScale;
		sun.transform.RotateAround(sun.transform.position, Vector3.forward, rot);
		EventManager.scene.FireEvent(EventStr.DAY_CHANGE_EVENT);
	}
}
