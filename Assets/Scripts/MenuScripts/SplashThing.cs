using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashThing : MonoBehaviour {

    public float delayTime = 2;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(delayTime);
        Application.LoadLevel(2);
    }
}
