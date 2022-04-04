using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    //public Text victoryText;
    public GameObject WLPanel;
    public Text wLText;
    // Start is called before the first frame update
    void Start()
    {
        WLPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHP.staticHP <= 0)
        {
            WLPanel.SetActive(true);
            wLText.text = "Are You NOOB ?";
            Time.timeScale = 0f;
        }
        if(EnemyHP.staticHP <= 0)
        {
            WLPanel.SetActive(true);
            wLText.text = "Beginner Luck";
            Time.timeScale = 0f;
        }
    }
}
