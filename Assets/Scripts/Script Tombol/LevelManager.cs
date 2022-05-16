using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public GameObject LevelCanvas;
    public GameObject Story1, Story2, Story3;
    public GameObject Prolog, Ending;
 
    // Start is called before the first frame update
    void Start()
    {
        LevelCanvas.SetActive(true);
        Story1.SetActive(false);
        Story2.SetActive(false);
        Story3.SetActive(false);
        Ending.SetActive(false);
        Prolog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelPilih()
    {
        LevelCanvas.SetActive(true);
        Story1.SetActive(false);
        Story2.SetActive(false);
        Story3.SetActive(false);
        Ending.SetActive(false);
        Prolog.SetActive(false);
    }
    public void PrologAwal()
    {
        Prolog.SetActive(true);
        LevelCanvas.SetActive(false);
        Story1.SetActive(false);
        Story2.SetActive(false);
        Story3.SetActive(false);
        Ending.SetActive(false);

    }
    public void Storysatu()
    {
        LevelCanvas.SetActive(false);
        Story1.SetActive(true);
        Story2.SetActive(false);
        Story3.SetActive(false);
        Ending.SetActive(false);
        Prolog.SetActive(false);
    }
    public void Storydua()
    {
        LevelCanvas.SetActive(false);
        Story1.SetActive(false);
        Story2.SetActive(true);
        Story3.SetActive(false);
        Ending.SetActive(false);
        Prolog.SetActive(false);
    }
    public void Storytiga()
    {
        LevelCanvas.SetActive(false);
        Story1.SetActive(false);
        Story2.SetActive(false);
        Story3.SetActive(true);
        Ending.SetActive(false);
        Prolog.SetActive(false);
    }
    public void EndingStory()
    {
        LevelCanvas.SetActive(false);
        Story1.SetActive(false);
        Story2.SetActive(false);
        Story3.SetActive(false);
        Ending.SetActive(true);
        Prolog.SetActive(false);
    }
    public void MulaiSatu()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void MulaiDua()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void MulaiTiga()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
