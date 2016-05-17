using UnityEngine;
using System.Collections;

public class _Spawner : MonoBehaviour {

	public Wave[] waves;
	public EnemyAI enemy;


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
		}
	}

	public void OnEnemyDeath() {
		enemiesRemainingAlive --;
		print ("0001110");

		if (enemiesRemainingAlive == 0) {
			print ("000110");

			
			NextWave();
		}
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
