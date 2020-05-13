using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardCounter : MonoBehaviour
{
    public Text goldenCards;

    public Text blackCards;

    public InventoryItem goldenCard;

    public InventoryItem blackCard;
    

    // Update is called once per frame
    void Update()
    {
        goldenCards.text = "Gold: " + goldenCard.amount * goldenCard.value;
        blackCards.text = "Black: " + blackCard.amount * blackCard.value;
    }
}
