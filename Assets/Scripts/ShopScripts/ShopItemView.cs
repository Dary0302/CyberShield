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
    [SerializeField] private TMP_Text price;
    
    public event Action<ShopItemView> ItemBought;

    public void SetData(SampleShopItem shopItem)
    {
        productPhoto.sprite = shopItem.ProductPhoto;
        productName.text = shopItem.ProductName;
        description.text = shopItem.Description;
        price.text = $"{shopItem.Price.ToString()}$";
        buyButton.onClick.AddListener(() =>
        {
            if (!PlayerStats.TryItemBuy(shopItem.SystemName, shopItem.Price))
                return;
            
            ItemBought?.Invoke(this);
        });
    }
}