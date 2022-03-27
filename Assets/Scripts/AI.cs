using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public static List<Card> staticEnemyDeck = new List<Card>();

    public GameObject Hand;
    public GameObject Zone;

    public int x;
    public int y;
    public static int deckSize;

    public GameObject CardToHand;

    public GameObject[] Clones;

    public static bool draw;

    public GameObject CardBack;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());

        Hand = GameObject.Find("EnemyHand");
        Zone = GameObject.Find("MyEnemyZone");

        x = 0;
        y = 0;
        deckSize = 15;

        draw = true;

        for (int i = 1; i < deckSize; i++)
        {
            deck[0] = CardDataBase.cardList[0];
            x = Random.Range(1, 5);
            deck[i] = CardDataBase.cardList[x];
        }
    }
    // Update is called once per frame
    void Update()
    {
        staticEnemyDeck = deck;

        if(ThisCard.drawX > 0)
        {
            StartCoroutine(Draw(ThisCard.drawX));
            ThisCard.drawX = 0;
        }

        if(TurnSystem.startTurn == false && draw == false)
        {
            StartCoroutine(Draw(TurnSystem.DrawCount));
            draw = true;
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

        Instantiate(CardBack, transform.position, transform.rotation);

        StartCoroutine(ShuffleNow());
    }

    IEnumerator StartGame()
    {
        for(int i = 0; i <= 3; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

    IEnumerator ShuffleNow()
    {
        yield return new WaitForSeconds(1);
        Clones = GameObject.FindGameObjectsWithTag("Clone");

        foreach (GameObject Clone in Clones)
        {
            Destroy(Clone);
        }
    }

    IEnumerator Draw(int x)
    {
        for(int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);

        }
    }
}
