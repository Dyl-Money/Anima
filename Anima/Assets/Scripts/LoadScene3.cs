using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene3 : MonoBehaviour
{
    //public int scene3;
    public GameObject scene3;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "HeroHDWeapons")
        {
            scene3.SetActive(true);
        //if (PlayerPrefs.GetString("Scene3") == "Unloaded")
        //{
            //SceneManager.LoadSceneAsync(scene3, LoadSceneMode.Additive);
            //PlayerPrefs.SetString("Scene3", "Loaded");
        }
    }
}
