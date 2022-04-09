using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    //public Text victoryText;
    public GameObject WLPanel;
    public GameObject Win;
    public GameObject Lose;
    //public Text wLText;
    AudioSource audiox;

    //public Image imageNotif;
    // Start is called before the first frame update
    void Start()
    {
        audiox = GetComponent<AudioSource>();
        WLPanel.SetActive(false);
        Win.SetActive(false);
        Lose.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHP.staticHP <= 0)
        {
            audiox.Play();
            WLPanel.SetActive(true);
            Win.SetActive(true);
            Time.timeScale = 0f;
        }
        if(EnemyHP.staticHP <= 0)
        {
            audiox.Play();
            WLPanel.SetActive(true);
            Lose.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
