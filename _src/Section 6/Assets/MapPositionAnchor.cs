using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using  Mapbox.Unity.Map;
using Mapbox.Examples;
namespace GoogleARCore.Examples.HelloAR
{

public class MapPositionAnchor : MonoBehaviour {

//		controller control;
//		LocationProviderFactory locationProviderFactory;
//		AbstractMap abstractMap;
//		void OnEnable(){
//			locationProviderFactory.mapManager = abstractMap;
//		}
	// Use this for initialization
	void Awake () {
//			control = GameObject.FindObjectOfType<controller> ().GetComponent<controller> ();
//			locationProviderFactory = GameObject.FindObjectOfType<LocationProviderFactory> ();
//			abstractMap=GetComponent<AbstractMap> ();
			transform.position=new Vector3(0,8,0);
	}
	void OnDisable(){
//			control.MapPrefab = null;
//			locationProviderFactory.mapManager = null;
	}
	// Update is called once per frame
	void Update () {
		Touch touch;
		if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
		{
			return;
		}

		// Raycast against the location the player touched to search for planes.
		TrackableHit hit;
		TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
			TrackableHitFlags.FeaturePointWithSurfaceNormal;

		if (Frame.Raycast (touch.position.x, touch.position.y, raycastFilter, out hit)) {
			// Use hit pose and camera pose to check if hittest is from the
		
		
				// Create an anchor to allow ARCore to track the hitpoint as understanding of the physical
				// world evolves.
				var anchor = hit.Trackable.CreateAnchor (hit.Pose);
			//and change our map position to anchor point
			transform.position=anchor.transform.position;
				
			}

		}	}
}
