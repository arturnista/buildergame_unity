using UnityEngine;
using System.Collections;

public class CitizenWork : MonoBehaviour {

	public Work.WorkType workType;

	[HideInInspector]
	public Work job;

	private bool isWorking;
	private float workingTime;

	private Citizen citizen;
	private CitizenInventory inventory;

	void Awake(){
		inventory = GetComponent<CitizenInventory>();
		citizen = GetComponent<Citizen>();

		isWorking = false;
	}

	void Start () {
		if(!job){
			Work[] works = GameObject.FindObjectsOfType<Work>();
			foreach(Work w in works){
				try{
					if(w.type == workType){
						job = w.BecameWorker(citizen);
						break;
					}
				}catch(NotEnoughRoomException){
					continue;
				}
			}
		}
	}

	void Update(){
		if(isWorking){
			workingTime += GameTimeController.deltaTime;
			if(workingTime >= job.resourceTimeToCollect){
				inventory.resource = new Resource(job.resourceProvide);

				citizen.RetrieveResource();

				workingTime = 0f;
			}
		}
	}

	public void StartWorking(){
		isWorking = true;
	}

	public void StopWorking(){
		isWorking = false;
	}

	public bool IsWoorking(){
		return isWorking;
	}
}
