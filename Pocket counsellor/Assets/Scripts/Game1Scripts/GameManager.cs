using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public AudioSource sliceSFX;

    #region [Score]

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI endScoreText;

    public int score;

    #endregion

    #region [Timer]

    public float timeRemaining;
    public bool timerIsRunning;
    public TextMeshProUGUI timeText;

    #endregion

    #region [Lives]

    public GameObject liveParentObjectP1;

    public GameObject liveParentObjectP2;

    public TextMeshProUGUI liveText;

    public TextMeshProUGUI endliveText;

    public int lives;

    public GameObject KillTrigger;

    #endregion


    #region [GameState]

    public bool gamePlayState;

    public bool gameMenuState;

    public GameObject mainMenuUI;

    public GameObject difficultyUI;

    public GameObject gameplayElements;

    public GameObject gameOverUI;

    #endregion


    // Update is called once per frame
    void Update()
    {

        if (lives == 0 || timeRemaining == 0 && gameMenuState == false)
        {
            GameOver();
        }

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    public void AddPoint()
    {
        sliceSFX.Stop();
        sliceSFX.Play();
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void LoseLive()
    {
        lives -= 1;
        liveText.text = "Lives: " + lives.ToString();
    }

    public void DifficultyHard()
    {
        KillTrigger.SetActive(true);
        liveParentObjectP1.SetActive(true);
        liveParentObjectP2.SetActive(true);
    }

    public void DifficultyEasy()
    {
        KillTrigger.SetActive(false);
        liveParentObjectP1.SetActive(false);
        liveParentObjectP2.SetActive(false);
    }

    public void RestartGame()
    {
        timeRemaining = 300;
        timerIsRunning = true;
        lives = 10;
        score = 0;

        scoreText.text = "Score: " + score.ToString();

        liveText.text = "Lives: " + lives.ToString();

        gamePlayState = true;

        gameMenuState = false;

        difficultyUI.SetActive(false);

        gameplayElements.SetActive(true);

        gameOverUI.SetActive(false);

        StartCoroutine(FindObjectOfType<Spawner>().SpawnFruits());
    }

    public void GameOver()
    {
        gamePlayState = false;

        DisplayTime(timeRemaining);
        //timeText.text = "00:0" + timeRemaining.ToString();
        timerIsRunning = false;

        endScoreText.text = "Your Score: " + score.ToString();

        endliveText.text = "Lives Remaining: " + lives.ToString();

        mainMenuUI.SetActive(false);

        gameplayElements.SetActive(false);

        gameOverUI.SetActive(true);

        timeRemaining = 300;
        lives = 3;
        score = 0;

    }

    public void ReturnToMenu()
    {
        gameMenuState = true;

        mainMenuUI.SetActive(true);

        gameplayElements.SetActive(false);

        gameOverUI.SetActive(false);
    }



    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}