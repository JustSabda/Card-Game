using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ThisCard : MonoBehaviour
{
    public AiCardToHand aiScript;
    public List<Card> thisCard = new List<Card>();
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

    public bool cardBack;
    CardBack CardBackScript;

    public GameObject Hand;

    public int numberOfCardsInDeck;

    public bool canBeSummon;
    public bool summoned;

    public GameObject skinCare;

    public static int drawX;
    public int draw_cards;
    public int add_CurrentMana;


    public GameObject attackBorder;
    public bool summoningSickness;

    public bool onlyThisCardAttack;
    public bool canMove;
    public bool cantMove;

    public int healSpell;
    public bool canHeal;

    public GameObject CardVisual;
    public GameObject IkonVisual;

    public int position;

    public GameObject[] Zone;
    Tiles tiles;

    public bool canDamaged;
    public static bool cantDamaged;

    public bool freeze;
    public bool cold;
    public int coldCountdown;
    public GameObject freezeEffect;

    public bool toxic;
    public bool poisoned;
    public GameObject poisonedEffect;

    AudioSource audiox;
    public GameObject battleSFX;
    public bool waitMove;

    void Start()
    {
        audiox = GetComponent<AudioSource>();
        tiles = GetComponent<Tiles>();

        CardBackScript = GetComponent<CardBack>();
        thisCard[0] = CardDataBase.cardList[thisId];
        numberOfCardsInDeck = PlayerDeck.deckSize;

        canBeSummon = false;
        summoned = false;
        currentPower = 0;
        drawX = 0;
        summoningSickness = true;
        canMove = false;


        canHeal = true;
        if (this.tag != "Deck")
        {
            CardVisual.SetActive(true);
            IkonVisual.SetActive(false);
        }

        //Zone = GameObject.FindGameObjectsWithTag("Zone");
        if (this.tag != "Deck")
        {
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
        freezeEffect.SetActive(false);
        waitMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        Hand = GameObject.Find("Hand");
        if(this.transform.parent == Hand.transform.parent)
        {
            cardBack = false;
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

        freeze = thisCard[0].freeze;
        toxic = thisCard[0].toxic;

        //nameText.text = "" + cardName;
        //costText.text = "" + cost;
        
        //descriptionText.text = "" + cardDescription;

        

        CardBackScript.UpdateCard(cardBack);

        if(this.tag == "Clone")
        {
            if(numberOfCardsInDeck == 0 && PlayerDeck.deckSize == 0)
            {
                if (SceneManager.GetActiveScene().name == "Level 1")
                {
                    numberOfCardsInDeck = 8;
                    PlayerDeck.deckSize = 8;
                }
                if (SceneManager.GetActiveScene().name == "Level 2")
                {
                    numberOfCardsInDeck = 9;
                    PlayerDeck.deckSize = 9;
                }
                if (SceneManager.GetActiveScene().name == "Level 3")
                {
                    numberOfCardsInDeck = 10;
                    PlayerDeck.deckSize = 10;
                }
            }
            thisCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];

            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";
        }
        if (this.tag != "Deck")
        {
            powerText.text = "" + currentPower;
            thatImage.sprite = thisSpriteCard;
            thatIcon.sprite = thisIkonCard;
            if (TurnSystem.currentMana >= cost && summoned == false && TurnSystem.isYourTurn==true)
            {
                canBeSummon = true;
            }
            else
            {
                canBeSummon = false;
            }

            if (canBeSummon == true && Time.timeScale != 0f)
            {
                gameObject.GetComponent<Draggable>().enabled = true;
                skinCare.SetActive(true);
            }
            else
            {
                gameObject.GetComponent<Draggable>().enabled = false;
                skinCare.SetActive(false);
            }


            for (int i = 0; i < Zone.Length; i++)
            {
                if (summoned == false && this.transform.parent == Zone[i].transform)
                {
                    if (this.transform.parent == Zone[i].transform)
                    {
                        position = i;
                        Summon();
                    }
                }
            }
        }

        if (TurnSystem.isYourTurn == false && summoned == true)
        {
            summoningSickness = false;
            cantMove = false;
        }
        if (TurnSystem.isYourTurn == true && summoningSickness == false && cantMove == false)
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }
        if(canHeal == true && summoned == true)
        {
            Heal();
            canHeal = false;
        }
        if (TurnSystem.isYourTurn == true && canMove == true && cantMove == false)
        {
            Move(currentMove);
            if (coldCountdown != 0)
            {
                coldCountdown--;
                cantMove = true;
            }
            if(poisoned == true)
            {
                currentPower--;
                cantMove = true;
            }
        }
        if(position == 8||position==9 || position == 17 || position == 18 || position == 26 || position == 27 || position == 35 || position == 36)
        {
            //audiox.Play();
            Destroy();
            EnemyHP.staticHP = EnemyHP.staticHP - currentPower;
        }
        if (coldCountdown > 0)
        {
            cold = true;
        }
        else
        {
            cold = false;
            currentMove = move;
            freezeEffect.SetActive(false);
        }

        if (cold == true)
        {
            currentMove = 0;
            freezeEffect.SetActive(true);
            Zone[position].GetComponent<Tiles>().FullEnemies = false;
            //thatIcon.color = new Color32(102, 255, 229, 255);
            if(currentPower <= 0)
            {
                //audiox.Play();

                Destroy();
            }
        }
        if(poisoned == true)
        {
            poisonedEffect.SetActive(true);
            Zone[position].GetComponent<Tiles>().FullEnemies = false;
            if (currentPower <= 0)
            {
                //audiox.Play();
                
                Destroy();
            }
        }

    }
    public void LateUpdate()
    {
        if (currentPower <= 0 && Zone[position].GetComponent<Tiles>().FullEnemies == true)
        {
            //audiox.Play();
            
            Destroy();
        }
    }
    public void damaged()
    {
        if (TurnSystem.isYourTurn == false && cantDamaged == false)
        {
            Debug.Log("Damaged");
            currentPower = currentPower - Zone[position].GetComponent<Tiles>().enemyCurrentPower;
            cantDamaged = true;
        }
    }
    public void Summon()
    {
        TurnSystem.currentMana -= cost;
        summoned = true;

        TurnSystem.currentMana += add_CurrentMana;
        TurnSystem.DrawCount += 1;

        drawX = draw_cards;
        currentPower = maxPower;
        currentMove = move;
        
        ChangeSkin();
    }
    public void CurrentMana(int x)
    {
        TurnSystem.currentMana += x;
    }
    public void Destroy()
    {
        Instantiate(battleSFX);
        Destroy(this.gameObject);
    }
    public void Heal()
    {
        PlayerHP.staticHP += healSpell;
    }
    public void Move(int x)
    {
        if (Zone[position + x].GetComponent<Tiles>().Full == false)
        {
            Zone[position + x].GetComponent<Tiles>().Full = true;
            for (int i = 0; i < Zone.Length; i++)
            {
                if (position == i)
                {
                    Zone[position + x].GetComponent<HorizontalLayoutGroup>().enabled = false;
                    if (this.gameObject.GetComponent<RectTransform>() != null)
                    {
                        this.transform.DOMove(Zone[position + x].transform.position, 2f);
                        //StartCoroutine(moveGo());
                    }
                    if (this.transform.position == Zone[position + x].transform.position)
                    {
                        Zone[position + x].GetComponent<HorizontalLayoutGroup>().enabled = true;
                    }

                    this.transform.SetParent(Zone[position + x].transform);
                    //StartCoroutine(moveGo());
                }
            }

            position = position + x;
            cantMove = true;
            if (Zone[position].GetComponent<Tiles>().FullEnemies == true)
            {
                //audiox.Play();
                aiScript = GetComponentInParent<Transform>().parent.GetComponentInChildren<AiCardToHand>();
                //Zone[position].GetComponent<Tiles>().enemyCurrentPower = Zone[position].GetComponent<Tiles>().enemyCurrentPower - currentPower;
                aiScript.currentPower = aiScript.currentPower - currentPower;
                currentPower = currentPower - Zone[position].GetComponent<Tiles>().enemyDamaged;


                //currentPower = currentPower - Zone[position].GetComponent<Tiles>().enemyCurrentPower;
                //Zone[position].GetComponent<Tiles>().enemyCurrentPower = Zone[position].GetComponent<Tiles>().enemyCurrentPower - currentPower;
                if (freeze == true)
                {
                    aiScript.coldCountdown = 2;

                }
                if (toxic == true)
                {
                    aiScript.poisoned = true;
                }
            }
        }
    
    }
    public void ChangeSkin()
    {
        CardVisual.SetActive(false);
        IkonVisual.SetActive(true);
    }
    public void BackDef()
    {
        CardVisual.SetActive(true);
        IkonVisual.SetActive(false);
    }
    public void SetSelectedHero()
    {
	MenuManager.Instance.TutorialBtn6();
        MenuManager.Instance.ShowTileInfo(this);
    }
    IEnumerator moveGo()
    {
        yield return new WaitForSeconds(2f);
        waitMove = true;

    }
}
