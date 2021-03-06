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

    public GameObject rawImage, rawImagePeng;

    public bool firstClick;
    public GameObject pauseMenu, particleEs;
    public GameObject Tutorial, Tutorial0, Tutorial1, Tutorial2, Tutorial3, Tutorial4, Tutorial5, Tutorial52, Tutorial6, Tutorial7, Tutorial8, Tutorial9, Tutorial10;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 2" || SceneManager.GetActiveScene().name == "Level 1" )
        {
            rawImage.SetActive(true);
            rawImagePeng.SetActive(true);
            ParticleSystem ps = GameObject.FindWithTag("Particles").GetComponent<ParticleSystem>();
            ps.Play();
            Tutorial0.SetActive(true);
        }
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            particleEs.SetActive(false);
        }
        else if(SceneManager.GetActiveScene().name == "Level 3" || SceneManager.GetActiveScene().name == "Level 1")
        {
            rawImage.SetActive(true);
            rawImagePeng.SetActive(true);
 


        }
        Time.timeScale = 1f;



        firstClick = false;
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
        Tutorial0.SetActive(false);
        Tutorial1.SetActive(false);
        Tutorial2.SetActive(false);
        Tutorial3.SetActive(false);
        Tutorial4.SetActive(false);
        Tutorial5.SetActive(false);
        Tutorial52.SetActive(false);
        Tutorial6.SetActive(false);
        Tutorial7.SetActive(false);
        Tutorial8.SetActive(false);
        if (SceneManager.GetActiveScene().name == "Level 2" || SceneManager.GetActiveScene().name == "Level 3")
        {
            Tutorial9.SetActive(false);
            Tutorial10.SetActive(false);
        }

        Time.timeScale = 1f;
    }
    public void TutorialBtn1()
    {
        //Tutorial.SetActive(true);
        Tutorial0.SetActive(false);
        if (SceneManager.GetActiveScene().name == "Level 2" || SceneManager.GetActiveScene().name == "Level 3")
        {
            Tutorial9.SetActive(true);
        }
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            Tutorial1.SetActive(true);
        }
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
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            Tutorial2.SetActive(true);
        }
        if (SceneManager.GetActiveScene().name == "Level 2" || SceneManager.GetActiveScene().name == "Level 3")
        {
            Tutorial9.SetActive(false);
            Tutorial10.SetActive(true);
        }
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
    public void TutorialBtn52()
    {
        Tutorial5.SetActive(false);
        Tutorial52.SetActive(true);
        Time.timeScale = 0f;
        firstClick = true;
    }
    public void TutorialBtn6()
    {
        if(firstClick == true)
        {
            Tutorial52.SetActive(false);
            Tutorial5.SetActive(false);
            Tutorial6.SetActive(true);
            Time.timeScale = 0f;
        }
        firstClick = false;
    }
    public void TutorialBtn7()
    {

        Tutorial6.SetActive(false);
        Tutorial7.SetActive(true);
        Time.timeScale = 0f;
    }
    public void TutorialBtn8()
    {
        Tutorial7.SetActive(false);
        Tutorial8.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void LevelButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelection");
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            LevelManager.epilogbo = true;
        }
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
