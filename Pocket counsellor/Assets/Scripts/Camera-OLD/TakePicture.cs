using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;


public class TakePicture : MonoBehaviour
{
    static WebCamTexture backCam;

    void Update()
    {
        if (backCam == null)
        {
            backCam = new WebCamTexture();

            Debug.Log("Got WebCamTexture");
        }
            
        GetComponent<Renderer>().material.mainTexture = backCam;

        if (!backCam.isPlaying)
        {
            backCam.Play();
            Debug.Log("Camera should work");
        }
            
    }

    public void TakePhotoButtonTrigger()
    {
        StartCoroutine(TakePhoto());
    }

    IEnumerator TakePhoto()
    {

        // NOTE - you almost certainly have to do this here:

        yield return new WaitForEndOfFrame();

        Texture2D photo = new Texture2D(backCam.width, backCam.height);
        photo.SetPixels(backCam.GetPixels());
        photo.Apply();

        //Encode to a PNG
        byte[] bytes = photo.EncodeToPNG();
        string timeStamp = System.DateTime.Now.ToString("ss-mm-HH-dd-MM-yyyy");
        //Write out the PNG. Of course you have to substitute your_path for something sensible
        File.WriteAllBytes(Application.dataPath + "/PC-Photos/" + timeStamp + "-photo.png", bytes);

        Debug.Log("Photo was saved");
    }

}
