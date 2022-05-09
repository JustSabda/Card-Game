using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card
{
    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;

    public Sprite thisImage;
    public Sprite thisIcon;
    public int draw_Card;
    public int add_CurrentMana;

    public int healBase;
    public int move;

    public bool freeze;
    public bool toxic;

    public Card()
    {

    }

    public Card(int Id ,string CardName, int Cost, int Power, string CardDescription, Sprite ThisImage,Sprite ThisIcon ,int Draw_Card , int Add_CurrentMana , int HealBase , int Move , bool Freeze , bool Toxic)
    {
        id = Id;
        cardName = CardName;
        cost = Cost;
        power = Power;
        cardDescription = CardDescription;
        thisImage = ThisImage;
        thisIcon = ThisIcon;
        draw_Card = Draw_Card;
        add_CurrentMana = Add_CurrentMana;
        healBase = HealBase;
        move = Move;
        freeze = Freeze;
        toxic = Toxic;
    }
}
