using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public static List<Card> staticEnemyDeck = new List<Card>();

    public List<Card> cardsInHand = new List<Card>();

    public GameObject Hand;

    public int x;
    public static int deckSize;

    public GameObject CardToHand;

    public GameObject[] Clones;

    public static bool draw;

    public GameObject CardBack;

    public int currentMana;

    public bool[] AiCanSummon;

    public bool drawPhase;
    public bool summonPhase;
    public bool attackPhase;
    public bool endPhase;

    public int[] cardsID;

    public int summonThisId;

    public AiCardToHand aiCardToHand;

    public int summonID;

    public int howManyCards;

    public GameObject[] Zone;

    // Start is called before the first frame update

    void Start()
    {

  

        Hand = GameObject.Find("EnemyHand");
        Zone = GameObject.FindGameObjectsWithTag("Zone");

        //x = 0;
        deckSize = 30;


        draw = true;
        for (int i = 0; i < deckSize; i++)
        {
            int[] acak = { 2, 3, 5};
            int acak1 = Random.Range(0, 3);
            int y = acak[acak1];
            deck[i] = CardDataBase.cardList[y];
        }


        Shuffle();

        StartCoroutine(StartGame());

    }
    // Update is called once per frame
    void Update()
    {
        staticEnemyDeck = deck;

        if (ThisCard.drawX > 0)
        {
            StartCoroutine(Draw(ThisCard.drawX));
            ThisCard.drawX = 0;
        }

        if (TurnSystem.startTurn == true && draw == false)
        {
            StartCoroutine(Draw(TurnSystem.EnemyDrawCount));
            draw = true;
            //TurnSystem.startTurn = false;
            TurnSystem.EnemyDrawCount = 0;
        }

        currentMana = TurnSystem.currentEnemyMana;

        if (0 == 0)
        {
            int j = 0;
            howManyCards = 0;
            foreach(Transform child in Hand.transform)
            {
                howManyCards++;
            }
            foreach(Transform child in Hand.transform)
            {
                cardsInHand[j] = child.GetComponent<AiCardToHand>().thisCard[0];
                j++;
            }

            for(int i = 0; i < 30; i++)
            {
                if (i >= howManyCards)
                {
                    cardsInHand[i] = CardDataBase.cardList[0];
                }
            }
            j = 0;
        }
        if (TurnSystem.isYourTurn == false)
        {
            for(int i = 0; i < 30; i++)
            {
                if(cardsInHand[i].id != 0)
                {
                    if (currentMana >= cardsInHand[i].cost)
                    {
                        AiCanSummon[i] = true;
                    }
                }
            }
        }
        else
        {
            for(int i = 0; i < 30; i++)
            {
                AiCanSummon[i] = false; 
            }
        }

        if (TurnSystem.isYourTurn == false)
        {
            drawPhase = true;
        }

        if (drawPhase == true && summonPhase == false && attackPhase == false)
        {
            StartCoroutine(WaitForSummonPhase());
        }

        if(TurnSystem.isYourTurn == true)
        {
            drawPhase = false;
            summonPhase = false;
            attackPhase = false;
            endPhase = false;
        }  
        if (summonPhase == true)
        {
            summonID = 0;
            summonThisId = 0;
            int index = 0;
            for (int i = 0; i < 30; i++)
            {
                if (AiCanSummon[i] == true)
                {
                    cardsID[index] = cardsInHand[i].id;
                    index++;
                }
            }
            for(int i = 0; i < 30; i++)
            {
                if (cardsID[i] != 0)
                {
                    if (cardsID[i] > summonID)
                    {
                        summonID = cardsID[i];
                    }
                }

            }
            summonThisId = summonID;
            foreach(Transform child in Hand.transform)
            {
                if (child.GetComponent<AiCardToHand>().id == summonThisId && CardDataBase.cardList[summonThisId].cost <= currentMana)
                {
                    
                    int[] acak = {5,6,14,15,23,24,32,33};
                    int acak1 = Random.Range(0, 8);
                    int x = acak[acak1];
                    for (int i = 0; i < Zone.Length; i++)
                    {
                        if (Zone[x].GetComponent<Tiles>().FullEnemies == false && Zone[x].GetComponent<Tiles>().Full == false)
                        {
                            child.transform.SetParent(Zone[x].transform);
                            AiCardToHand.summoned = true;
                            AiCardToHand.summoningSickness = true;
                            if (AiCardToHand.summoningSickness == true)
                            {
                                child.GetComponent<AiCardToHand>().currentPower = child.GetComponent<AiCardToHand>().maxPower;
                            }
                        }
                    }
                    

                    TurnSystem.EnemyDrawCount =+ 1;
                    TurnSystem.currentEnemyMana -= CardDataBase.cardList[summonThisId].cost;
                    break;
                }
            }
            summonPhase = false;
            attackPhase = true;
        }

       
    }
    public void Shuffle()
    {
        for (int i = 0; i < deckSize; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }
    }

    IEnumerator StartGame()
    {
        for (int i = 0; i <= 3; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

    IEnumerator Draw(int x)
    {
        for (int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);

        }
    }

    IEnumerator WaitForSummonPhase()
    {
        yield return new WaitForSeconds(1);
        summonPhase = true;
    }

} 
