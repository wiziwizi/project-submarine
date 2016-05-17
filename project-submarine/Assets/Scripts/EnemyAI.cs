using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	//private NavMeshAgent _navMeshAgent;
	private GameObject _player;
	private GameObject _spawner;
	private bool playerHit;
	//private int waypointIndex = 0;

	//public Transform[] waypoints; 
	public  float MoveSpeed;
	private _Spawner spawnScript;

		
	// Use this for initialization
	void Awake () 
	{
		//_navMeshAgent = GetComponent<NavMeshAgent> ();
		_player = GameObject.FindGameObjectWithTag ("Player");
		_spawner = GameObject.FindGameObjectWithTag ("EnemySpawnPoint");	
	}

	// Update is called once per frame
	void  Update()
	{
		transform.LookAt (_player.transform.position);

		if (playerHit == true)
		{
			transform.position -= transform.forward * MoveSpeed * 2 * Time.deltaTime;
			Invoke ("Reverse", 0.5f);
		}
		else
		{
			transform.position += transform.forward * MoveSpeed * Time.deltaTime;
		}
	}

	void Reverse()
	{
		transform.position += transform.forward * MoveSpeed * Time.deltaTime;
		playerHit = false;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.transform.tag == "Player")
		{
			playerHit = true;
		}
		if (other.gameObject.tag == "projectile") {
			
			Destroy (gameObject);
			Debug.Log ("Raak");
			Destroy (other.gameObject);
			_spawner.GetComponent<_Spawner> ().OnEnemyDeath ();

		}

	}
}