using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public GameObject LevelCanvas;
    public GameObject Story1;
    public GameObject Prolog;
 
    // Start is called before the first frame update
    void Start()
    {
        LevelCanvas.SetActive(true);
        Story1.SetActive(false);
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
        Prolog.SetActive(false);
    }
    public void PrologAwal()
    {
        Prolog.SetActive(true);
        LevelCanvas.SetActive(false);
        Story1.SetActive(false);

    }
    public void Storysatu()
    {
        LevelCanvas.SetActive(false);
        Story1.SetActive(true);
        Prolog.SetActive(false);
    }
    public void MulaiSatu()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
