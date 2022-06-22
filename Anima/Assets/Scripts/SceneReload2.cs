using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneReload2 : MonoBehaviour
{
    public GameObject Scan;
    public Transform Spawnpoint;
    public GameObject Prefab;
    public GameObject Console;
    public GameObject Scanning;
    public GameObject Trigger2;
    public GameObject Text;
    void Start()
    {
        if (PlayerPrefs.GetString("ScanDestroy2") == "Yes")
        {
            Scan.SetActive(false);
            Trigger2.SetActive(false);
            Console.GetComponent<vp_PlatformSwitch2>().enabled = false;
            Console.GetComponent<BoxCollider>().enabled = false;
            Console.GetComponent<BoxCollider>().enabled = false;
            Scanning.GetComponent<Scan>().enabled = true;
            PlayerPrefs.SetString("DoorOpen2", "Open");
            Text.SetActive(false);
        }
    }

    void Update()
    {
        if (PlayerPrefs.GetString("ScanDestroy2") == "Yes")
        {
            Scan.SetActive(false);
            Trigger2.SetActive(false);
            Console.GetComponent<vp_PlatformSwitch2>().enabled = false;
            Console.GetComponent<BoxCollider>().enabled = false;
            Console.GetComponent<BoxCollider>().enabled = false;
            Scanning.GetComponent<Scan>().enabled = true;
            PlayerPrefs.SetString("DoorOpen2", "Open");
            Text.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "HeroHDWeapons")
        {
            PlayerPrefs.SetString("ScanDestroy2", "Yes");
        }
    }
}