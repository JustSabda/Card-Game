using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    //public Text victoryText;
    public GameObject textObject;
    // Start is called before the first frame update
    void Start()
    {
        //textObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHP.staticHP <= 0)
        {
            //textObject.SetActive(true);
            
        }
        if(EnemyHP.staticHP <= 0)
        {
            //textObject.SetActive(true);
        }
    }
}
