using System.Collections.Generic;
using UnityEngine;

public class InstantiateShopItem : MonoBehaviour
{
    [SerializeField] private ShopItemView shopItemViewPrefab;
    [SerializeField] private Transform content;
    [SerializeField] private List<SampleShopItem> shopItems = new();
    private readonly List<ShopItemView> shopItemViews = new();

    private void Start()
    {
        SpawnAssortment();
    }
    private void SpawnAssortment()
    {
        foreach (var shopItem in shopItems)
        {
            if (PlayerPrefs.HasKey(shopItem.SystemName))
                continue;
            
            var newShopItem = Instantiate(shopItemViewPrefab, content.position, Quaternion.identity, content);
            newShopItem.ItemBought += OnItemBought;
            newShopItem.ItemBought += PlayerStats.SuccessItemBought;
            shopItemViews.Add(newShopItem);

            newShopItem.SetData(shopItem);
        }
    }

    private void OnItemBought(ShopItemView shopItemView)
    {
        shopItemView.ItemBought -= OnItemBought;
        shopItemViews.Remove(shopItemView);
        Destroy(shopItemView.gameObject);
    }

    private void OnDestroy()
    {
        foreach (var shopItemView in shopItemViews)
        {
            shopItemView.ItemBought -= OnItemBought;
        }
        shopItemViews.Clear();
    }
}