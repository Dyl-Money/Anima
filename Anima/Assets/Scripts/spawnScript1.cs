using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript1 : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject Prefab;
    public GameObject Console;
    public GameObject Scanning;
    void Start()
    {
        PlayerPrefs.SetString("DoorOpen1", "Closed");
        PlayerPrefs.SetString("Scan1", "Off");
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Scanning")
        {
            StartCoroutine(Example());
            StartCoroutine(Example2());
            PlayerPrefs.SetString("Scan1", "On");
            Console.GetComponent<vp_PlatformSwitch2>().enabled = false;
            Console.GetComponent<BoxCollider>().enabled = false;
            Console.GetComponent<BoxCollider>().enabled = false;
            Scanning.GetComponent<Scan>().enabled = true;

        }
    }


    IEnumerator Example()
    {
        yield return new WaitForSeconds(5);
        Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
    }
    IEnumerator Example2()
    {
        yield return new WaitForSeconds(6);
        PlayerPrefs.SetString("DoorOpen1", "Open");

    }
}