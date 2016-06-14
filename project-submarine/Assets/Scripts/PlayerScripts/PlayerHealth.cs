using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Image=UnityEngine.UI.Image;

public class PlayerHealth : MonoBehaviour 
{
	public static float health = 100;

	private bool playerDead;

	[SerializeField]
	private Image HealthBar;

	void Update()
	{
		HealthBar.fillAmount = health / 100f;
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