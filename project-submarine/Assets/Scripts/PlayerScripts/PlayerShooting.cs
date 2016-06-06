using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public float bulletSpeed;
	public Transform muzzle;
	public projectile Projectile;
	public float shootRate;


	RaycastHit hit;

	private AudioSource audioSource;
	private float nextFireTime;

	public GameObject particles;
	private ParticleSystem particleEmission;

	void Start()
	{
		hit = new RaycastHit(); 
		nextFireTime = 0;
		audioSource = GetComponent<AudioSource>();
		particleEmission = particles.GetComponent<ParticleSystem> ();
	}

	void Update()
	{
		if (Pauze.Pause == false)
		{
			if (Input.GetMouseButton (0) && (Time.time >= nextFireTime))
			{
				Shoot ();
				particleEmission.Play ();
			}
			if (!Input.GetMouseButton (0))
			{
				particleEmission.Stop ();
			}
		}
	}

	void FixedUpdate()
	{
		//Plane plane = new Plane (Vector3.up, Vector3.zero);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float distance;
		if(Physics.Raycast(ray, out hit, 400.0f))
		{
			transform.LookAt(hit.point);
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