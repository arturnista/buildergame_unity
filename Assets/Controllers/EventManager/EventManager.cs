using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void Listener();

public class EventManager : MonoBehaviour {

	private Dictionary<string, ListenerList> listeners;

	void CreateDic () {
		listeners = new Dictionary<string, ListenerList>();
	}

	private static EventManager thisEventlistener;
	public static EventManager scene{
		get{
			if(!thisEventlistener){
				thisEventlistener = GameObject.FindObjectOfType<EventManager>();
			}
			return thisEventlistener;
		}
	}
	
	public void AddListener(string ev, Listener method){
		if(listeners == null){
			CreateDic();
		}
		if(!listeners.ContainsKey(ev)){
			listeners.Add(ev, new ListenerList());
		}
		listeners[ev].AddListener(method);
	}

	public void FireEvent(string ev){
		if(listeners == null){
			CreateDic();
		}
		if(!listeners.ContainsKey(ev)){
			return;
		}
		foreach(Listener list in listeners[ev].methods){
			list();
		}
	}

}

class ListenerList {

	public List<Listener> methods;

	public ListenerList(){
		methods = new List<Listener>();
	}

	public void AddListener(Listener ls){
		methods.Add(ls);
	}
}