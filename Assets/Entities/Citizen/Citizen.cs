using UnityEngine;
using System.Collections;

public class Citizen : MonoBehaviour {

	public const float MAX_HUNGER = 100F;
	public const float HUNGRY_AMOUNT = 30F;

	private House home;

	private CitizenInventory inventory;
	private CitizenMovement movement;
	private CitizenWork work;

	private float hunger;
	private float hungerPerSecond = 3;

	private bool isHungry;
	private bool isRetrievingResource;

	public House house{
		get{
			return home;
		}
	}

	public Work job{
		get{
			return work.job;
		}
	}

	public bool isHomeless{
		get{
			return home == null;
		}
	}

	public bool isJobless{
		get{
			return job == null;
		}
	}

	public float Hunger{
		get{
			return hunger;
		}
		set{
			if(value > 0){
				hunger = value;
			}
		}
	}

	public bool isWorking{
		get{
			return work.IsWoorking();
		}
	}

	void Awake(){
		movement = GetComponent<CitizenMovement>();
		work = GetComponent<CitizenWork>();
		inventory = GetComponent<CitizenInventory>();

		hunger = MAX_HUNGER;
	}

	void Start(){
		GameObject parent = GameObject.Find("Citizens");
		transform.parent = parent.transform;

		if(!home){
			House[] houses = GameObject.FindObjectsOfType<House>();
			foreach(House h in houses){
				try{
					home = h.BecameResident(this);
					break;
				}catch(NotEnoughRoomException){
					continue;
				}
			}
		}
	}

	void Update(){
		float curHPS = hungerPerSecond * (isWorking ? job.harshLevel : 1f);

		hunger -= curHPS * Time.deltaTime;
		if(hunger <= HUNGRY_AMOUNT){
			isHungry = true;
		}

		SetTarget();
	}

	void SetTarget(){
		if(isHungry){
			movement.SetTarget(home.transform);
			if(hunger >= HUNGRY_AMOUNT){
				isHungry = false;
			}
			return;
		}
		if(isRetrievingResource){
			movement.SetTarget(inventory.citWarehouse.transform);
			return;
		}
		movement.SetTarget(job.transform);
	}

	public void RetrieveResource(){
		isRetrievingResource = true;
	}

	public void OnArriveTarget(){
		if(isRetrievingResource){
			try{
				inventory.citWarehouse.RetrieveResource(inventory.resource);
				isRetrievingResource = false;
			} catch(WarehouseFull){
				isRetrievingResource = true;
			}
		}else if(isHungry){
			try{
				hunger = MAX_HUNGER;
				isRetrievingResource = false;
			} catch(WarehouseFull){
				isRetrievingResource = true;
			}
		}
	}
}
