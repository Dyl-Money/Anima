using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanDestroy2 : MonoBehaviour
{
    public GameObject ScanWave;
    void Start()
    {
        PlayerPrefs.SetString("ScanDestroy2", "No");
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "CubeScan")
        {
            ScanWave.SetActive(false);
            PlayerPrefs.SetString("ScanDestroy2", "Yes");
        }
    }
}
