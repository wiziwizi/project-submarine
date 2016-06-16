using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
	private AudioSource audioSource;
	[SerializeField]
	private GameObject PickUpparticle;
	private ParticleSystem FX_pickup;


	void Start(){
		audioSource = GetComponent<AudioSource>();

	}


void  OnTriggerEnter(Collider other)
	{
		
		if(other.gameObject.CompareTag("Player"))
		{
			
			Instantiate (PickUpparticle, transform.position, transform.rotation);

			UIController.Pickups++;
			Destroy (gameObject);
		}
	}
}
