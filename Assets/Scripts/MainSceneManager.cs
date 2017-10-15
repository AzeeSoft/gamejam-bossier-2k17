using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;

    int currentScore = 0;
    int playerLives = 3;

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
    }

    public void addCurrentScore(int a)
    {
        currentScore += a;
        updateCurrentScore();
    }

    public void loseLife()
    {
        playerLives--;
        updateLives();
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
}