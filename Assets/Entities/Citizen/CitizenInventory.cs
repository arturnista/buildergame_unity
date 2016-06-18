using UnityEngine;
using System.Collections;

public class CitizenInventory : MonoBehaviour {

	private Resource resourceCarried;

	private Warehouse warehouse;
	private CitizenWork work;

	public Resource resource{
		get{
			return resourceCarried;
		}
		set{
			resourceCarried = value;
		}
	}

	public Warehouse citWarehouse{
		get{
			return warehouse;
		}
	}

	void Awake(){
		work = GetComponent<CitizenWork>();
		Warehouse[] warehouses = GameObject.FindObjectsOfType<Warehouse>();
		warehouse = warehouses[0];
		if(warehouses.Length > 1){
			foreach(Warehouse wh in warehouses){
				float newDist = Vector3.Distance(wh.transform.position, work.job.transform.position);
				float oldDist = Vector3.Distance(warehouse.transform.position, work.job.transform.position);
				if(newDist < oldDist){
					warehouse = wh;
				}
			}
		}
	}

}
