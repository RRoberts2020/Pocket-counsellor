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

    public void Game1Scene(string Game1)
    {
        SceneManager.LoadScene(Game1);
    }
    public void Game2Scene(string Game2Scene)
    {
        SceneManager.LoadScene(Game2Scene);
    }

    public void Game3Scene(string Game3Scene)
    {
        SceneManager.LoadScene(Game3Scene);
    }

    public void TalkToMeScene(string TalkToMe)
    {
        SceneManager.LoadScene(TalkToMe);
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If you are in Main menu, press android back button and you will quit app
            if (SceneManager.GetActiveScene().buildIndex == 0) 
            {
                Application.Quit();
            }

            // If you are in Take picture, press android back button and you will go back to main menu
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }

            // If you are in View picture, press android back button and you will go back to Take picture
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }

}
