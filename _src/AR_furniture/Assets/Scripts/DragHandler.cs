using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using GoogleARCore;
using System.Collections.Generic;
using GoogleARCore.Examples.Common;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public GameObject prefab;
	GameObject hoverPrefab;
	DetectedPlaneGenerator detectedPlaneGenerator;

	List<TrackableHit> trackableHitList=new List<TrackableHit>();

	// Use this for initialization
	void Start () {
		hoverPrefab = Instantiate (prefab);
		//RemoveScriptsFromPrefab ();
		AdjustPrefabAlpha ();
		hoverPrefab.SetActive (false);
		detectedPlaneGenerator = GameObject.FindObjectOfType<DetectedPlaneGenerator> ();
	}

//	void RemoveScriptsFromPrefab() {
//		Component[] components = hoverPrefab.GetComponentsInChildren<TurretTargettingSystem>();
//		foreach (Component component in components) {
//			Destroy (component);
//		}
//	}

	void AdjustPrefabAlpha() {
		MeshRenderer[] meshRenderers = hoverPrefab.GetComponentsInChildren<MeshRenderer> ();
		for (int i = 0; i < meshRenderers.Length; i++) {
			Material mat = meshRenderers [i].material;
			meshRenderers [i].material.color = new Color (mat.color.r, mat.color.g, mat.color.b, 0.5f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void IBeginDragHandler.OnBeginDrag(PointerEventData eventData) {
		// Debug.Log("Beginning drag");
	}

	public void OnDrag(PointerEventData eventData) {
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		Frame.RaycastAll (ray.origin,ray.direction,trackableHitList,Mathf.Infinity,TrackableHitFlags.Default);
		if ( trackableHitList != null && trackableHitList.Count > 0) {
			int terrainCollderQuadIndex = GetTerrainColliderQuadIndex (trackableHitList);
			if (terrainCollderQuadIndex != -1) {
				hoverPrefab.transform.position = trackableHitList[terrainCollderQuadIndex].Pose.position;
				hoverPrefab.SetActive (true);
				// Debug.Log (hits [terrainCollderQuadIndex].point);
			} else {
				hoverPrefab.SetActive (false);
			}
		}
	}

	int GetTerrainColliderQuadIndex(List<TrackableHit> hits) {
		for (int i = 0; i < hits.Count; i++) {
			if (hits [i].Trackable is DetectedPlane) {
				
				return i;
			}
		}

		return -1;
	}

	public void OnEndDrag(PointerEventData eventData) {
		// If the prefab instance is active after dragging stopped, it means
		// it's in the arena so (for now), just drop it in.
		if (hoverPrefab.activeSelf) {
			Instantiate (prefab, hoverPrefab.transform.position, Quaternion.identity);
			detectedPlaneGenerator.DisablePlanes ();
		}

		// Then set it to inactive ready for the next drag!
		hoverPrefab.SetActive (false);
	}
}
