using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour {
	public GameObject[] enemies;
	public int amount;
	private Vector3 spawnpoint;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		amount = enemies.Length;
		if (amount != 10) {
			InvokeRepeating ("spawnEnemy", 1, 5f);

		}

	
	}
	void spawnEnemy (){
		spawnpoint.x = Random.Range (-20, 20);
		spawnpoint.y = 0.5f;
		spawnpoint.z = Random.Range(-20,20);
		Instantiate (enemies [UnityEngine.Random.Range (0, enemies.Length - 1)], spawnpoint, Quaternion.identity);
		CancelInvoke ();
	}
}
