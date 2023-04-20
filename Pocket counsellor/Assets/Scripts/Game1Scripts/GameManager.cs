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

    #region [GameState]

    public int lives;

    public bool gamePlayState;

    public bool gameMenuState;

    public GameObject mainMenuUI;

    public GameObject gameplayElements;

    public GameObject gameOverUI;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        timeRemaining = 300;
        timerIsRunning = false;
        scoreText.text = "Score: " + score.ToString();
    }

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

    public void RestartGame()
    {
        timeRemaining = 300;
        timerIsRunning = true;
        lives = 3;
        score = 0;

        gamePlayState = true;

        gameMenuState = false;

        mainMenuUI.SetActive(false);

        gameplayElements.SetActive(true);

        gameOverUI.SetActive(false);

        StartCoroutine(FindObjectOfType<Spawner>().SpawnFruits());
    }

    public void GameOver()
    {
        gamePlayState = false;

        timeText.text = "00:0" + timeRemaining.ToString();
        timerIsRunning = false;

        endScoreText.text = "Score: " + score.ToString();

        mainMenuUI.SetActive(false);

        gameplayElements.SetActive(false);

        gameOverUI.SetActive(true);
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
