using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour {

	Animator anim;
	RaycastHit hit;
	int count;

	[SerializeField] GameObject cake;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetTrigger ("Emerging");
		count = 0;
	}
	void EnableCake(){
		cake.SetActive (true);
	}
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (0)&&count<1) {
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit)){
				if(hit.collider.gameObject.tag=="GiftBox"){
					anim.SetTrigger("BoxOpen");
					count++;
					Invoke ("EnableCake", 1f);
				}
			}
		}
	}

}
