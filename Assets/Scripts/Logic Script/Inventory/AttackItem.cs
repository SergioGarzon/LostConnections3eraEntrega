using UnityEngine;
[CreateAssetMenu (menuName = "Shop/AttackItem")]
public class AttackItem: ScriptableObject
{
    public string itemName;
    public string description;
    public string player;
    public int id;
    public Sprite sprite;
    public bool isSelected;
    
}
