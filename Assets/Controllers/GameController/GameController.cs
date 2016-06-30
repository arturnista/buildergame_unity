using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject house;

	private Resource woodResource;
	private Resource ironResource;
	private Resource foodResource;

	void Awake () {
		woodResource = new Resource();
		woodResource.type = Resource.Type.Wood;

		ironResource = new Resource();
		ironResource.type = Resource.Type.Iron;

		foodResource = new Resource();
		foodResource.type = Resource.Type.Food;
	}

	public void BuildHouse(Vector3 position){
		Instantiate(house, position, Quaternion.identity);
	}

	void Update () {
	
	}

	void UpdateResources(){

	}
}
