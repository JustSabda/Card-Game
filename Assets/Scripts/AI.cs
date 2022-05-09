using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


        //x = 0;
        deckSize = 30;


        draw = true;
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            for (int i = 0; i < deckSize; i++)
            {
                int[] acak = { 2, 3, 5 };
                int acak1 = Random.Range(0, 3);
                int y = acak[acak1];
                deck[i] = CardDataBase.cardList[y];
            }
        }
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            for (int i = 0; i < deckSize; i++)
            {
                int[] acak = { 2, 3, 5 , 8 };
                int acak1 = Random.Range(0, 4);
                int y = acak[acak1];
                deck[i] = CardDataBase.cardList[y];
                //deck[5] = CardDataBase.cardList[6];
            }
        }

        Shuffle();

        StartCoroutine(StartGame());

        Hand = GameObject.Find("EnemyHand");
        //Zone = GameObject.FindGameObjectsWithTag("Zone");
        Zone[0] = GameObject.Find("Zone_a00");
        Zone[1] = GameObject.Find("Zone_a01");
        Zone[2] = GameObject.Find("Zone_a02");
        Zone[3] = GameObject.Find("Zone_a03");
        Zone[4] = GameObject.Find("Zone_a04");
        Zone[5] = GameObject.Find("Zone_a05");
        Zone[6] = GameObject.Find("Zone_a06");
        Zone[7] = GameObject.Find("Zone_a07");
        Zone[8] = GameObject.Find("Zone_a08");
        Zone[9] = GameObject.Find("Zone_a09");
        Zone[10] = GameObject.Find("Zone_b01");
        Zone[11] = GameObject.Find("Zone_b02");
        Zone[12] = GameObject.Find("Zone_b03");
        Zone[13] = GameObject.Find("Zone_b04");
        Zone[14] = GameObject.Find("Zone_b05");
        Zone[15] = GameObject.Find("Zone_b06");
        Zone[16] = GameObject.Find("Zone_b07");
        Zone[17] = GameObject.Find("Zone_b08");
        Zone[18] = GameObject.Find("Zone_b09");
        Zone[19] = GameObject.Find("Zone_c01");
        Zone[20] = GameObject.Find("Zone_c02");
        Zone[21] = GameObject.Find("Zone_c03");
        Zone[22] = GameObject.Find("Zone_c04");
        Zone[23] = GameObject.Find("Zone_c05");
        Zone[24] = GameObject.Find("Zone_c06");
        Zone[25] = GameObject.Find("Zone_c07");
        Zone[26] = GameObject.Find("Zone_c08");
        Zone[27] = GameObject.Find("Zone_c09");
        Zone[28] = GameObject.Find("Zone_d01");
        Zone[29] = GameObject.Find("Zone_d02");
        Zone[30] = GameObject.Find("Zone_d03");
        Zone[31] = GameObject.Find("Zone_d04");
        Zone[32] = GameObject.Find("Zone_d05");
        Zone[33] = GameObject.Find("Zone_d06");
        Zone[34] = GameObject.Find("Zone_d07");
        Zone[35] = GameObject.Find("Zone_d08");
        Zone[36] = GameObject.Find("Zone_d09");


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
                    
                    int[] acak = {6,7,15,16,24,25,33,34};
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
                                child.GetComponent<AiCardToHand>().currentMove = child.GetComponent<AiCardToHand>().move;
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
