using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSystem : MonoBehaviour
{

    public void MainScene(string MainScene)
    {
        SceneManager.LoadScene(MainScene);
    }

    public void TakePicture(string TakePicture)
    {
        SceneManager.LoadScene(TakePicture);
    }

    public void ViewPicture(string ViewPicture)
    {
        SceneManager.LoadScene(ViewPicture);
    }

    public void QuitGame()
    {
        Application.Quit();
    } 

}
