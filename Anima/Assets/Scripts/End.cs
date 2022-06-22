using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject Hero;
    public GameObject Canvas;
    public GameObject Animation;
    private Animator _animator;
    public GameObject Canvas2;

    void Start()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Text")
        {
            Hero.GetComponent<vp_FPInput>().enabled = false;
            Hero.GetComponent<CharacterController>().enabled = false;
            Hero.GetComponent<DisableCamera>().enabled = true;
            Hero.GetComponent<vp_SimpleCrosshair>().enabled = false;
            Canvas.SetActive(true);
            _animator = Animation.GetComponent<Animator>();
            _animator.SetBool("Fade", true);
            StartCoroutine(Example());
        }
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(3);
        camera1.SetActive(false);
        camera2.SetActive(true);
        Canvas.SetActive(false);
        Canvas2.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    //void OnTriggerExit(Collider col)
    //{
    //if (col.gameObject.name == "Text")
    //{
    //Hero.GetComponent<vp_FPInput>().enabled = true;
    //Hero.GetComponent<CharacterController>().enabled = true;
    //Hero.GetComponent<DisableCamera>().enabled = false;
    //Hero.GetComponent<vp_SimpleCrosshair>().enabled = true;
    //Canvas.SetActive(false);
    //}
    //}
}
