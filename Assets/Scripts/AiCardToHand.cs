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
    public Text powerText;
    //public Text descriptionText;

    public Sprite thisSpriteCard;
    public Image thatImage;

    public Sprite thisIkonCard;
    public Image thatIcon;

    public int move;
    public int currentMove;

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

    AudioSource audiox;
    public bool freeze;
    public bool cold;

    // Start is called before the first frame update
    void Start()
    {
        
        audiox = GetComponent<AudioSource>();
        
        summoningSickness = true;
        summoned = false;
        canMove = false;
        tiles = GetComponent<Tiles>();  

        CardBackScript = GetComponent<CardBack>();
        thisCard[0] = CardDataBase.cardList[thisId];
        Hand = GameObject.Find("EnemyHand");

        z = 0;
        numberOfCardsInDeck = AI.deckSize;
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
        thisIkonCard = thisCard[0].thisIcon;

        draw_cards = thisCard[0].draw_Card;
        add_CurrentMana = thisCard[0].add_CurrentMana;

        healSpell = thisCard[0].healBase;

        //nameText.text = "" + cardName;
        //costText.text = "" + cost;
        powerText.text = "" + currentPower;
        //descriptionText.text = "" + cardDescription;

        thatImage.sprite = thisSpriteCard;
        thatIcon.sprite = thisIkonCard;
        CardBackScript.UpdateCard(cardBack);

        if (this.tag == "Clone")
        {
            if (numberOfCardsInDeck == 0 && PlayerDeck.deckSize == 0)
            {
                numberOfCardsInDeck = 8;
                PlayerDeck.deckSize = 8;
            }
            thisCard[0] = AI.staticEnemyDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            AI.deckSize -= 1;

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
            Move(currentMove);
        }
        if (position == 1 || position == 2 || position == 10 || position == 11 || position == 19 || position == 20 || position == 29 || position == 30)
        {
            audiox.Play();
            Destroy();
            PlayerHP.staticHP = PlayerHP.staticHP - currentPower;
        }
        if(hurted>=maxPower && thisCardCanBeDestroyed)
        {
            //Destroy();
            //hurted = 0;
        }
        if(cold == true)
        {
            currentMove = 0;
            thatIcon.color = new Color32(102,255,229,255);
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
            audiox.Play();
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
                    audiox.Play();
                    playerScript = GetComponentInParent<Transform>().parent.GetComponentInChildren<ThisCard>();
                    playerScript.currentPower = playerScript.currentPower - currentPower;
                    //Zone[position].GetComponent<Tiles>().currentPower = Zone[position].GetComponent<Tiles>().currentPower - currentPower;
                    currentPower = currentPower - Zone[position].GetComponent<Tiles>().damaged;
                    if (freeze == true)
                    {
                        playerScript.cold = true;
                    }
                }
            }
        }
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
    public void SetSelectedHero()
    {
        MenuManager.Instance.ShowTileInfo2(this);
    }
}
