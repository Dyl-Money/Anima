using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool on = false;
    public GameObject playerLight;
    public AudioSource sound;

    void Start()
    {
        GameObject.Find("PlayerLight");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            on = !on;
            sound.Play();
        if (on)
            //GameObject.Find("PlayerLight").SetActive(true);
            playerLight.SetActive(true);
        
        if (!on)
            //GameObject.Find("PlayerLight").SetActive(false);
            playerLight.SetActive(false);
    }
}
