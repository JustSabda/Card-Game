using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AiCardToHand : MonoBehaviour
{
    public ThisCard playerScript;
    public List<Card> thisCard = new List<Card>();

    public bool cantMove;
    public bool canMove;
    public int position;
    public static bool summoningSickness;
    public static bool summoned;
    public GameObject[] Zone;

    public int thisId;

    public int id;

    public string cardName;
    public int cost;
    public int maxPower;
    public int currentPower;
    public string cardDescription;

    //public Text nameText;
    //public Text costText;
    //public Text powerText;
    //public Text descriptionText;

    public Sprite thisSpriteCard;
    public Image thatImage;

    public Sprite thisIkonCard;
    public Image thatIcon;

    public static int move;

    public static int drawX;
    public int drawXcards;
    public int draw_cards;
    public int add_CurrentMana;

    public int hurted;
    public bool canAttack;
    public bool cantAttack;
    public int actualpower;
    public int returnXcards;

    public int healSpell;
    public bool canHeal;

    public GameObject Hand;

    public int z = 0;
    public GameObject It;

    public int numberOfCardsInDeck;
    public bool cardBack;

    Tiles tiles;
    CardBack CardBackScript;

    public GameObject CardVisual;
    public GameObject IkonVisual;

    //test

    public bool isTarget;
    public bool thisCardCanBeDestroyed;


    // Start is called before the first frame update
    void Start()
    {
        Zone = GameObject.FindGameObjectsWithTag("Zone");
        summoningSickness = true;
        summoned = false;
        canMove = false;
        tiles = GetComponent<Tiles>();  

        CardBackScript = GetComponent<CardBack>();
        thisCard[0] = CardDataBase.cardList[thisId];
        Hand = GameObject.Find("EnemyHand");

        z = 0;
        numberOfCardsInDeck = AI.deckSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (z == 0)
        {
            It.transform.SetParent(Hand.transform);
            It.transform.localPosition = Vector3.one;
            It.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
            //It.transform.eulerAngles = new Vector3(25, 0, 0);
            z = 1;
        }


        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cost = thisCard[0].cost;
        maxPower = thisCard[0].power;
        cardDescription = thisCard[0].cardDescription;

        move = thisCard[0].move;
        thisSpriteCard = thisCard[0].thisImage;

        draw_cards = thisCard[0].draw_Card;
        add_CurrentMana = thisCard[0].add_CurrentMana;

        healSpell = thisCard[0].healBase;

        //nameText.text = "" + cardName;
        //costText.text = "" + cost;
        //powerText.text = "" + power;
        //descriptionText.text = "" + cardDescription;

        thatImage.sprite = thisSpriteCard;

        CardBackScript.UpdateCard(cardBack);

        if (this.tag == "Clone")
        {
            thisCard[0] = AI.staticEnemyDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            AI.deckSize -= 1;
            if (numberOfCardsInDeck == 0 && PlayerDeck.deckSize == 0)
            {
                numberOfCardsInDeck = 14;
                PlayerDeck.deckSize = 14;
            }
            this.tag = "Untagged";
            cardBack = true;
        }
        for (int i = 0; i < Zone.Length; i++)
        {
            if (summoned == true && this.transform.parent == Zone[i].transform)
            {
                if (this.transform.parent == Zone[i].transform)
                {
                    position = i;
                    //Summon();
                }
            }
        }
        if (TurnSystem.isYourTurn == true && summoned == true)
        {
            summoningSickness = false;
            //cantAttack = false;
            cantMove = false;
        }
        if (TurnSystem.isYourTurn == false && summoningSickness == false && cantMove == false)
        {
            //canAttack = true;
            canMove = true;
        }
        else
        {
            //canAttack = false;
            canMove = false;
        }
        if (TurnSystem.isYourTurn == false && canMove == true && cantMove == false)
        {
            Move(move);
        }
        if (position == 1 || position == 9 || position == 10 || position == 18 || position == 19 || position == 27 || position == 28)
        {
            Destroy();
            PlayerHP.staticHP = PlayerHP.staticHP - currentPower;
        }
        if (Zone[position].GetComponent<Tiles>().Full == true&& TurnSystem.isYourTurn == true)
        {
            //currentPower = currentPower - Zone[position].GetComponent<Tiles>().currentPower;
        }
        if(hurted>=maxPower && thisCardCanBeDestroyed)
        {
            //Destroy();
            //hurted = 0;
        }
    }
    IEnumerator Battle()
    {
        yield return new WaitForSeconds(1);
        if(currentPower <= 0 && Zone[position].GetComponent<Tiles>().Full == true)
        {

        }
    }
    public void LateUpdate()
    {
        if (currentPower <= 0 && Zone[position].GetComponent<Tiles>().Full == true)
        {
            Destroy();
        }
    }
    public void Summon()
    {
        //TurnSystem.currentMana -= cost;
        //summoned = true;

        //TurnSystem.currentMana += add_CurrentMana;
        //TurnSystem.DrawCount += 1;

        //drawX = draw_cards;
        //currentPower = maxPower;
        //ChangeSkin();
    }
    public void ChangeSkin()
    {
        CardVisual.SetActive(false);
        IkonVisual.SetActive(true);
    }
    public void damaged()
    {

    }
    public void Move(int x)
    {
        if (position != 0)
        {
            if (Zone[position - x].GetComponent<Tiles>().FullEnemies == false)
            {
                Zone[position - x].GetComponent<Tiles>().FullEnemies = true;
                for (int i = 0; i < Zone.Length; i++)
                {
                    if (position == i)
                    {
                        this.transform.SetParent(Zone[position - x].transform);
                    }

                }
                position = position - x;

                cantMove = true;
                if (Zone[position].GetComponent<Tiles>().Full == true)
                {
                    playerScript = GetComponentInParent<Transform>().parent.GetComponentInChildren<ThisCard>();
                    playerScript.currentPower = playerScript.currentPower - currentPower;
                    //Zone[position].GetComponent<Tiles>().currentPower = Zone[position].GetComponent<Tiles>().currentPower - currentPower;
                    currentPower = currentPower - Zone[position].GetComponent<Tiles>().damaged;
                }
            }
        }
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
