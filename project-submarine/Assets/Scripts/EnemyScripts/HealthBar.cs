using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	// Use this for initialization
	public Transform Camera;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (Camera);
	
	}
}
