using UnityEngine;
using System.Collections;

public class CitizenMovement : MonoBehaviour {

	private Transform target;
	private Vector3 lastTargetPosition;
	private NavMeshAgent navMeshAgent;
	private bool targetAlreadyArrived;

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
		
	}

	void Start () {
		navMeshAgent = GetComponent<NavMeshAgent>();
		lastTargetPosition = Vector3.zero;
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
