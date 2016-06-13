using UnityEngine;
using System.Collections;

public class Enemysoundmanager : MonoBehaviour {
	public AudioClip [] _gravel;
	private AudioSource _aSource;


	// Use this for initialization
	void Start () {
		_aSource = GetComponent<AudioSource> ();
		StartCoroutine ("PlaySound");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator PlaySound(){
		_aSource.clip = _gravel [Random.Range (0, _gravel.Length)];
		_aSource.Play ();
		yield return new WaitForSeconds (_aSource.clip.length);
		StartCoroutine ("PlaySound");
}
}
