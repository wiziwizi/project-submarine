using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private GameObject _player;
	private bool playerHit;
	private int i;
	public float Damage;
	public  float MoveSpeed;
	private _Spawner spawnScript;

		
	// Use this for initialization
	void Awake () 
	{
		_player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void  Update()
	{
		Debug.Log (transform.forward);
		transform.LookAt (_player.transform.position);
		Debug.Log (playerHit);
		if (playerHit == true)
		{
			Debug.Log ("Check2: "+playerHit);
			//transform.position -= transform.forward * MoveSpeed * Time.deltaTime;
			PlayerHealth.health -= Damage;
			Invoke ("Reverse", 0.5f);
		}
		else
		{
			transform.position += transform.forward * MoveSpeed * Time.deltaTime;
		}

	}

	void Reverse()
	{
		Debug.Log ("Check3: "+playerHit);
		transform.position += transform.forward * MoveSpeed * Time.deltaTime;
		playerHit = false;

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			playerHit = true;
			Debug.Log ("Check4: "+playerHit);
		}
	}
}