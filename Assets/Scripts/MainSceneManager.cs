using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    public Text scoreText;
    public Text victoryScoreText;
    public Text highscoreText;
    public Text victoryHighscoreText;
    public Text livesText;
    public Text timerText;
    public GameObject scoreNotification;

    public GameObject pauseMenuLayout;
    public GameObject gameOverLayout;
    public GameObject victoryLayout;
    public Text gameOverScoreText;
    public Text gameOverHighScoreText;

    public int maxLives;

    public int totalTime = 5;

    int currentScore = 0;
    int playerLives = 1;

    bool paused = false;

    float passedSeconds = 0;

    static MainSceneManager mainSceneManager = null;

    public static MainSceneManager getMainSceneManager()
    {
        return mainSceneManager;
    }

    void Awake()
    {
        mainSceneManager = this;
    }

    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Enemy"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("PlayerSafe"), true);
        updateCurrentScore();
        updateLives();
        updateHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        checkForPause();
        updateTimer();
    }

    void checkForPause()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!pauseMenuLayout.activeSelf)
            {
                showPauseMenu();
            }
            else
            {
                hidePauseMenu();
            }
        }
    }

    void updateTimer()
    {
        passedSeconds += Time.deltaTime;
        float timeRemaining = totalTime - passedSeconds;
        int h = (int) (timeRemaining/60);
        int s = (int) (timeRemaining%60);

        timerText.text = h + ":" + s;

        if (timeRemaining <= 0)
        {
            gameOver();
        }
    }

    public void addCurrentScore(int a)
    {
        currentScore += a;
        GameObject pecky = GameObject.FindGameObjectWithTag("pecky");

        GameObject scoreNotif = GameObject.Instantiate(scoreNotification, pecky.transform.position,
            pecky.transform.rotation);
        TextMesh textmesh = scoreNotif.GetComponent<TextMesh>();
        textmesh.text = a.ToString();

        StartCoroutine(StaticTools.NotifyCollectible(scoreNotif, 10));
        updateCurrentScore();
    }

    public bool addLife()
    {
        if (playerLives < maxLives)
        {
            playerLives++;
            updateLives();
            return true;
        }

        return false;
    }

    public bool loseLife()
    {
        playerLives--;
        if (playerLives > 0)
        {
            updateLives();
            return true;
        }
        else
        {
            gameOver();
            return false;
        }
    }

    public void setHighScore(int highScore)
    {
        highscoreText.text = highScore.ToString();
    }

    public void updateHighScore()
    {
        int highscore = PlayerPrefs.GetInt("highscore", 0);
        setHighScore(highscore);
    }

    public void updateCurrentScore()
    {
        Debug.Log("Current Score: " + scoreText.text);
        scoreText.text = currentScore.ToString();
    }

    public void updateLives()
    {
        livesText.text = "   X   " + playerLives;
    }

    public void reloadScene()
    {
        Debug.Log("Restart..");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void showPauseMenu()
    {
        Time.timeScale = 0;
        pauseMenuLayout.SetActive(true);
    }

    public void hidePauseMenu()
    {
        pauseMenuLayout.SetActive(false);
        Time.timeScale = 1;
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        gameOverScoreText.text = "Your Score: " + currentScore;

        int highscore = PlayerPrefs.GetInt("highscore", 0);

        if (currentScore > highscore)
        {
            PlayerPrefs.SetInt("highscore", currentScore);
            PlayerPrefs.Save();
        }
        gameOverHighScoreText.text = "High Score: " + highscore;

        gameOverLayout.SetActive(true);
    }

    public void victory()
    {
        Time.timeScale = 0;

        currentScore += (int)(totalTime - passedSeconds);

        victoryScoreText.text = currentScore.ToString();

        int highscore = PlayerPrefs.GetInt("highscore", 0);

        if (currentScore > highscore)
        {
            PlayerPrefs.SetInt("highscore", currentScore);
            PlayerPrefs.Save();
        }

        victoryHighscoreText.text = highscore.ToString();

        victoryLayout.SetActive(true);
    }
}