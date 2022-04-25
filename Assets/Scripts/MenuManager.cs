using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public static MenuManager Instance;
    [SerializeField] private GameObject _selecetedHeroObject;
    [SerializeField] private GameObject _skinCare1;
    [SerializeField] private GameObject _skinCare2;

    public GameObject pauseMenu;
    public GameObject Tutorial, Tutorial1, Tutorial2, Tutorial3, Tutorial4, Tutorial5;
    void Start()
    {
        
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
        //Tutorial.SetActive(false);
        Tutorial1.SetActive(false);
        Tutorial2.SetActive(false);
        Tutorial3.SetActive(false);
        Tutorial4.SetActive(false);
        Tutorial5.SetActive(false);
        Time.timeScale = 1f;
    }
    public void TutorialBtn1()
    {
        //Tutorial.SetActive(true);
        Tutorial1.SetActive(true);
        Tutorial2.SetActive(false);
        Tutorial3.SetActive(false);
        Tutorial4.SetActive(false);
        Tutorial5.SetActive(false);
        Time.timeScale = 0f;
    }
    public void TutorialBtn2()
    {
        //Tutorial.SetActive(true);
        Tutorial1.SetActive(false);
        Tutorial2.SetActive(true);
        Tutorial3.SetActive(false);
        Tutorial4.SetActive(false);
        Tutorial5.SetActive(false);
        Time.timeScale = 0f;
    }
    public void TutorialBtn3()
    {
        //Tutorial.SetActive(true);
        Tutorial1.SetActive(false);
        Tutorial2.SetActive(false);
        Tutorial3.SetActive(true);
        Tutorial4.SetActive(false);
        Tutorial5.SetActive(false);
        Time.timeScale = 1f;
    }
    public void TutorialBtn4()
    {
        //Tutorial.SetActive(true);
        Tutorial1.SetActive(false);
        Tutorial2.SetActive(false);
        Tutorial3.SetActive(false);
        Tutorial4.SetActive(true);
        Tutorial5.SetActive(false);
        Time.timeScale = 0f;
    }
    public void TutorialBtn5()
    {
        //Tutorial.SetActive(true);
        Tutorial1.SetActive(false);
        Tutorial2.SetActive(false);
        Tutorial3.SetActive(false);
        Tutorial4.SetActive(false);
        Tutorial5.SetActive(true);
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
    public void RestartButton()
    {
        SceneManager.LoadScene("Level 1");
    }
}
