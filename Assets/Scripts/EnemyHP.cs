using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHP : MonoBehaviour
{
    public static float maxHP;
    public static float staticHP;
    public float hp;
    //public Image Health;
    public Text hpText;
    public AudioSource audiox;

    // Start is called before the first frame update
    void Start()
    {
        audiox = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            maxHP = 6;
            staticHP = 6;
        }
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            maxHP = 8;
            staticHP = 8;
        }
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            maxHP = 10;
            staticHP = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        hp = staticHP;
        //Health.fillAmount = hp / maxHP;

        if (hp >= maxHP)
        {
            hp = maxHP;
        }

        hpText.text = hp + "";
        if (staticHP == 0)
        {
            audiox.Play();
        }
    }
}
