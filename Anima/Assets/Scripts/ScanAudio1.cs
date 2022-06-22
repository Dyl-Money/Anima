using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanAudio1 : MonoBehaviour
{
    public AudioClip MusicClip;
    public AudioSource MusicSource;
    // Start is called before the first frame update
    void Start()
    {
        //MusicSource.clip = MusicClip;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString("Scan1") == "On")
            {
            MusicSource.PlayOneShot(MusicClip, 1);
            //MusicSource.Stop();
            StartCoroutine(Example());
            }
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
        //MusicSource.Play();
    }
}
