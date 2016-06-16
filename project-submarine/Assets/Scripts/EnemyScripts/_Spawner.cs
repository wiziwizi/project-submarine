using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class _Spawner : MonoBehaviour {

	public Wave[] waves;
	public EnemyAI enemy;
	private GameObject[] gos;
	public Text WaveText;
	public static int WaveNumber = 1;
	public static bool NextWaveBool;


	Wave currentWave;
	int currentWaveNumber;

	int enemiesRemainingToSpawn;
	int enemiesRemainingAlive;
	float nextSpawnTime;


	void Start() {
		NextWave ();

	}

	void Update() {

		if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
		{
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
		if (gos.Length == 1)
		{
			Invoke ("TimeDelay", 5f);
		}

	}
	void TimeDelay()
	{
		NextWaveBool = true;
		NextWave ();
	}

	public void NextWave()
	{
		currentWaveNumber++;
		WaveNumber = currentWaveNumber;
		NextWaveBool = true;

		if (currentWaveNumber - 1 < waves.Length)
		{
			currentWave = waves [currentWaveNumber - 1];
			enemiesRemainingToSpawn = currentWave.enemyCount;
			enemiesRemainingAlive = enemiesRemainingToSpawn;
		}

		NextWaveBool = false;
	}

	[System.Serializable]
	public class Wave {
		public int enemyCount ;
		public float timeBetweenSpawns;
	}

}
