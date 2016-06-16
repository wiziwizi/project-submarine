using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
	private AudioSource audioSource;
	private bool Force = false;
	private float smooth = 3.0f;
	private GameObject Target;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		Target = GameObject.Find("GravitationalObject");
	}


void  OnTriggerEnter(Collider other)
	{
		
		if(other.gameObject.CompareTag("Player"))
		{
			audioSource.Play ();
			UIController.Pickups++;

			Destroy (gameObject);
		}
		if(other.gameObject.CompareTag("Force"))
		{
			Force = true;
		}
	}
	void FixedUpdate()
	{
		if (Force == true)
		{
			transform.position = Vector3.Lerp (transform.position, Target.transform.position, Time.fixedDeltaTime * smooth);
		}
	}
}