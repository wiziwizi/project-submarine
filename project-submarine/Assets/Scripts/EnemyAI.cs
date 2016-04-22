using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	//private NavMeshAgent _navMeshAgent;
	private GameObject _player;
	//private int waypointIndex = 0;

	//public Transform[] waypoints; 
	public  float MoveSpeed;

	// Use this for initialization
	void Awake () 
	{
		//_navMeshAgent = GetComponent<NavMeshAgent> ();
		_player = GameObject.FindGameObjectWithTag ("Player");

	}

	// Update is called once per frame
	void  Update()
	{
		transform.LookAt (_player.transform.position);
		transform.position += transform.forward * MoveSpeed * Time.deltaTime;
	}
}
