using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Work : MonoBehaviour {

	public enum WorkType{
		Blacksmith,
		Farm,
		Mine
	}

	public int maxJobs = 3;
	public WorkType type;
	[Tooltip("Harsh Level set the multiplier to the hungerPerSecond of the worker")]
	[Range(0.2f, 3f)]
	public float harshLevel = 1f;
	public Resource resourceProvide;
	public float resourceTimeToCollect;

	private List<Citizen> workers = new List<Citizen>();

	void Start () {
		GameObject parent = GameObject.Find("Works");
		transform.parent = parent.transform;
	}

	public Work BecameWorker(Citizen cit){
		if(workers.Count >= maxJobs){
			throw new NotEnoughRoomException();
		}
		workers.Add(cit);
		return this;
	}

	void OnTriggerEnter(Collider coll){
		CitizenWork cit = coll.GetComponent<CitizenWork>();
		if(cit){
			cit.StartWorking();
		}
	}

	void OnTriggerExit(Collider coll){
		CitizenWork cit = coll.GetComponent<CitizenWork>();
		if(cit){
			cit.StopWorking();
		}
	}
}
