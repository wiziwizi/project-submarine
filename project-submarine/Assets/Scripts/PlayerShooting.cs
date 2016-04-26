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
	private void Shoot()
	{
		projectile bullet = Instantiate (Projectile, muzzle.position, muzzle.rotation) as projectile;
		bullet.SetSpeed (bulletSpeed);
		nextFireTime = Time.time + shootRate;




	}

}





