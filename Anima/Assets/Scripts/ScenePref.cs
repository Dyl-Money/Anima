using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePref : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("Scene1", "Loaded");
        PlayerPrefs.SetString("Scene2", "Unloaded");
        PlayerPrefs.SetString("Scene3", "Unloaded");
        PlayerPrefs.SetString("Scene4", "Unloaded");
        PlayerPrefs.SetString("Scene5", "Unloaded");
    }
}
