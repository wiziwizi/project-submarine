using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pauze : MonoBehaviour {

	public static bool Pause = false;
	public Canvas PauseMenu;

	void Awake()
	{
		PauseMenu = PauseMenu.GetComponent<Canvas> ();
		PauseMenu.enabled = false;
	}

	void Update ()
	{
		if (Pause == false && Input.GetKeyDown(KeyCode.P))
		{
			Debug.Log (Time.timeScale);
			Time.timeScale = 0f;
			Pause = true;
			PauseMenu.enabled = true;
		}
		if (Pause == true && Input.GetKeyDown(KeyCode.Escape))
		{
			UnPause ();
		}
	}

	public void UnPause()
	{
		Time.timeScale = 1f;
		Pause = false;
		PauseMenu.enabled = false;
	}
	public void Exit()
	{
		Application.Quit ();
	}
}
