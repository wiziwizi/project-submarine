using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour 
{
	private float _speed;


	void Start(){
		Destroy(gameObject, 5f);
	}


	void Update() {
		transform.Translate (Vector3.forward * _speed * Time.deltaTime);
	}
	public void SetSpeed(float value)
	{
		_speed = value;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy")) {

			Debug.Log ("hij");


			Destroy(other.gameObject);
			Destroy(gameObject);


		}



	}


}

