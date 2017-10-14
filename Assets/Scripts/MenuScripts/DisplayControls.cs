using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayControls : MonoBehaviour {


    public void Awake()
    {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("menuMusic");
            if (objs.Length > 1)
                Destroy(this.gameObject);
            DontDestroyOnLoad(this.gameObject);
    }
}
