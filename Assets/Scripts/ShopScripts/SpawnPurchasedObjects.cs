using UnityEngine;

public class SpawnPurchasedObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] shopItems;

    public void Update()
    {
        foreach (var shopItem in shopItems)
        {
            if (PlayerPrefs.HasKey(shopItem.name))
                shopItem.SetActive(true);
        }
    }
}