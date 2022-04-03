using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource Asource;
    // Start is called before the first frame update
    void Start()
    {
        Asource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.currentSelectedGameObject)
            {
                PlaySound(clickSound);
            }
        }
    }
    public void PlaySound(AudioClip Aclip)
    {
        Asource.PlayOneShot(Aclip);
    }
}
