using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public bool Full;
    public int currentPower;
    public int enemyCurrentPower;
    public bool FullEnemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponentInChildren<ThisCard>())
        {
            Full = true;
            currentPower = gameObject.GetComponentInChildren<ThisCard>().currentPower;
        }
        if (gameObject.GetComponentInChildren<AiCardToHand>())
        {
            FullEnemies = true;
            enemyCurrentPower = gameObject.GetComponentInChildren<AiCardToHand>().currentPower;    
        }

        if (!(gameObject.GetComponentInChildren<ThisCard>() || gameObject.GetComponentInChildren<AiCardToHand>()))
        {
            Full = false;
            FullEnemies = false;
            currentPower = 0;
            enemyCurrentPower = 0;
        }

    }
}
