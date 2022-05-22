using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScene : MonoBehaviour
{
    public AudioClip bambang;
    public AudioClip Ipul;
    public bool x = true;
    
    // Update is called once per frame
    private void Start()
    {
        x = true;
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level 1")
        {
            if (x == true)
            {
                Music.Instance.GetComponentInChildren<AudioSource>().Stop();
                Music.Instance.GetComponentInChildren<AudioSource>().clip = bambang;
                Music.Instance.GetComponentInChildren<AudioSource>().Play();
                x = false;
            }
            
        }
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            if (x == true)
            {
                Music.Instance.GetComponentInChildren<AudioSource>().Stop();
                Music.Instance.GetComponentInChildren<AudioSource>().clip = bambang;
                Music.Instance.GetComponentInChildren<AudioSource>().Play();
                x = false;
            }

        }
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            if (x == true)
            {
                Music.Instance.GetComponentInChildren<AudioSource>().Stop();
                Music.Instance.GetComponentInChildren<AudioSource>().clip = bambang;
                Music.Instance.GetComponentInChildren<AudioSource>().Play();
                x = false;
            }

        }
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (x == false)
            {
                Music.Instance.GetComponentInChildren<AudioSource>().Stop();
                Music.Instance.GetComponentInChildren<AudioSource>().clip = Ipul;
                Music.Instance.GetComponentInChildren<AudioSource>().Play();
                x = true;
            }
        }

    }
}
