using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AiCardToHand : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();




    public int thisId;

    public int id;

    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;

    //public Text nameText;
    //public Text costText;
    //public Text powerText;
    //public Text descriptionText;

    public Sprite thisSpriteCard;
    public Image thatImage;

    public Sprite thisIkonCard;
    public Image thatIcon;

    public int move;

    public static int drawX;
    public int drawXcards;
    public int draw_cards;
    public int add_CurrentMana;

    public int hurted;
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
    // Start is called before the first frame update
    void Start()
    {

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
        power = thisCard[0].power;
        cardDescription = thisCard[0].cardDescription;

        move = thisCard[0].move;
        thisSpriteCard = thisCard[0].thisImage;

        draw_cards = thisCard[0].draw_Card;
        add_CurrentMana = thisCard[0].add_CurrentMana;

        healSpell = thisCard[0].healBase;

        actualpower = power - hurted;

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

    }
    public void ChangeSkin()
    {
        CardVisual.SetActive(false);
        IkonVisual.SetActive(true);
    }
}
