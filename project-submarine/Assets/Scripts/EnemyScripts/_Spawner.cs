using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class _Spawner : MonoBehaviour {

	public Wave[] waves;
	public EnemyAI enemy;
	private GameObject[] gos;
	public static int WaveNumber = 1;

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
			gos = GameObject.FindGameObjectsWithTag("Enemy");
		}
	}

	public void OnEnemyDeath()
	{
		enemiesRemainingAlive --;

		gos = GameObject.FindGameObjectsWithTag("Enemy");
		Debug.Log (gos.Length);
		if (gos.Length == 1)
		{
			StartCoroutine (TimeDelay ());
		}

	}
	IEnumerator TimeDelay()
	{
		UIController.NextWaveBool = true;
		WaveNumber = currentWaveNumber;
		yield return new WaitForSeconds (5);
		NextWave ();
	}

	public void NextWave()
	{
		currentWaveNumber++;

		if (currentWaveNumber - 1 < waves.Length)
		{
			currentWave = waves [currentWaveNumber - 1];
			enemiesRemainingToSpawn = currentWave.enemyCount;
			enemiesRemainingAlive = enemiesRemainingToSpawn;
		}
		UIController.NextWaveBool = false;
	}

	[System.Serializable]
	public class Wave
	{
		public int enemyCount ;
		public float timeBetweenSpawns;
	}
}