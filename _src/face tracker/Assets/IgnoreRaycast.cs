using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.ScrollSnaps;

public class IgnoreRaycast : MonoBehaviour {
	DirectionalScrollSnap directionalSnap;
	public CanvasGroup[] canvasList;
	// Use this for initialization
	void Start () {
		canvasList = GetComponentsInChildren<CanvasGroup> ();
		directionalSnap = GetComponentInParent<DirectionalScrollSnap> ();
		directionalSnap.targetItemSelected.AddListener (IgnoreElementRaycast);
	}
	public void IgnoreElementRaycast(int n){
		foreach (CanvasGroup c in canvasList) {
			c.blocksRaycasts = true;
		}
		canvasList [n].blocksRaycasts = false;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
