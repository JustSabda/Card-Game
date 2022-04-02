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
    public int x;
    public int y;
    public bool yes;
    public bool yes2;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        y = 0;
        yes = true;
        yes2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameObject.GetComponentInChildren<ThisCard>())
        {
            Full = true;
            //StartCoroutine(Point());
            if(yes == true)
            {
                currentPower = gameObject.GetComponentInChildren<ThisCard>().currentPower;
                damaged = currentPower;
                yes = false;
                if (currentPower <= 0)
                {
                    x = 1;
                }
            }
            if (TurnSystem.isYourTurn == true)
            {
                //currentPower = gameObject.GetComponentInChildren<ThisCard>().currentPower;
                //gameObject.GetComponentInChildren<ThisCard>().currentPower= currentPower;
            }

            
            //currentPower = gameObject.GetComponentInChildren<ThisCard>().currentPower;
            //enemyDamaged = currentPower;
        }
        else
        {
            currentPower = 0;
            yes = true;
            //StopCoroutine(Point());
        }
        if (gameObject.GetComponentInChildren<AiCardToHand>())
        {
            FullEnemies = true;
            //StartCoroutine(Point2());
            if(yes2 == true)
            {
                enemyCurrentPower = gameObject.GetComponentInChildren<AiCardToHand>().currentPower;
                enemyDamaged = enemyCurrentPower;
                yes2 = false;
                if (enemyCurrentPower <= 0)
                {
                    y = 1;
                }
            }
            if (TurnSystem.isYourTurn == false)
            {
                //enemyCurrentPower = gameObject.GetComponentInChildren<AiCardToHand>().currentPower;
                //gameObject.GetComponentInChildren<AiCardToHand>().currentPower = enemyCurrentPower;
            }

            //enemyCurrentPower = gameObject.GetComponentInChildren<AiCardToHand>().currentPower;
            //damaged = enemyCurrentPower;
        }
        else
        {
            enemyCurrentPower = 0;
            yes2 = true;
            //StopCoroutine(Point2());
        }
        if(gameObject.GetComponentInChildren<ThisCard>() && gameObject.GetComponentInChildren<AiCardToHand>())
        {
            //x = currentPower - enemyCurrentPower;
        }
      
        if (!(gameObject.GetComponentInChildren<ThisCard>() || gameObject.GetComponentInChildren<AiCardToHand>()))
        {
            Full = false;
            FullEnemies = false;
            currentPower = 0;
            enemyCurrentPower = 0;
            //StopCoroutine(Point());
            //StopCoroutine(Point2());
        }

    }
    IEnumerator Point()
    {
        yield return null;
        currentPower = gameObject.GetComponentInChildren<ThisCard>().currentPower;
    }
    IEnumerator Point2()
    {
        yield return null;
        enemyCurrentPower = gameObject.GetComponentInChildren<AiCardToHand>().currentPower;
    }
}
