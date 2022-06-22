using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    public GameObject lightSource;
    public GameObject lightOn;
    public GameObject lightOff;

    void Start()
    {
        StartCoroutine(Example2());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(2);
        lightSource.SetActive(true);
        lightOn.SetActive(true);
        lightOff.SetActive(false);
        StartCoroutine(Example2());
    }
    IEnumerator Example2()
    {
        yield return new WaitForSeconds(2);
        lightSource.SetActive(false);
        lightOff.SetActive(true);
        lightOn.SetActive(false);
        StartCoroutine(Example());
    }
}
