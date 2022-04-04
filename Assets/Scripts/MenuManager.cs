using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] private GameObject _selecetedHeroObject;
    [SerializeField] private GameObject _skinCare1;
    [SerializeField] private GameObject _skinCare2;
    private void Awake()
    {
        Instance = this;
    }
    public void ShowTileInfo(ThisCard cardName)
    {
        _selecetedHeroObject.GetComponentInChildren<Image>().sprite = cardName.thisSpriteCard;
        _selecetedHeroObject.SetActive(true);
        _skinCare1.SetActive(true);
        _skinCare2.SetActive(false);
    }
    public void ShowTileInfo2(AiCardToHand cardName)
    {
        _selecetedHeroObject.GetComponentInChildren<Image>().sprite = cardName.thisSpriteCard;
        _selecetedHeroObject.SetActive(true);
        _skinCare1.SetActive(false);
        _skinCare2.SetActive(true);
    }
}
