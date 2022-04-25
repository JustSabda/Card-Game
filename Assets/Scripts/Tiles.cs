using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public bool Full;
    public int currentPower;
    public int damaged;
    public int enemyCurrentPower;
    public int enemyDamaged;
    public bool FullEnemies;
    SoundMenu soundMenu;

    // Start is called before the first frame update
    void Start()
    {
        soundMenu = GetComponent<SoundMenu>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.GetComponentInChildren<ThisCard>())
        {
            Full = true;
            currentPower = gameObject.GetComponentInChildren<ThisCard>().currentPower;
            damaged = currentPower;
        }
        else
        {
            currentPower = 0;
        }
        if (gameObject.GetComponentInChildren<AiCardToHand>())
        {
            FullEnemies = true;
            enemyCurrentPower = gameObject.GetComponentInChildren<AiCardToHand>().currentPower;
            enemyDamaged = enemyCurrentPower;
        }
        else
        {
            enemyCurrentPower = 0;
        }
        if(gameObject.GetComponentInChildren<ThisCard>() && gameObject.GetComponentInChildren<AiCardToHand>())
        {

        }
        if (!(gameObject.GetComponentInChildren<ThisCard>() || gameObject.GetComponentInChildren<AiCardToHand>()))
        {
            Full = false;
            FullEnemies = false;
            currentPower = 0;
            enemyCurrentPower = 0;
            damaged = 0;
            enemyDamaged = 0;
            if (gameObject.GetComponentInChildren<ThisCard>())
            {
                FullEnemies = true;
            }
            if (gameObject.GetComponentInChildren<AiCardToHand>())
            {
                Full = true;
            }
        }

    }
}
