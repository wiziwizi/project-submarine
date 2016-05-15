using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	private float tumbleL = 0;
	private float tumbleR = 0;

	private float accel = .2f;

	private float max = 45;

	private Rigidbody _rigidbody;

	// Use this for initialization
	void Awake ()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			tumbleL += accel;
			if (tumbleL > max)
			{
				tumbleL = max;
			}
			if (transform.rotation.z > 45)
			{
				transform.Rotate (transform.rotation.x,transform.rotation.y,45);
			}
		}

		else
		{
			tumbleL -= accel;
			if(tumbleL < 0)
			{
				tumbleL = 0;
			}
		}

		if (!Input.GetKey(KeyCode.A) || !Input.GetKeyUp(KeyCode.LeftArrow))
		{
			tumbleR += accel;

			if (transform.rotation.z < 360 && transform.rotation.z > 46)
			{
				transform.Rotate (transform.rotation.x,transform.rotation.y,0);
			}
		}

		else
		{
			tumbleL -= accel;
			if(tumbleL < 0)
			{
				tumbleL = 0;
			}
		}

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			
		}
		else
		{
			
		}

		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			
		}
		else
		{
			
		}

		if (Input.GetKey(KeyCode.Space))
		{
			
		}
		else
		{
			
		}

		transform.Rotate (Vector3.forward * tumbleL * Time.deltaTime);

		transform.Rotate (Vector3.back * tumbleR * Time.deltaTime);
		//transform.Translate (Vector3.back * speedB * Time.deltaTime);
	}
}
