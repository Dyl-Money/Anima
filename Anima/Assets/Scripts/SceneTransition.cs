using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void SceneStart()
    {
        SceneManager.LoadScene(1);
    }
    public void SceneEnd()
    {
        SceneManager.LoadScene(0);
    }
}
