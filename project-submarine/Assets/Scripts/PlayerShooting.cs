using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public float bulletSpeed;
	public Transform muzzle;
	public projectile Projectile;
	public float shootRate;
	private AudioSource audioSource;
	public AudioClip destroysound;




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
		projectile bullet = Instantiate (Projectile, muzzle.position, muzzle.rotation) as projectile;
		bullet.SetSpeed (bulletSpeed);
		nextFireTime = Time.time + shootRate;
		print ("ron");
		audioSource.Play ();
	}

}





