using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCountHud : MonoBehaviour {

    private int numberLives;
    private Text lifeValue;

    public LifeCountHud()
    {
        numberLives = 3;
        lifeValue = this.GetComponent<Text>();
    }

    public void setNumberLives(int i)
    {
        numberLives = i;
    }

    public int getNumberLives()
    {
        return numberLives;
    }

    public void setLifeValue()
    {
        lifeValue.text = "   X"+ "   " + numberLives;
    }

	// Update is called once per frame
	void Update () {
        setLifeValue();
	}
}
