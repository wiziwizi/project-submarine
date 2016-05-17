using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	private float tumbleL = 0;
	private float tumbleR = 0;
	private float accel = 0.4f;

	private float maxL = 30;
	private float maxR = -30;

	private Rigidbody _rigidbody;
	private float xRot;
	private float yRot;

	// Use this for initialization
	void Awake ()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		xRot = transform.rotation.x;
		yRot = transform.rotation.y;

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			tumbleL += accel;
			if (tumbleL > maxL)
			{
				tumbleL = maxL;
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
			tumbleR -= accel;
			if (tumbleR < maxR)
			{
				tumbleR = maxR;
			}
		}

		else
		{
			tumbleR += accel;
			if(tumbleR > 0)
			{
				tumbleR = 0;
			}
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

		transform.localRotation = Quaternion.Euler (Vector3.forward * (tumbleL +tumbleR));

		//transform.Rotate (Vector3.back * tumbleR * Time.deltaTime);

		//transform.rotation = Quaternion.Euler(new Vector3(xRot, yRot, Mathf.Clamp (Time.time, 0, 20)));
	}
}
