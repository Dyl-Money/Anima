using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript2 : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject Prefab;
    public GameObject Console;
    public GameObject Scanning;
    public GameObject door;

    void Start()
    {
        PlayerPrefs.SetString("DoorOpen2", "Closed");
        PlayerPrefs.SetString("Scan2", "Off");
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Scanning")
        {
            StartCoroutine(Example());
            StartCoroutine(Example2());
            PlayerPrefs.SetString("Scan2", "On");
            Console.GetComponent<vp_PlatformSwitch2>().enabled = false;
            Console.GetComponent<BoxCollider>().enabled = false;
            Console.GetComponent<BoxCollider>().enabled = false;
            Scanning.GetComponent<Scan>().enabled = true;
            door.GetComponent<Animator>().enabled = true;
            door.GetComponent<vp_PlatformSwitch>().enabled = false;
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
        PlayerPrefs.SetString("DoorOpen2", "Open");
        door.GetComponent<Animator>().enabled = false;
        door.GetComponent<vp_PlatformSwitch>().enabled = true;
    }
}