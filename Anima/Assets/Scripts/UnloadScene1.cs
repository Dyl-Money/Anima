using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnloadScene1 : MonoBehaviour
{
    public GameObject scene1;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "HeroHDWeapons")
        {
            scene1.SetActive(false);
        }
    }
}
