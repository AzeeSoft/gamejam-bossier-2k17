using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    public GameObject scoreNotification;

    public GameObject pauseMenuLayout;
    public GameObject gameOverLayout;
    public Text gameOverScoreText;

    public int maxLives ;

    int currentScore = 0;
    int playerLives = 1;

    bool paused = false;

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
        updateCurrentScore();
        updateLives();
    }

    // Update is called once per frame
    void Update()
    {
        checkForPause();
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

    public void addCurrentScore(int a)
    {
        currentScore += a;
        GameObject pecky = GameObject.FindGameObjectWithTag("pecky");

        GameObject scoreNotif = GameObject.Instantiate(scoreNotification, pecky.transform.position, pecky.transform.rotation);
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
        gameOverLayout.SetActive(true);
    }
}