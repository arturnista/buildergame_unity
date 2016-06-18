using UnityEngine;
using System.Collections;

[System.Serializable]
public class WarehouseFull : System.Exception
{
	public WarehouseFull ()
	{
	}
	public WarehouseFull (string message) : base (message)
	{
	}
	public WarehouseFull (string message, System.Exception inner) : base (message, inner)
	{
	}
	protected WarehouseFull (System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base (info, context)
	{
	}
} 

