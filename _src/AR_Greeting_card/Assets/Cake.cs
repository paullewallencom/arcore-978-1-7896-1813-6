using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour {

	AudioSource source;

	public float speed;
	// Use this for initialization
	void Start () 
	   {
		source = GetComponent<AudioSource> ();
		source.Play ();
		}

	void OnDisable()
	{
		source.Stop ();	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, speed, 0));
	}
}
