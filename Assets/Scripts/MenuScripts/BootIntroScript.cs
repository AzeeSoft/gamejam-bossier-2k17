using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BootIntroScript : MonoBehaviour {
    public float delayTime = 5.76f;
    public Canvas BootCanvas;
    public GameObject BootTextPrefab;
    private GameObject BootTextObject;
	// Use this for initialization
	IEnumerator Start () {
        Vector3 oldTransform = BootTextPrefab.transform.position;
        BootTextPrefab.transform.position = new Vector3(1000000, 1000000, 0);
        yield return new WaitForSeconds(delayTime);
        BootTextPrefab.transform.position = oldTransform;
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter was pressed...");
            Application.LoadLevel(1);
        }
	}
}
