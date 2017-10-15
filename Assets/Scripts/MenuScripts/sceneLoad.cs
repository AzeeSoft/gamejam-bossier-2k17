using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneLoad : MonoBehaviour {
    private GameObject[] sound;

    public void LoadScene(int level)
    {
        sound= GameObject.FindGameObjectsWithTag("menuMusic");
        if (level == 5)
            sound[0].SetActive(false);
        Application.LoadLevel(level);
    }
}
