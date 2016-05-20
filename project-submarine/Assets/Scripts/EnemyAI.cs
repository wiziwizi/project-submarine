using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	//private NavMeshAgent _navMeshAgent;
	private GameObject _player;
	private GameObject _spawner;
	private bool playerHit;
	private GameObject[] sp;
	private int i;
	private UIController UIController;
	//private int waypointIndex = 0;

	//public Transform[] waypoints; 
	public  float MoveSpeed;
	private _Spawner spawnScript;

		
	// Use this for initialization
	void Awake () 
	{
		//_navMeshAgent = GetComponent<NavMeshAgent> ();
		_player = GameObject.FindGameObjectWithTag ("Player");
		sp = GameObject.FindGameObjectsWithTag ("EnemySpawnPoint");
		GameObject UIController = GameObject.FindWithTag ("UIController");

			
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
			Destroy (other.gameObject);
			UIController.AddScore (20);


			for (i = 0; i < sp.Length; i++)
			{
				sp [i].GetComponent<_Spawner> ().OnEnemyDeath ();
			}
				
		}

	}
}