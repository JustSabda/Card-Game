using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScene : MonoBehaviour
{
    public AudioClip bambang;
    public AudioClip Ipul;
    public AudioClip slamet;
    public AudioClip parjo;
    public bool x = true;
    public bool y;
    
    // Update is called once per frame
    private void Start()
    {
        x = true;
        y = true;
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level 1")
        {
            if (x == true && y == false)
            {
                Music.Instance.GetComponentInChildren<AudioSource>().Stop();
                Music.Instance.GetComponentInChildren<AudioSource>().clip = bambang;
                Music.Instance.GetComponentInChildren<AudioSource>().Play();
                x = false;
                y = true;
            }
            
        }
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            if (x == true && y == false)
            {
                Music.Instance.GetComponentInChildren<AudioSource>().Stop();
                Music.Instance.GetComponentInChildren<AudioSource>().clip = bambang;
                Music.Instance.GetComponentInChildren<AudioSource>().Play();
                x = false;
                y = true;
            }

        }
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            if (x == true && y == false)
            {
                Music.Instance.GetComponentInChildren<AudioSource>().Stop();
                Music.Instance.GetComponentInChildren<AudioSource>().clip = bambang;
                Music.Instance.GetComponentInChildren<AudioSource>().Play();
                x = false;
                y = true;
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
                y = true;
            }
        }
        if (SceneManager.GetActiveScene().name == "Prolog")
        {
            if (x == true && y == true)
            {
                Music.Instance.GetComponentInChildren<AudioSource>().Stop();
                Music.Instance.GetComponentInChildren<AudioSource>().clip = slamet;
                Music.Instance.GetComponentInChildren<AudioSource>().Play();
                x = true;
                y = false;
            }
        }
        if (SceneManager.GetActiveScene().name == "Epilog")
        {
            if (x == true && y == true)
            {
                Music.Instance.GetComponentInChildren<AudioSource>().Stop();
                Music.Instance.GetComponentInChildren<AudioSource>().clip = parjo;
                Music.Instance.GetComponentInChildren<AudioSource>().Play();
                x = true;
                y = false;
            }
        }

    }
}
