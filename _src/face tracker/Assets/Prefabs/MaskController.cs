using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.ScrollSnaps;

public class MaskController : MonoBehaviour {
	[SerializeField]
	DirectionalScrollSnap directionalSnap;
	[SerializeField]
	GameObject[] masksList;
	// Use this for initialization
	void Start () {
		directionalSnap.targetItemSelected.AddListener (MaskManager);
	}
	
	public void MaskManager(int n){
		foreach (GameObject go in masksList) {
			go.SetActive (false);

		}
		masksList [n].SetActive (true);
	}

}
