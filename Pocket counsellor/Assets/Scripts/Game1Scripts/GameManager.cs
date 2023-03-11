using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    #region [Score]

    public TextMeshProUGUI scoreText;

    private int score;

    public bool isSliced;

    #endregion

    #region [Timer]

    public float timeRemaining;
    public bool timerIsRunning;
    public TextMeshProUGUI timeText;

    #endregion

    #region [GameState]

    public int lives;

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

        if (lives == 0 || timeRemaining == 0)
        {
            GameOver();
        }

        if (isSliced == true)
        {
            AddPoint();
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
                GameOver();
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    public void AddPoint()
    {
        score++;
        isSliced = false;
    }

    public void RestartGame()
    {

        mainMenuUI.SetActive(false);

        gameplayElements.SetActive(true);

        gameOverUI.SetActive(false);

        timeRemaining = 300;
        timerIsRunning = true;
        lives = 3;
        score = 0;
    }

    public void GameOver()
    {

        timeText.text = "00:0" + timeRemaining.ToString();
        timerIsRunning = false;

        mainMenuUI.SetActive(false);

        gameplayElements.SetActive(false);

        gameOverUI.SetActive(true);
    }



    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
