using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanDestroy1 : MonoBehaviour
{
    public GameObject ScanWave;
    void Start()
    {
        PlayerPrefs.SetString("ScanDestroy1", "No");
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "CubeScan")
        {
            ScanWave.SetActive(false);
            PlayerPrefs.SetString("ScanDestroy1", "Yes");
        }
    }
}
