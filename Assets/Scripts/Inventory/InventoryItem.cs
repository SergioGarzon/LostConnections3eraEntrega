using UnityEngine;


[CreateAssetMenu (menuName = "Shop/InventoryItem")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public int id;
    public Sprite sprite;
    public int value;
    public Color backgroundColor;
    public int amount=0;
    public CardType cardType;
    private int _finalValue1;
    private int _finalValue2;
    private int _finalValue3;
    private int _finalValue4;
    private int _gameMoney;

    public void Load() {
        amount = SessionData.Data.cardsAmount[id];
        SessionData.LoadData();
    }
    
    public void Upgrade() {

        SessionData.Data.cardsAmount[id] = amount;
        SessionData.SaveData();
    }

}
[System.Serializable]
public class InventoryItemSerializable {
    public int cardsAmount;
}
public enum CardType{HISTORY, INFO, BLACK, ID}