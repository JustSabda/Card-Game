using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{

    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();

    public int x;
    public int y;
    public static int deckSize = 15;

    public GameObject CardToHand;
    public GameObject Hand;

    // Start is called before the first frame update

    private void Awake()
    {
        Shuffle();
    }
    void Start()
    {
        y = 0;
        x = 1;
        deckSize = 15;

        for(int i = 1;i < deckSize; i++)
        {
            deck[0] = CardDataBase.cardList[y];
            x = Random.Range(1, 5);
            deck[i] = CardDataBase.cardList[x];
        }

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
        }
    }
    public void Shuffle()
    {
        for(int i = 1; i < deckSize; i++)
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
        }
    }
}
