using UnityEngine;
using System.Collections;

[System.Serializable]
public class NotEnoughRoomException : System.Exception
{
	public NotEnoughRoomException ()
	{
	}
	public NotEnoughRoomException (string message) : base (message)
	{
	}
	public NotEnoughRoomException (string message, System.Exception inner) : base (message, inner)
	{
	}
	protected NotEnoughRoomException (System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base (info, context)
	{
	}
} 

