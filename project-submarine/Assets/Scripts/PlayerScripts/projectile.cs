using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour 
{
	private float _speed = 90f;


	void OnEnable(){
		Invoke ("Remove", 20f);
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
		if(!other.CompareTag ("Shop"))
		{
			Remove ();
		}
	}

	void Remove()
	{
		gameObject.SetActive(false);
	}

	void OnDisable()
	{
		CancelInvoke ();
	}
}

