using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour {

	[SerializeField]
	GameObject UI;

	public void TakeAShot()
	{
		UI.SetActive(false);
		StartCoroutine ("CaptureIt");
	}

	IEnumerator CaptureIt()
	{
		string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string fileName = "Screenshot" + timeStamp + ".png";
		string pathToSave = fileName;
		ScreenCapture.CaptureScreenshot(pathToSave);
		yield return new WaitForEndOfFrame();
		Rect resource_background_Rect = new Rect(960, 400, 500, 30);
		GUI.Box(resource_background_Rect, "You have taken a photo");
		UI.SetActive(true);
	}

}
