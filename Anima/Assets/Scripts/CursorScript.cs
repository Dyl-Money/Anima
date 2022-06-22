using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        transform.SetAsLastSibling();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;

    }
}
