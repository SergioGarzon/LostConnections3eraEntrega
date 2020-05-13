using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public Image image;
    //private Sprite sprite;
    
    public Text type;

    //public string name;

    public Text amount;

    //public string amountText;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Load(InventoryItem inventoryItem)
    {
        image.sprite = inventoryItem.sprite;
        type.text = inventoryItem.itemName;
        amount.text = inventoryItem.amount.ToString();
    }
 
    public void Show()//al hacer click el boton
    {
        
    }
}