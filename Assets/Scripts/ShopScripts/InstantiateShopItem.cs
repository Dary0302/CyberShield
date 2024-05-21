using System.Collections.Generic;
using UnityEngine;

public class InstantiateShopItem : MonoBehaviour
{
    [SerializeField] private ShopItemView shopItemViewPrefab;
    [SerializeField] private Transform content;
    [SerializeField] private List<SampleShopItem> shopItems = new();

    private void Start()
    {
        foreach (var shopItem in shopItems)
        {
            var newLetter = Instantiate(shopItemViewPrefab, content.position, Quaternion.identity, content);
            
            /*if (countQuests < PlayerStats.LevelsCompletedNumber)
                newLetter.SetDoneCheckMark();*/

            newLetter.SetData(shopItem);
        }
    }
}