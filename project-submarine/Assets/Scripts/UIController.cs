using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text Score;
	public Text EnemiesRemaining;
	public Text WaveText;
	public Text WaveNumber;
	private GameObject[] er;
	public static int score;
	private float ERemaining;

	// Use this for initialization
	void Start()
	{
		WaveText.CrossFadeAlpha (0f, 0.5f, false);
		WaveNumber.CrossFadeAlpha (0f, 0.5f, false);
		score = 0;
		UpdateScore ();
	}

	void Update()
	{
		WaveText.text = _Spawner.WaveNumber.ToString();
		er = GameObject.FindGameObjectsWithTag ("Enemy");
		EnemiesRemaining.text = er.Length + ":";
		if(_Spawner.NextWaveBool == true)
		{
			WaveText.canvasRenderer.SetAlpha (1f);
			WaveNumber.canvasRenderer.SetAlpha (1f);
		}
		else
		{
			WaveText.CrossFadeAlpha (0f, 0.5f, false);
			WaveNumber.CrossFadeAlpha (0f, 0.5f, false);
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		Score.text = score + ":";
	}
}