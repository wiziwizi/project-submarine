using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	private Rigidbody _rigidbody;
	private float Xinput;
	private float Yinput;



	void Awake()
	{
		//reference with rigidbody
		_rigidbody = GetComponent<Rigidbody>();

	}
	void Update()
	{
		Xinput = Input.GetAxis ("Horizontal");
		Yinput = Input.GetAxis("Vertical");

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Plane plane = new Plane (Vector3.up, Vector3.zero);
		float distance;
		if (plane.Raycast (ray, out distance)) {
			Vector3 Point = ray.GetPoint (distance);
			Vector3 adjustedHeightPoint = new Vector3 (Point.x, transform.position.y, Point.z);
			transform.LookAt (adjustedHeightPoint);
		}

	}
	void FixedUpdate()
	{
		Vector3 direction = new Vector3 (Xinput, 0f, Yinput);
		Vector3 velocity = direction * speed * Time.fixedDeltaTime;
		_rigidbody.MovePosition(_rigidbody.position + velocity);

	}

}
