using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private GameObject _player;
	private bool playerHit;

	private float BackSpeed;
	private float ForwardSpeed;
	private Rigidbody rigidbody;
	private AudioSource clip;

	public float Damage;
	public float MoveSpeed;

	// Use this for initialization
	void Awake () 
	{
		clip = GetComponent<AudioSource> ();
		rigidbody = GetComponent<Rigidbody> ();
		_player = GameObject.FindGameObjectWithTag ("Player");
		BackSpeed = -MoveSpeed;
		ForwardSpeed = MoveSpeed;
	}

	// Update is called once per frame
	void Update()
	{
		transform.LookAt (_player.transform.position);
		Debug.Log (playerHit);
		if (playerHit == true)
		{
			clip.Play ();
			Debug.Log ("Check2: "+playerHit);
			MoveSpeed = BackSpeed;
			PlayerHealth.health -= Damage;
			playerHit = false;
			Invoke ("Reverse", 0.2f);
		}
	}

	void Reverse()
	{
		Debug.Log ("Check3: "+playerHit);
		MoveSpeed = ForwardSpeed;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			
			playerHit = true;
			Debug.Log ("Check4: "+playerHit);
		}
		if (other.gameObject.tag == "projectile")
		{
			MoveSpeed = MoveSpeed / 2;
			Invoke ("Reverse", 0.2f);
		}
	}

	void FixedUpdate()
	{
		if (Pauze.Pause == false)
		{
			rigidbody.MovePosition (rigidbody.position + (transform.TransformDirection (Vector3.forward) * MoveSpeed * Time.fixedDeltaTime));
		}
	}
}