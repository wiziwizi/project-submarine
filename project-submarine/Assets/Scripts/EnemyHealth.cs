using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour 
{
	public float health;
	public float Damage;
	private int i;
	private GameObject[] sp;
	private GameObject _canvas;
	private UIController uiController;

	void Awake ()
	{
		_canvas = GameObject.FindGameObjectWithTag ("UIController");
		uiController = _canvas.GetComponent<UIController> ();
		sp = GameObject.FindGameObjectsWithTag ("EnemySpawnPoint");
	}

	void Update()
	{
		if (health <= 0) 
		{
			EnemyDeath ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "projectile")
		{
			health -= Damage;
		}
	}

	void EnemyDeath()
	{
		Destroy (gameObject);
		uiController.AddScore (20);
		for (i = 0; i < sp.Length; i++)
		{
			sp [i].GetComponent<_Spawner> ().OnEnemyDeath ();
		}
	}

}