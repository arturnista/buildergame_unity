using UnityEngine;
using System.Collections;

[System.Serializable]
public class Resource {
	public enum Type{
		Food,
		Wood,
		Iron,
		Tool
	}

	public Type type;
	public int amount;

	public Resource(){

	}
	public Resource(Resource res){
		type = res.type;
		amount = res.amount;
	}
}
