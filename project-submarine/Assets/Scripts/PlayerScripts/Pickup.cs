using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			UIController.Pickups++;
			Destroy (gameObject);
		}
	}
}
