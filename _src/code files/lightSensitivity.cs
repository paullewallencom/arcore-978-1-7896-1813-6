using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class lightSensitivity : MonoBehaviour {

	float minThresholdValue=0.4f;
	Animator anim;
	[SerializeField]
	GameObject lightPrefab;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		lightPrefab.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Frame.LightEstimate.PixelIntensity < minThresholdValue) {
			//dark
			lightPrefab.SetActive (true);
			anim.SetTrigger ("animate");
		} else {
			lightPrefab.SetActive (false);
			anim.SetTrigger ("idle");
		}
	}
}
