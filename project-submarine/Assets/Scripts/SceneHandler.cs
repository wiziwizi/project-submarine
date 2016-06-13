﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class SceneHandler : MonoBehaviour {

	public Canvas quitMenu;
	public Canvas optionMenu;
	public Canvas credits;

	public Button startText;
	public Button exitText;
	public Text WaveNumber;
	public Text Score;

	void Start()
	{
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		optionMenu = optionMenu.GetComponent<Canvas> ();
		quitMenu = quitMenu.GetComponent<Canvas> ();

		quitMenu.enabled = false;
		optionMenu.enabled = false;
		credits.enabled = false;

		WaveNumber.text = _Spawner.WaveNumber.ToString();
		Score.text = UIController.score.ToString();
	}
	public void NewGame()
	{
		SceneManager.LoadScene ("MainScene");
	}

	public void OptionMenu()
	{
		optionMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void QuitMenu()
	{
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void ExitQuitMenu()
	{
		optionMenu.enabled = false;
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Menu()
	{
		SceneManager.LoadScene ("MenuScene");
	}

	public void Credits ()
	{
		credits.enabled = true;
	}

	public void ExitCredits ()
	{
		credits.enabled = false;
	}
}