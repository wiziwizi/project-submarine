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
			LevelReset ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Enemy")
		{
			health -= 25;
		}
	}

	void LevelReset()
	{
		SceneManager.LoadScene("MainScene");
	}

}