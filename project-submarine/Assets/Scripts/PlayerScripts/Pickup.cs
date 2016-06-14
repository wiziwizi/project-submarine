using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
	private AudioSource audioSource;

	void Start(){
		audioSource = GetComponent<AudioSource>();
	}


void  OnTriggerEnter(Collider other)
	{
		
		if(other.gameObject.CompareTag("Player"))
		{
			audioSource.Play ();
			UIController.Pickups++;

			Destroy (gameObject);
		}
	}
}
