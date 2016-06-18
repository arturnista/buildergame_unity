using UnityEngine;
using System.Collections;

public class Warehouse : MonoBehaviour {

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

	public void RetrieveResource(Resource res){
		if(res.amount > 0){
			switch(res.type){
			case Resource.Type.Wood:
				woodResource.amount += res.amount;
				break;
			case Resource.Type.Iron:
				ironResource.amount += res.amount;
				break;
			case Resource.Type.Food:
				foodResource.amount += res.amount;
				break;
			}
			res.amount = 0;
		}
	}

}
