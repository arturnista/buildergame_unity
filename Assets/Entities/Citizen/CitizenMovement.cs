using UnityEngine;
using System.Collections;

public class CitizenMovement : MonoBehaviour {

	private Transform target;
	private Vector3 lastTargetPosition;
	private NavMeshAgent navMeshAgent;
	private bool targetAlreadyArrived;

	private float normalSpeed;

	private Vector3 targetPosition{
		get{
			if(target)
				return target.position;
			else
				return transform.position;
		}
	}

	public void SetTarget(Transform target){
		this.target = target;
	}

	void Awake(){
		navMeshAgent = GetComponent<NavMeshAgent>();
		normalSpeed = navMeshAgent.speed;
		EventManager em = GameObject.FindObjectOfType<EventManager>();
		em.AddListener(EventStr.PAUSE_GAME_EVENT, OnChangeTime);
		em.AddListener(EventStr.PLAY_GAME_EVENT, OnChangeTime);
		em.AddListener(EventStr.FORWARD_GAME_EVENT, OnChangeTime);
	}

	void Start () {
		lastTargetPosition = Vector3.zero;
	}

	public void OnChangeTime(){
		Vector3 normalVelocity = navMeshAgent.velocity / GameTimeController.lastTimeMultiplier;
		navMeshAgent.velocity = normalVelocity * GameTimeController.timeMultiplier;
		navMeshAgent.speed = normalSpeed * GameTimeController.timeMultiplier;

		print(GameTimeController.timeMultiplier);
	}

	void Update () {
		navMeshAgent.SetDestination(targetPosition);
		if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance){
			ArriveTarget();
		}
		if(lastTargetPosition != targetPosition){
			ChangeTarget();
			lastTargetPosition = targetPosition;
		}
	}

	void ChangeTarget(){
		if(!target){
			return;
		}
		StopMove();
		Vector3 be = target.GetComponent<Collider>().bounds.extents;
		float dist = Mathf.Max(be.x, be.z);
		navMeshAgent.stoppingDistance = dist;
		targetAlreadyArrived = false;
	}

	void ArriveTarget(){
		if(targetAlreadyArrived){
			return;
		}

		SendMessage("OnArriveTarget");

		StopMove();
		targetAlreadyArrived = true;
	}

	void StopMove(){
		navMeshAgent.velocity = Vector3.zero;
	}

	void OnTriggerEnter(Collider coll){
		Road rd = coll.GetComponent<Road>();
		if(rd){
			navMeshAgent.speed *= rd.movementMultiplier;
		}
	}

	void OnTriggerExit(Collider coll){
		Road rd = coll.GetComponent<Road>();
		if(rd){
			navMeshAgent.speed /= rd.movementMultiplier;
		}
	}
}
