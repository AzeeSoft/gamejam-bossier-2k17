using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class PointsInfo : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyTimely());
    }

    IEnumerator DestroyTimely()
    {
        yield return new WaitForSecondsRealtime(1);

        Destroy(gameObject.transform.parent.gameObject);
        Destroy(gameObject);
    } 
}
