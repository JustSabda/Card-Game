using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    private void Awake()
    {
        // Id , nama , cost , Power, deskripsi , Image , DrawCard , CurrentMana++ , HealBase , Movement
        cardList.Add(new Card(0, "Dummy", 1, 2, "Dummy", Resources.Load<Sprite>("Kian Santang"), 0, 0, 0, 20));
        cardList.Add(new Card(1, "Cecep", 1 , 2, "None",Resources.Load<Sprite>("Kian Santang"),0,0,1,2));
        cardList.Add(new Card(2, "Semprul", 2, 5, "None", Resources.Load<Sprite>("Sutawijaya"),0,0,1,1));
        cardList.Add(new Card(3, "Bambang", 3, 1, "None",Resources.Load<Sprite>("Sultan Agung"),0,0,1,2));
        cardList.Add(new Card(4, "Wiluyo", 2, 1, "None", Resources.Load<Sprite>("Ken Arok"),0,0,1,1));
        cardList.Add(new Card(5, "Asep", 1, 1, "None", Resources.Load<Sprite>("Siliwangi"),0,0,1,1));
    }
}
