using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour 
{
	public float health = 100f;

	private bool playerDead;

	void Update()
	{
		if (health <= 0) 
		{
			Debug.Log ("hoi");

			LevelReset ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Enemy"))
		{
			Debug.Log ("hoi");
			health -= 22;
		}
	}

	void LevelReset()
	{
		SceneManager.LoadScene("MainScene");
	}

}
