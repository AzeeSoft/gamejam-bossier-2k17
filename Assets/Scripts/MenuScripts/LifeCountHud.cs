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
        lifeValue = GetComponent<Text>();
        lifeValue.text = "" + numberLives + " X";
    }

	// Update is called once per frame
	void Update () {
		
	}
}
