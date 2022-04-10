using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManage : MonoBehaviour
{
    public GameObject ObjectMusic;
    [SerializeField] Slider volumeSlider;
    private AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetFloat("musicVolume", 1);
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume",1);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
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
