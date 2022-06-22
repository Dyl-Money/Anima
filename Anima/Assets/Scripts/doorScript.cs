using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    private Animator _animator;
    public bool door1 = false;
    private float panel;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        door1 = _animator.GetBool("character_nearby");
        PlayerPrefs.GetString("DoorOpen");


    }

    void Update()
    {
        if (PlayerPrefs.GetString("DoorOpen") == "Open")
        {
            _animator.SetBool("character_nearby", true);
            
        }
    }
}
