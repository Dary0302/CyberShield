using System;
using UnityEngine;

public class SpawnPurchasedObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] shopItems;
    [SerializeField] private ShopItemView shopItemView;

    private void Update()
    {
        PutItemOnScene();
    }

    private void PutItemOnScene()
    {
        foreach (var shopItem in shopItems)
        {
            if (PlayerPrefs.HasKey(shopItem.name))
                shopItem.SetActive(true);
        }
    }


}