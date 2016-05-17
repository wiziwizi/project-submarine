using UnityEngine;
using System.Collections;

public class _Spawner : MonoBehaviour {

	public Wave[] waves;
	public EnemyAI enemy;
	private GameObject[] gos;

	Wave currentWave;
	int currentWaveNumber;

	int enemiesRemainingToSpawn;
	int enemiesRemainingAlive;
	float nextSpawnTime;


	void Start() {
		NextWave ();
	}

	void Update() {

		if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime) {
			enemiesRemainingToSpawn--;
			nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

			EnemyAI spawnedEnemy = Instantiate(enemy, transform.position, Quaternion.identity) as EnemyAI;
			//spawnedEnemy.OnDeath += OnEnemyDeath;
			gos = GameObject.FindGameObjectsWithTag("Enemy");

		}
	}

	public void OnEnemyDeath() {
		enemiesRemainingAlive --;

		gos = GameObject.FindGameObjectsWithTag("Enemy");
		print (gos.Length);
		//if (enemiesRemainingAlive == 0) {
		if (gos.Length == 1)
		{
			print ("000110");


			StartCoroutine (TimeDelay ());
		}

	}
	IEnumerator TimeDelay(){
		yield return new WaitForSeconds (5);
		NextWave ();
	}

	void NextWave() {
		currentWaveNumber++;
		print ("Wave: " + currentWaveNumber);
		if (currentWaveNumber - 1 < waves.Length) {
			currentWave = waves [currentWaveNumber - 1];
			print ("0000000");
		
			enemiesRemainingToSpawn = currentWave.enemyCount;
			enemiesRemainingAlive = enemiesRemainingToSpawn;
		}
	}

	[System.Serializable]
	public class Wave {
		public int enemyCount ;
		public float timeBetweenSpawns;
	}

}
