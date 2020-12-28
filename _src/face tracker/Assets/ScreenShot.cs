using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.ScrollSnaps;
public class ScreenShot : MonoBehaviour {
	DirectionalScrollSnap directionSnap;
	bool canTakeScreenshot=true;
	[SerializeField] AudioClip screenShotSound;
	AudioSource audioSource;

	public void Start(){
		directionSnap = GetComponent<DirectionalScrollSnap> ();
		directionSnap.startMovementEvent.AddListener (StopTakingScreenshot);
		directionSnap.targetItemSelected.AddListener (StartTakingScreenshot);
		audioSource = gameObject.AddComponent<AudioSource> ();
	}
			
	public void StopTakingScreenshot(UnityEngine.UI.ScrollSnaps.DirectionalScrollSnap.StartMovementEventType s)
	{
		print ("I am taking screenshot");
	    canTakeScreenshot = false;
    }

	public void StartTakingScreenshot(int n)
	{
		Debug.Log("Now i can take screenshot");
		canTakeScreenshot=true;
	}


	public void TakeScreenShot()
	{
		if (canTakeScreenshot) {
			print ("I am going to take screenshot");
			StartCoroutine (CaptureIt ());
		}
		else {
			print ("sorry!! cannot take screnshot");
		}
    }

	IEnumerator CaptureIt()
	{
		string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string fileName = "Screenshot" + timeStamp + ".png";
		string pathToSave = fileName;
		ScreenCapture.CaptureScreenshot(pathToSave);
		yield return new WaitForEndOfFrame();
		audioSource.PlayOneShot (screenShotSound);
		//Instantiate (blink, new Vector2(0f, 0f), Quaternion.identity);
	}
}
