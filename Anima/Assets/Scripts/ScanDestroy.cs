using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanDestroy : MonoBehaviour
{
    public GameObject ScanWave;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "CubeScan")
        {
            ScanWave.SetActive(false);

        }
    }
}
