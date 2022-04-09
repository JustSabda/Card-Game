using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public static MenuManager Instance;
    [SerializeField] private GameObject _selecetedHeroObject;
    [SerializeField] private GameObject _skinCare1;
    [SerializeField] private GameObject _skinCare2;

    public GameObject pauseMenu;
    public GameObject Tutorial;
    void Start()
    {
        TutorialBtn();
    }
    void Update()
    {

        //ChangeVolume();
    }
    private void Awake()
    {
        Instance = this;
    }
    public void ShowTileInfo(ThisCard cardName)
    {
        _selecetedHeroObject.GetComponentInChildren<Image>().sprite = cardName.thisSpriteCard;
        _selecetedHeroObject.SetActive(true);
        _skinCare1.SetActive(true);
        _skinCare2.SetActive(false);
    }
    public void ShowTileInfo2(AiCardToHand cardName)
    {
        _selecetedHeroObject.GetComponentInChildren<Image>().sprite = cardName.thisSpriteCard;
        _selecetedHeroObject.SetActive(true);
        _skinCare1.SetActive(false);
        _skinCare2.SetActive(true);
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Tutorial.SetActive(false);
        Time.timeScale = 1f;
    }
    public void TutorialBtn()
    {
        Tutorial.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
