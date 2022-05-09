using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    private void Awake()
    {
        // Id , nama , cost , Power, deskripsi , Image ,>>>> ICON <<<<, DrawCard , CurrentMana++ , HealBase , Movement, Freeze
        cardList.Add(new Card(0, "Dummy", 1, 2, "Dummy", Resources.Load<Sprite>("Gajah Mada"), Resources.Load<Sprite>(""), 0, 0, 0, 20, false, false));
        cardList.Add(new Card(1, "Gajah Mada", 9, 5, "None", Resources.Load<Sprite>("Gajah Mada"), Resources.Load<Sprite>("Gajah Mada Ico"), 0, 0, 2, 1, false, false));
        cardList.Add(new Card(2, "Prajurit Tombak", 3, 3, "None", Resources.Load<Sprite>("Prajurit Tombak"), Resources.Load<Sprite>("Prajurit Tombak Ico"), 0, 0, 0, 1, false, false));
        cardList.Add(new Card(3, "Prajurit Pedang", 2, 2, "None", Resources.Load<Sprite>("Prajurit Pedang"), Resources.Load<Sprite>("Prajurit Pedang Ico"), 0, 0, 0, 1, false, false));
        cardList.Add(new Card(4, "Benteng Proteksi", 3, 4, "None", Resources.Load<Sprite>("Benteng Pertahanan"), Resources.Load<Sprite>("Benteng Pertahanan Ico"), 0, 0, 0, 0, false, false));
        cardList.Add(new Card(5, "Prajurit Kilat", 2, 1, "None", Resources.Load<Sprite>("Prajurit Kilat"), Resources.Load<Sprite>("Prajurit Kilat Ico"), 0, 0, 0, 2, false, false));
        cardList.Add(new Card(6, "Hayam Wuruk", 8, 2, "None", Resources.Load<Sprite>("Hayam Wuruk"), Resources.Load<Sprite>("Hayam Wuruk Ico"), 0, 1, 0, 0, false, false));
        cardList.Add(new Card(7, "Prajurit Zirah", 4, 3, "None", Resources.Load<Sprite>("Prajurit Pedang"), Resources.Load<Sprite>("Prajurit Pedang Ico"), 0, 0, 0, 1, false, false));
        cardList.Add(new Card(8, "Prajurit Es", 2, 1, "None", Resources.Load<Sprite>("Prajurit Pedang"), Resources.Load<Sprite>("Prajurit Pedang Ico"), 0, 0, 0, 1, true, false));
        cardList.Add(new Card(9, "Ken Arok", 2, 2, "None", Resources.Load<Sprite>("Prajurit Pedang"), Resources.Load<Sprite>("Prajurit Pedang Ico"), 0, 0, 0, 1, false, false));
        cardList.Add(new Card(10, "Kertanegara", 2, 2, "None", Resources.Load<Sprite>("Prajurit Pedang"), Resources.Load<Sprite>("Prajurit Pedang Ico"), 0, 0, 0, 1, false, false));
    }
}
