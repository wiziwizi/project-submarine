using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public float bulletSpeed;
	public Transform muzzle;
	public projectile Projectile;
	public float shootRate;
	public AudioClip destroysound;

	private AudioSource audioSource;
	private float nextFireTime;

	void Start()
	{
		nextFireTime = 0;
		audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{

		if (Input.GetMouseButton (0) && (Time.time >= nextFireTime)) {
			Shoot ();
		}
	}

	void FixedUpdate()
	{
		Plane plane = new Plane (Vector3.up, Vector3.zero);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float distance;
		if (plane.Raycast (ray, out distance))
		{
			Vector3 point = ray.GetPoint (distance);
			transform.LookAt(point);
			//Debug.Log (point);
		}

	}
	private void Shoot()
	{
		GameObject obj = NewObjectPooler.current.GetPooledObject ();

		if (obj == null) return;
		obj.transform.position = muzzle.position;
		obj.transform.rotation = muzzle.rotation;
		obj.SetActive(true);
		nextFireTime = Time.time + shootRate;
		audioSource.Play ();
	}

}





