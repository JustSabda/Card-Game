using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TombolManage : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Credits;
    public GameObject Setting;
    public GameObject List;
    public GameObject Prolog;
    public GameObject Story1;
    public GameObject Story2;
    public GameObject Story3;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        MainMenu.SetActive(true);
        Credits.SetActive(false);
        Setting.SetActive(false);
        List.SetActive(false);
        
    }
    void Update()
    {

    }
    public void MenuButton()
    {
        MainMenu.SetActive(true);
        Credits.SetActive(false);
        Setting.SetActive(false);
        List.SetActive(false);
    }
    public void CreditsButton()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
        Setting.SetActive(false);
        List.SetActive(false);
    }
    public void SettingButton()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(false);
        Setting.SetActive(true);
        List.SetActive(false);
    }
    public void ListButton()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(false);
        Setting.SetActive(false);
        List.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Selection()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void Game()
    {
        SceneManager.LoadScene("Level 1");
    }
}
