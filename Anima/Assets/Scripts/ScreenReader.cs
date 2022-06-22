using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenReader : MonoBehaviour
{
    public GameObject screen;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject CameraScreen;
    public GameObject Hero;

    void Start()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
    }

        void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Text")
        {
            CameraScreen.SetActive(true);
            Hero.GetComponent<vp_FPInput>().enabled = false;
            Hero.GetComponent<CharacterController>().enabled = false;
            Hero.GetComponent<DisableCamera>().enabled = true;
            Hero.GetComponent<vp_SimpleCrosshair>().enabled = false;
            camera1.SetActive(false);
            camera2.SetActive(true);
            screen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (Input.GetMouseButton(1))
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Text")
        {
            CameraScreen.SetActive(false);
            Hero.GetComponent<vp_FPInput>().enabled = true;
            Hero.GetComponent<CharacterController>().enabled = true;
            Hero.GetComponent<DisableCamera>().enabled = false;
            Hero.GetComponent<vp_SimpleCrosshair>().enabled = true;
            camera1.SetActive(true);
            camera2.SetActive(false);
            screen.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
