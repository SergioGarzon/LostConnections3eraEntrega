
using UnityEngine;
[CreateAssetMenu (menuName = "Shop/ShopItem")]
public class ShopItem : ScriptableObject
{
    public string itemName;
    public string character;
    public Sprite sprite;
    public int cost;
    public Color BackgroundColor;

}
