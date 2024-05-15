using UnityEngine;

[CreateAssetMenu(fileName = "New Shop item", menuName = "Shop item")]
public class SampleShopItem : ScriptableObject
{
    [field: SerializeField] public string ProductName { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public Sprite ProductPhoto { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
}