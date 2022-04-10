using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMenu : MonoBehaviour
{
    AudioSource audiox;
    public AudioClip clickSound;
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        audiox = GetComponent<AudioSource>();
        volumeSlider = GameObject.FindGameObjectWithTag("Volume").GetComponent<Slider>();
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audiox.PlayOneShot(clickSound);
        }
        ChangeVolume();
        Save();
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
