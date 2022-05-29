using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeck : MonoBehaviour
{

    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();

    //Deck Setting
    public int x;
    public int x1;
    public int x2;
    public int x3;
    public int x4;
    public int x5;
    public int x6;
    public int x7;
    public int x8;


    public static int deckSize = 8;

    public GameObject CardToHand;
    public GameObject Hand;

    AudioSource audiox;

    // Start is called before the first frame update

    void Awake()
    {
        
    }
    void Start()
    {
        audiox = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            deckSize = 10;
            //dummy
            x = 0;

            //realcard
            x1 = 1;
            x2 = 6;
            x3 = 4;
            x4 = 2;
            x5 = 3;
            x6 = 5;

            for (int i = 1; i < deckSize; i++)
            {

                deck[0] = CardDataBase.cardList[x1];
                deck[1] = CardDataBase.cardList[x2];
                deck[2] = CardDataBase.cardList[x3];
                deck[3] = CardDataBase.cardList[x4];
                deck[4] = CardDataBase.cardList[x4];
                deck[5] = CardDataBase.cardList[x5];
                deck[6] = CardDataBase.cardList[x5];
                deck[7] = CardDataBase.cardList[x5];
                deck[8] = CardDataBase.cardList[x6];
                deck[9] = CardDataBase.cardList[x6];
            }
        }

        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            deckSize = 13;
            //dummy
            x = 0;

            //realcard
            x1 = 1;
            x2 = 6;
            x3 = 4;
            x4 = 2;
            x5 = 3;
            x6 = 5;
            x7 = 7;

            for (int i = 1; i < deckSize; i++)
            {

                deck[0] = CardDataBase.cardList[x1];
                deck[1] = CardDataBase.cardList[x2];
                deck[2] = CardDataBase.cardList[x3];
                deck[3] = CardDataBase.cardList[x4];
                deck[4] = CardDataBase.cardList[x4];
                deck[5] = CardDataBase.cardList[x5];
                deck[6] = CardDataBase.cardList[x5];
                deck[7] = CardDataBase.cardList[x5];
                deck[8] = CardDataBase.cardList[x6];
                deck[9] = CardDataBase.cardList[x6];
                deck[10] = CardDataBase.cardList[x7];
                deck[11] = CardDataBase.cardList[x7];
                deck[12] = CardDataBase.cardList[x7];
            }
        }
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            deckSize = 15;
            //dummy
            x = 0;

            //realcard
            x1 = 1;
            x2 = 6;
            x3 = 4;
            x4 = 2;
            x5 = 3;
            x6 = 5;
            x7 = 7;
            x8 = 8;

            for (int i = 1; i < deckSize; i++)
            {

                deck[0] = CardDataBase.cardList[x1];
                deck[1] = CardDataBase.cardList[x2];
                deck[2] = CardDataBase.cardList[x3];
                deck[3] = CardDataBase.cardList[x4];
                deck[4] = CardDataBase.cardList[x4];
                deck[5] = CardDataBase.cardList[x5];
                deck[6] = CardDataBase.cardList[x5];
                deck[7] = CardDataBase.cardList[x5];
                deck[8] = CardDataBase.cardList[x6];
                deck[9] = CardDataBase.cardList[x6];
                deck[10] = CardDataBase.cardList[x7];
                deck[11] = CardDataBase.cardList[x7];
                deck[12] = CardDataBase.cardList[x7];
                deck[13] = CardDataBase.cardList[x8];
                deck[14] = CardDataBase.cardList[x8];
            }
        }

        Shuffle();


        StartCoroutine(StartGame());

    }

    // Update is called once per frame
    void Update()
    {
        
        staticDeck = deck;

        if(ThisCard.drawX > 0)
        {

            StartCoroutine(Draw(ThisCard.drawX));
            
            ThisCard.drawX = 0;

        }
        if (TurnSystem.startTurn == true)
        {
            StartCoroutine(Draw(TurnSystem.DrawCount));
            
            TurnSystem.startTurn = false;
            TurnSystem.DrawCount = 0;
        }
    }

    IEnumerator StartGame()
    {
        for(int i = 0; i <= 3; i++)
        {
            
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
            audiox.Play();
        }
        yield return new WaitForSeconds(3/4);
        if (SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2")
        {
            MenuManager.Instance.TutorialBtn1();
        }
            
    }
    public void Shuffle()
    {
        for(int i = 0; i < deckSize; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }

    }

    IEnumerator Draw(int x)
    {
        for(int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
            audiox.Play();
        }
    }
}
