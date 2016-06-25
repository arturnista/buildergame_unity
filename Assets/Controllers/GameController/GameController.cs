using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

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
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpdateResources(){

	}
}
