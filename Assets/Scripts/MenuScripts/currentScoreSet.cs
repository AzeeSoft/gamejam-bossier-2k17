using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currentScoreSet : MonoBehaviour {

    private int score;
    private Text scoreLabel;

    public currentScoreSet()
    {
        score = 0;
        scoreLabel = this.GetComponent<Text>();
    }

    public void setScore(int i)
    {
        score = i;
    }

    public int getScore()
    {
        return score;
    }

    public void setScoreLabel()
    {
        if (score == 0)
            scoreLabel.text = "00000";
        else
            scoreLabel.text = "" + score;
    }
	// Update is called once per frame
	void Update () {
        setScoreLabel();
	}
}
