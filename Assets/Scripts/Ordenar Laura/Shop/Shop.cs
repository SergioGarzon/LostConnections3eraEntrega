﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//Panel SHOP es una clase que muestra los datos
public class Shop : MonoBehaviour
{
    [Header("List of cards to buy")]   //Esto es un texto que se coloca arriba, una etiqueta en el editor
    public InventoryItem blackCard;   
    public InventoryItem goldenCard;
    

    [Header("List of the items sold")] //
    [SerializeField]private ShopItem[] shopItems;

    [Header("References")] 
    [SerializeField] private Transform shopContainer;
    [SerializeField]private GameObject shopItemPrefab;
    
    public ShopData shopData;
    
    public ScoreData scoreData;

    [Header("UI")] 
    public GameObject CharlieShop;
    public GameObject AtifShop;

    private InventoryItem _inventoryItem;
    public GameObject dialogPanelNPC;
    private Text dialogText;
    private string _stringText;

    private void Awake()
    {
        int player = PlayerPrefs.GetInt("ObjetoElegido", 0);

        if (player == 0)
        {
            ShowAtifAttacks();
        }
        else if (player == 1)
        {
            ShowCharlieAttacks();
        }
        else
        {
            ShowAtifAttacks();
        }
    }

    private void Start()
    {
        PopulateShop();
        dialogText = dialogPanelNPC.GetComponentInChildren<Text>(); 
    }

    private void PopulateShop()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            ShopItem si = shopItems[i];
            GameObject itemObject = Instantiate(shopItemPrefab, shopContainer);

            itemObject.transform.GetChild(0).GetComponent<Image>().sprite= si.sprite;
            
            itemObject.transform.GetChild(1).GetComponent<Text>().text = si.itemName;
            
            itemObject.GetComponent<Button>().onClick.AddListener(()=>OnButtonClick(si));

        }
    }
    public void ShowAtifAttacks()
    {
        CharlieShop.SetActive(false);
        AtifShop.SetActive(true);
    }

    public void ShowCharlieAttacks()
    {
        CharlieShop.SetActive(true);
        AtifShop.SetActive(false);
    }

    private void OnButtonClick(ShopItem item)
    {
        
        if (item.cost < 100 & (item.cost/10)<=goldenCard.amount  & item.cost>=10)
        {
            goldenCard.amount = goldenCard.amount - (item.cost/10);
            ActivateItemBuyed(item);
        }
        else if ( item.cost>=100 & (item.cost/100)<=blackCard.amount)
        {
            blackCard.amount = blackCard.amount - (item.cost/100);
            ActivateItemBuyed(item);
        }
        else
        {
            _stringText = "You don't have enough cards.";
            StartCoroutine(ActivatePanel());
            //activar panel 
        }
        //comparar valor de tarjeta, tipo y el costo del producto
        //true= se agrega la funcionalidad en la batalla con bandera y restar amount
        //false = activar panel de no se puede comprar producto
    }

    void ActivateItemBuyed(ShopItem item)
    {
        switch (item.name)
        {
            case "Resetting":
                if (!shopData.resettingSold)
                {
                    shopData.resettingSold = true;
                    _stringText = "Sold!";
                    StartCoroutine(ActivatePanel());
                    scoreData.xp += 5;
                }
                else
                {
                    _stringText = "You have this item";
                    StartCoroutine(ActivatePanel());
                }
                break; 
                
            case "Heal":
                if (!shopData.healSold)
                {
                    shopData.healSold = true;
                    _stringText = "Sold!";
                    StartCoroutine(ActivatePanel());
                    scoreData.xp += 5;
                }
                else
                {
                    _stringText = "You have this item";
                    StartCoroutine(ActivatePanel());
                }
                break;
            case "Electroshock":
                if (!shopData.electroshockSold)
                {
                    shopData.electroshockSold = true;
                    _stringText = "Sold!";
                    StartCoroutine(ActivatePanel());
                    scoreData.xp += 5;
                }
                else
                {
                    _stringText = "You have this item";
                    StartCoroutine(ActivatePanel());
                }
                break;
            case "Delete":
                if (!shopData.deleteSold)
                {
                    shopData.deleteSold = true;
                    _stringText = "Sold!";
                    StartCoroutine(ActivatePanel());
                    scoreData.xp += 5;
                }
                else
                {
                    _stringText = "You have this item";
                    StartCoroutine(ActivatePanel());
                }
                break;
            case "ControlZ":
                if (!shopData.controlzSold)
                {
                    shopData.controlzSold = true;
                    _stringText = "Sold!";
                    StartCoroutine(ActivatePanel());
                    scoreData.xp += 5;
                }
                else
                {
                    _stringText = "You have this item";
                    StartCoroutine(ActivatePanel());
                }
                break;
            case "Update":
                if (!shopData.updateSold)
                {
                    shopData.updateSold = true;
                    _stringText = "Sold!";
                    StartCoroutine(ActivatePanel());
                    scoreData.xp += 5;
                }
                else
                {
                    _stringText = "You have this item";
                    StartCoroutine(ActivatePanel());
                }
                break;
            
        }
    }

    IEnumerator ActivatePanel()
    {
        dialogPanelNPC.SetActive(true);
        dialogText.text = _stringText;
        yield return new WaitForSeconds(2);
        dialogPanelNPC.SetActive(false);
    }
}
