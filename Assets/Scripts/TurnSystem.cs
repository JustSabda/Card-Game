using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public static bool isYourTurn;
    public int yourTurn;
    public int yourOponentTurn;
    public Text turnText;

    public int maxMana;
    public static int currentMana;
    public Text manaText;

    public static bool startTurn;
    public static int DrawCount;
    public static int EnemyDrawCount;

    public bool turnEnd;
    public Image timeBar;
    public Image enemyTimeBar;
    public float maxTime = 50f;
    public float maxEnemyTime = 50f;
    public float timeLeft;
    public bool timerStart;
    public bool timerStartEnemy;

    public static int maxEnemyMana;
    public static int currentEnemyMana;
    public Text enemyManaText;




    // Start is called before the first frame update
    void Start()
    {
        isYourTurn = true;
        yourTurn = 1;
        yourOponentTurn = 0;

        maxMana = 4;
        currentMana = 4;

        maxEnemyMana = 3;
        currentEnemyMana = 3;

        timeLeft = maxTime;
        startTurn = false;
        timerStart = true;
        timerStartEnemy = false;
        
        timeBar.enabled = true;
        enemyTimeBar.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isYourTurn == true)
        {
            turnText.text = "Your Turn";
        }
        else
        {
            turnText.text = "Enemy Turn";
        }

        manaText.text = ""+currentMana;


        if (timeLeft > 0 && timerStart)
        {
            Countdown();
        }
        if (timeLeft > 0 && timerStartEnemy)
        {
            CountdownEnemy();
        }

        if (timeLeft <= 0 && isYourTurn == true)
        {
            EndYourTurn();

        }

        if(timeLeft <= 0 && isYourTurn == false)
        {
            EndYourOpponentTurn();
        }

        //enemyManaText.text = currentEnemyMana + "";
    }

    public void EndYourTurn()
    {
        startTurn = true;
        timerStart = false;
        timerStartEnemy = true;
        isYourTurn = false;
        yourOponentTurn += 1;

        if (maxEnemyMana < 3)
        {
            maxEnemyMana += 1;
        }
        currentEnemyMana = maxEnemyMana;

        timeLeft = maxEnemyTime;
        timeBar.enabled = false;
        enemyTimeBar.enabled = true;

        AI.draw = false;
        ThisCard.cantDamaged = false;
    }

    public void EndYourOpponentTurn()
    {
        isYourTurn = true;
        yourTurn += 1;
        if (maxMana < 12)
        {
            maxMana += 1;
        }

        currentMana = maxMana;
        timerStart = true;
        timerStartEnemy = false;


        timeLeft = maxTime;
        timeBar.enabled = true;
        enemyTimeBar.enabled = false;
    }
    public void Countdown()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeBar.fillAmount = timeLeft / maxTime;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    public void CountdownEnemy()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            enemyTimeBar.fillAmount = timeLeft / maxEnemyTime;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
