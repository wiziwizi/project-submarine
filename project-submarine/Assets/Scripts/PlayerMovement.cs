using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speedF = 0f; //speed forward.
	public float speedB = 0f; //speed forward.
	public float speedU = 0f; //speed forward.
	public float speedD = 0f; //speed forward.
	public float rotationR = 0f; //speed rotatie Rechts.
	public float rotationL = 0f; //speed rotatie Links.
	public float max = 20f; //max speed forward.
	public float maxB = 10f; //max speed back.
	public float maxR = 40f; //max speed rotatie.

	public float accel = .2f; //acceleratie Algemeen.
	public float accelR = 0.5f; //acceleratie rotatie.
	public float accelB = .2f; //acceleratie back.
	private Rigidbody _rigidbody;




	void Awake()
	{
		//reference with rigidbody
		_rigidbody = GetComponent<Rigidbody>();

	}
	void Update()
	{
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			speedF += accel;

			if (speedF > max)
			{
				speedF = max;
			}
		}
		else
		{
			speedF -= accel;

			if (speedF < 0)
			{
				speedF = 0;
			}
		}
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			rotationL += accelR; 

			if (rotationL > maxR)
			{
				rotationL = maxR;
			}
		}
		else
		{
			rotationL -= accelR;

			if (rotationL < 0)
			{
				rotationL = 0;
			}
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			rotationR += accelR; 

			if (rotationR > maxR)
			{
				rotationR = maxR;
			}
		}
		else
		{
			rotationR -= accelR;

			if (rotationR < 0)
			{
				rotationR = 0;
			}
		}


		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))// achteruit
		{
			speedB += accelB;

			if (speedB > maxB)
			{
				speedB = maxB;
			}
		}
		else
		{
			speedB -= accelB;

			if (speedB < 0)
			{
				speedB = 0;
			}
		}

		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			speedD += accel;

			if (speedD > maxB)
			{
				speedD = maxB;
			}
		}
		else
		{
			speedD -= accel;

			if (speedD < 0)
			{
				speedD = 0;
			}
		}

		if (Input.GetKey(KeyCode.Space))
		{
			speedU += accel;

			if (speedU > maxB)
			{
				speedU = maxB;
			}
		}
		else
		{
			speedU -= accel;

			if (speedU < 0)
			{
				speedU = 0;
			}
		}

		transform.Translate (Vector3.forward * speedF * Time.deltaTime);
		transform.Translate (Vector3.back * speedB * Time.deltaTime);
		transform.Translate (Vector3.down * speedD * Time.deltaTime);
		transform.Translate (Vector3.up * speedU * Time.deltaTime);
		transform.Rotate (Vector3.down * rotationL * Time.deltaTime);
		transform.Rotate (Vector3.up * rotationR * Time.deltaTime);

	}

}
