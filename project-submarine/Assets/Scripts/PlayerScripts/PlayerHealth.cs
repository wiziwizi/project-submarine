using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour 
{
	public static float health = 100;

	private bool playerDead;

	void Update()
	{
		if (health <= 0) 
		{
			health = 100;
			LevelReset ();
		}
	}

	void LevelReset()
	{
		SceneManager.LoadScene("EndScene");
	}

}