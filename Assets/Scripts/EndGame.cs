using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    //public Text victoryText;
    public GameObject WLPanel;
    public static bool end;
    public GameObject Win, nextButton;
    public GameObject Lose, restartButton;
    //public Text wLText;
    AudioSource audiox;
    public AudioClip winSound;
    public AudioClip loseSound;

    //public Image imageNotif;
    // Start is called before the first frame update
    void Start()
    {
        end = false;
        audiox = GetComponent<AudioSource>();
        WLPanel.SetActive(false);
        Win.SetActive(false);
        Lose.SetActive(false);
        restartButton.SetActive(false);
        nextButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHP.staticHP <= 0)
        {
            if (end == false)
            {
                audiox.PlayOneShot(loseSound);
            }
            WLPanel.SetActive(true);
            Lose.SetActive(true);
            restartButton.SetActive(true);
            Time.timeScale = 0f;
            end = true;
        }
        if(EnemyHP.staticHP <= 0)
        {
            if (end == false)
            {
                audiox.PlayOneShot(winSound);
            }
            WLPanel.SetActive(true);
            Win.SetActive(true);
            nextButton.SetActive(true);
            Time.timeScale = 0f;
            end = true;
        }
    }
}
