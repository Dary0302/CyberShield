using System.Collections.Generic;
using Desktop;
using UnityEngine;

namespace ShopScripts
{
    public class InstantiateShopItem : MonoBehaviour
    {
        [SerializeField] private AudioSource buttonClickSound;
        [SerializeField] private ShopItemView shopItemViewPrefab;
        [SerializeField] private Transform content;
        [SerializeField] private List<SampleShopItem> shopItems = new();
        [SerializeField] private PlayerShowInfo playerShowInfo;
        [SerializeField] private GameObject productOutOfStock;
        private readonly List<ShopItemView> shopItemViews = new();

        private void Start()
        {
            SpawnAssortment();
        }
        private void SpawnAssortment()
        {
            var isProductOutOfStock = true;
            foreach (var shopItem in shopItems)
            {
                if (PlayerPrefs.HasKey(shopItem.SystemName))
                    continue;

                isProductOutOfStock = false;
                var newShopItem = Instantiate(shopItemViewPrefab, content.position, Quaternion.identity, content);
                newShopItem.ItemBought += OnItemBought;
                newShopItem.ItemBought += playerShowInfo.SuccessItemBought;
                shopItemViews.Add(newShopItem);

                newShopItem.SetData(shopItem);
            }
            if (isProductOutOfStock)
                productOutOfStock.gameObject.SetActive(true);
        }

        private void OnItemBought(ShopItemView shopItemView)
        {
            if (PlayerStats.GetCountItemsPurchased() == shopItems.Count - 1)
                productOutOfStock.gameObject.SetActive(true);
            
            buttonClickSound.Play();
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
}