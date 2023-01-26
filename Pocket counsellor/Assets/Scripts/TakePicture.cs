using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakePicture : MonoBehaviour
{
    static WebCamTexture backCam;

    void Start()
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

    public void TakePhoto()
    {
        Debug.Log("You Have taken picture");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
