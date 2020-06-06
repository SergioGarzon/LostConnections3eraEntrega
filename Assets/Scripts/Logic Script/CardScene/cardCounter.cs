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
        float blackPoint = blackCard.amount * blackCard.value;
        float goldenPoint = goldenCard.amount * goldenCard.value;

        string value = blackPoint + "\n" + goldenPoint;

        blackCards.text = value;
    }
}
