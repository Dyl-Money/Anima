using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene2 : MonoBehaviour
{
    //public int scene2;
    public GameObject scene2;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "HeroHDWeapons")
        {
            scene2.SetActive(true);
        //if (PlayerPrefs.GetString("Scene2") == "Unloaded")
        //{
            //SceneManager.LoadSceneAsync(scene2, LoadSceneMode.Additive);
            //PlayerPrefs.SetString("Scene2", "Loaded");
        }
    }
}
