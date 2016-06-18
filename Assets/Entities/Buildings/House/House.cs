using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House : MonoBehaviour {

	public int maxCapacity = 3;

	private List<Citizen> residents = new List<Citizen>();

	void Start () {
		GameObject parent = GameObject.Find("Houses");
		transform.parent = parent.transform;
	}

	public House BecameResident(Citizen cit){
		if(residents.Count >= maxCapacity){
			throw new NotEnoughRoomException();
		}
		residents.Add(cit);
		return this;
	}
}
