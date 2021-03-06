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
    public GameObject Particle1, Particle2, Particle3, Particle4;
    public static bool prologbo, epilogbo;
 
    // Start is called before the first frame update
    void Start()
    {
        if (prologbo == false && epilogbo == false)
        {
            LevelCanvas.SetActive(true);
            Story1.SetActive(false);
            Story2.SetActive(false);
            Story3.SetActive(false);
            //Ending.SetActive(false);
            //Prolog.SetActive(false);
        }
        Time.timeScale = 1f;
        if (prologbo == true)
        {
            Storysatu();
        }
        if (epilogbo == true)
        {
            EpilogButton();
        }
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
        //Ending.SetActive(false);
        //Prolog.SetActive(false);
    }
    public void PrologAwal()
    {
        //Prolog.SetActive(true);
        LevelCanvas.SetActive(false);
        Story1.SetActive(false);
        Story2.SetActive(false);
        Story3.SetActive(false);
        //Ending.SetActive(false);

    }
    public void Storysatu()
    {
        LevelCanvas.SetActive(false);
        Story1.SetActive(true);
        Story2.SetActive(false);
        Story3.SetActive(false);
        //Ending.SetActive(false);
        //Prolog.SetActive(false);
        prologbo = false;
    }
    public void Storydua()
    {
        LevelCanvas.SetActive(false);
        Story1.SetActive(false);
        Story2.SetActive(true);
        Story3.SetActive(false);
        //Ending.SetActive(false);
        //Prolog.SetActive(false);
    }
    public void Storytiga()
    {
        LevelCanvas.SetActive(false);
        Story1.SetActive(false);
        Story2.SetActive(false);
        Story3.SetActive(true);
        //Ending.SetActive(false);
        //Prolog.SetActive(false);
    }
    public void EndingStory()
    {
        LevelCanvas.SetActive(false);
        Story1.SetActive(false);
        Story2.SetActive(false);
        Story3.SetActive(false);
        //Ending.SetActive(true);
        //Prolog.SetActive(false);
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
    public void PrologButton()
    {
        SceneManager.LoadScene("Prolog");
        prologbo = true;
    }
    public void EpilogButton()
    {
        SceneManager.LoadScene("Epilog");
        epilogbo = false;
    }
}
