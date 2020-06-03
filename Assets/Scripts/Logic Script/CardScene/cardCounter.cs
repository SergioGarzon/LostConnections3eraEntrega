using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardCounter : MonoBehaviour
{

    public Text blackCards;

    public InventoryItem goldenCard;

    public InventoryItem blackCard;
    

    // Update is called once per frame
    void Update()
    {
        string value = blackCard.amount * blackCard.value  + "\n" + goldenCard.amount * goldenCard.value;

        blackCards.text = value;
    }
}
