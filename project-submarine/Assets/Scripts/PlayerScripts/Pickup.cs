using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
	private AudioSource audioSource;

	void Start(){
		audioSource = GetComponent<AudioSource>();
	}


	IEnumerator  OnTriggerEnter(Collider other)
	{
		
		if(other.gameObject.CompareTag("Player"))
		{
			audioSource.Play ();
			UIController.Pickups++;
			yield return new WaitForSeconds (0.5f);
			Destroy (gameObject);
		}
	}
}
