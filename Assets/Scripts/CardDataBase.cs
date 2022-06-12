using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    private void Awake()
    {
        // Id , nama , cost , Power, deskripsi , Image ,>>>> ICON <<<<, DrawCard , CurrentMana++ , HealBase , Movement, Freeze , toxic

        cardList.Add(new Card(0, "Dummy", 1, 2, "Dummy", Resources.Load<Sprite>("Gajah Mada"), Resources.Load<Sprite>(""), 0, 0, 0, 20, false, false));
        //Player

        cardList.Add(new Card(1, "Gajah Mada", 9, 5, "None", Resources.Load<Sprite>("Gajah Mada"), Resources.Load<Sprite>("Player Gajah Mada Ico"), 0, 0, 2, 1, false, false));
        cardList.Add(new Card(2, "Hayam Wuruk", 8, 2, "None", Resources.Load<Sprite>("Hayam Wuruk"), Resources.Load<Sprite>("Player Hayam Wuruk Ico"), 0, 1, 0, 0, false, false));
        cardList.Add(new Card(3, "Prajurit Tombak", 3, 3, "None", Resources.Load<Sprite>("Prajurit Tombak"), Resources.Load<Sprite>("Player Prajurit Tombak Ico"), 0, 0, 0, 1, false, false));
        cardList.Add(new Card(4, "Prajurit Pedang", 2, 2, "None", Resources.Load<Sprite>("Prajurit Pedang"), Resources.Load<Sprite>("Player Prajurit Pedang Ico"), 0, 0, 0, 1, false, false));
        cardList.Add(new Card(5, "Benteng Proteksi", 3, 4, "None", Resources.Load<Sprite>("Benteng Pertahanan"), Resources.Load<Sprite>("Player Benteng Pertahanan Ico"), 0, 0, 0, 0, false, false));
        cardList.Add(new Card(6, "Prajurit Kilat", 2, 1, "None", Resources.Load<Sprite>("Prajurit Kilat"), Resources.Load<Sprite>("Player Prajurit Kilat Ico"), 0, 0, 0, 2, false, false));
        cardList.Add(new Card(7, "Prajurit Zirah", 4, 4, "None", Resources.Load<Sprite>("Prajurit Zirah"), Resources.Load<Sprite>("Player Prajurit Zirah Ico"), 0, 0, 0, 1, false, false));
        cardList.Add(new Card(8, "Prajurit Es", 2, 1, "None", Resources.Load<Sprite>("Prajurit Es"), Resources.Load<Sprite>("Player Prajurit Es Ico"), 0, 0, 0, 1, true, false));


        //Enemy
        cardList.Add(new Card(11, "Prajurit Tombak", 3, 3, "None", Resources.Load<Sprite>("Prajurit Tombak"), Resources.Load<Sprite>("Enemy Prajurit Tombak Ico"), 0, 0, 0, 1, false, false));
        cardList.Add(new Card(12, "Prajurit Pedang", 2, 2, "None", Resources.Load<Sprite>("Prajurit Pedang"), Resources.Load<Sprite>("Enemy Prajurit Pedang Ico"), 0, 0, 0, 1, false, false));
        cardList.Add(new Card(13, "Benteng Proteksi", 3, 4, "None", Resources.Load<Sprite>("Benteng Pertahanan"), Resources.Load<Sprite>("Enemy Benteng Pertahanan Ico"), 0, 0, 0, 0, false, false));
        cardList.Add(new Card(14, "Prajurit Kilat", 2, 1, "None", Resources.Load<Sprite>("Prajurit Kilat"), Resources.Load<Sprite>("Enemy Prajurit Kilat Ico"), 0, 0, 0, 2, false, false));
        cardList.Add(new Card(15, "Prajurit Es", 2, 1, "None", Resources.Load<Sprite>("Prajurit Es"), Resources.Load<Sprite>("Enemy Prajurit Es Ico"), 0, 0, 0, 1, true, false));
        cardList.Add(new Card(16, "Ken Arok", 7, 5, "None", Resources.Load<Sprite>("Ken Arok"), Resources.Load<Sprite>("Enemy Ken Arok Ico"), 0, 0, 0, 1, false, false));
        cardList.Add(new Card(17, "Kertanegara", 5, 3, "None", Resources.Load<Sprite>("Kertanegara"), Resources.Load<Sprite>("Enemy Kertanegara Ico"), 0, 0, 0, 1, false, false));
        cardList.Add(new Card(18, "Siliwangi", 5, 1, "None", Resources.Load<Sprite>("Siliwangi"), Resources.Load<Sprite>("Enemy Siliwangi Ico"), 0, 0, 0, 2, false, true));
        cardList.Add(new Card(19, "Kian Santang", 6, 4, "None", Resources.Load<Sprite>("Kian Santang"), Resources.Load<Sprite>("Enemy Kian Santang Ico"), 0, 0, 0, 1, false, false));
    }
}
