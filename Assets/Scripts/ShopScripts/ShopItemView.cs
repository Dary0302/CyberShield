using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{
    [SerializeField] private Image productPhoto;
    [SerializeField] private TMP_Text productName;
    [SerializeField] private TMP_Text description;
    [SerializeField] private int price;
    [SerializeField] private Button buyButton;
    //[SerializeField] private Image notDoneCheckMark;
    //[SerializeField] private Image doneCheckMark;

    public void SetData(SampleShopItem shopItem)
    {
        productPhoto.sprite = shopItem.ProductPhoto;
        productName.text = shopItem.ProductName;
        description.text = shopItem.Description;
        price = shopItem.Price;
        buyButton.onClick.AddListener(() => PlayerStats.ItemBuy(productName.text, price));
    }

    /*public void SetDoneCheckMark()
    {
        notDoneCheckMark.sprite = doneCheckMark.sprite;
    }*/
}