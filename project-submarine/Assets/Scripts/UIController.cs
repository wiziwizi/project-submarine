using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text Score;
	private int score;

	// Use this for initialization
	void Start ()
	{
		score = 0;
		UpdateScore ();
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		Score.text = "Score: " + score;
	}
}