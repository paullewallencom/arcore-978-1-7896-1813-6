using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class ObjectSelection : MonoBehaviour {

	RaycastHit hit;
	// Use this for initialization
	void Start () {
		
	}
	public void DeselectAll(){
		foreach(GameObject g in GameObject.FindGameObjectsWithTag("Furniture"))
			{
			g.GetComponent<LeanTranslate> ().CanTranslate = false;
			g.GetComponent<LeanRotateCustomAxis> ().CanRotate = false;
		     }
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit)) {
				if (hit.collider.gameObject.tag == "Furniture") {
					DeselectAll ();
					hit.collider.gameObject.GetComponent<LeanTranslate> ().CanTranslate = true;
					hit.collider.gameObject.GetComponent<LeanRotateCustomAxis> ().CanRotate = true;
				}
			}
		}
	}
}
