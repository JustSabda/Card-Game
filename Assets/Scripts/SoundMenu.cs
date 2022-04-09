using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenu : MonoBehaviour
{
    AudioSource audiox;
    public AudioClip clickSound;
    // Start is called before the first frame update
    void Start()
    {
        audiox = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audiox.PlayOneShot(clickSound);
        }
    }
}
