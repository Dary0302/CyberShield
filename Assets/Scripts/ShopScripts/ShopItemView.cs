using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{
    [SerializeField] private Image productPhoto;
    [SerializeField] private TMP_Text productName;
    [SerializeField] private TMP_Text description;
    [SerializeField] private Button buyButton;
    
    public event Action<ShopItemView> ItemBought;

    public void SetData(SampleShopItem shopItem)
    {
        productPhoto.sprite = shopItem.ProductPhoto;
        productName.text = shopItem.ProductName;
        description.text = shopItem.Description;
        var price = shopItem.Price;
        buyButton.onClick.AddListener(() =>
        {
            if (!PlayerStats.TryItemBuy(shopItem.SystemName, price))
                return;
            
            ItemBought?.Invoke(this);
        });
    }
}