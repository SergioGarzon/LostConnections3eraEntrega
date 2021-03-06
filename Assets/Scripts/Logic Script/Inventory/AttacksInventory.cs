﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AttacksInventory: MonoBehaviour
{
    [Header("List of attacks")] 
    [SerializeField]private AttackItem[] inventoryItem;
    [SerializeField]private AttackItem[] selectedItem;

    [Header("References")] 
    [SerializeField] private Transform inventoryContainer;
    [SerializeField] private Transform attacksSelectedContainer;
    public ShopData shopData;
    public AttackItem CtrolZ;
    public AttackItem Reset;
    public AttackItem Delete;
    public AttackItem electroshock;
    public AttackItem heal;
    public AttackItem updating;
    public AttackItem superHit;
    public AttackItem canyon;
    public AttackItem scanner;
    public int isCharlie;

    [SerializeField]private GameObject cardItemPrefab;

    private GameObject currentGameObject;
    private int selectedGrid;
    private bool gridIsChoosed = false;
    private string updateNameinventary;
    private  string updateNameSelected;
    private GameObject boton1seleccionado;
    private GameObject boton2seleccionado;

    public static string attack1;
    public static string attack2;
    public static string attack3;


    //Ver esto de aca los saca a los ataques
    [Header("Flags")] 

    //Ataques de Charlie
    public static bool pixelSelected;
    public static bool stealSelected;
    public static bool bugSelected;
    public static bool controlZSelected;
    public static bool resetSelected;
    public static bool deleteSelected;
    

    //Ataques de Atif
    public static bool healSelected;
    public static bool updatingSelected;
    public static bool electroshockSelected;
    public static bool lightSelected;
    public static bool shockSelected;
    public static bool electricitySelected;
    
    public static bool superhitSelected;
    public static bool canyonSelected;
    public static bool scannerSelected;
    public static bool directattackSelected;
    public static bool ironfirstSelected;
    public static bool rechargeSelected;
    
    

    private void Start()
    {
        PopulateShop();
        PopulateAttacks();
        attack1 = selectedItem[0].itemName;
        attack2 = selectedItem[1].itemName;
        attack3 = selectedItem[2].itemName;
        UpdateFlags();
    }


    //Fijate si podes evitar esto
    public void Update()
    {
        if (isCharlie == 0)
        {
            if (shopData.controlzSold)
            {
                inventoryItem.Append(CtrolZ);
                GameObject itemObject = Instantiate(cardItemPrefab, inventoryContainer); 
                itemObject.transform.GetChild(0).GetComponent<Image>().sprite= CtrolZ.sprite;
                updateNameinventary=itemObject.transform.GetChild(1).GetComponent<Text>().text = CtrolZ.itemName;
                itemObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(CtrolZ, itemObject));
            }

            if (shopData.resettingSold)
            {
                inventoryItem.Append(Reset);
                GameObject itemObject = Instantiate(cardItemPrefab, inventoryContainer); 
                itemObject.transform.GetChild(0).GetComponent<Image>().sprite= Reset.sprite;
                updateNameinventary=itemObject.transform.GetChild(1).GetComponent<Text>().text = Reset.itemName;
                itemObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(Reset, itemObject));
            }

            if (shopData.deleteSold)
            {
                inventoryItem.Append(Delete);
                GameObject itemObject = Instantiate(cardItemPrefab, inventoryContainer); 
                itemObject.transform.GetChild(0).GetComponent<Image>().sprite= Delete.sprite;
                updateNameinventary=itemObject.transform.GetChild(1).GetComponent<Text>().text = Delete.itemName;
                itemObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(Delete, itemObject));
            }  
        }
        else if ( isCharlie == 1)
        {
            if (shopData.electroshockSold)
            {
                inventoryItem.Append(electroshock);
                GameObject itemObject = Instantiate(cardItemPrefab, inventoryContainer); 
                itemObject.transform.GetChild(0).GetComponent<Image>().sprite= electroshock.sprite;
                updateNameinventary=itemObject.transform.GetChild(1).GetComponent<Text>().text = electroshock.itemName;
                itemObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(electroshock, itemObject));
            }

            if (shopData.updateSold)
            {
                inventoryItem.Append(updating);
                GameObject itemObject = Instantiate(cardItemPrefab, inventoryContainer); 
                itemObject.transform.GetChild(0).GetComponent<Image>().sprite= updating.sprite;
                updateNameinventary=itemObject.transform.GetChild(1).GetComponent<Text>().text = updating.itemName;
                itemObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(updating, itemObject));
            }

            if (shopData.healSold)
            {
                inventoryItem.Append(heal);
                GameObject itemObject = Instantiate(cardItemPrefab, inventoryContainer); 
                itemObject.transform.GetChild(0).GetComponent<Image>().sprite= heal.sprite;
                updateNameinventary=itemObject.transform.GetChild(1).GetComponent<Text>().text = heal.itemName;
                itemObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(heal, itemObject));
            }
        }
        else if (isCharlie == 3)
        {
            if (shopData.superHitSold)
            {
                inventoryItem.Append(superHit);
                GameObject itemObject = Instantiate(cardItemPrefab, inventoryContainer); 
                itemObject.transform.GetChild(0).GetComponent<Image>().sprite= superHit.sprite;
                updateNameinventary=itemObject.transform.GetChild(1).GetComponent<Text>().text = superHit.itemName;
                itemObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(superHit, itemObject));
            }

            if (shopData.canyonSold)
            {
                inventoryItem.Append(canyon);
                GameObject itemObject = Instantiate(cardItemPrefab, inventoryContainer); 
                itemObject.transform.GetChild(0).GetComponent<Image>().sprite= canyon.sprite;
                updateNameinventary=itemObject.transform.GetChild(1).GetComponent<Text>().text = canyon.itemName;
                itemObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(canyon, itemObject));
            }

            if (shopData.healSold)
            {
                inventoryItem.Append(scanner);
                GameObject itemObject = Instantiate(cardItemPrefab, inventoryContainer); 
                itemObject.transform.GetChild(0).GetComponent<Image>().sprite= scanner.sprite;
                updateNameinventary=itemObject.transform.GetChild(1).GetComponent<Text>().text = scanner.itemName;
                itemObject.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(scanner, itemObject));
            }
        }
    }

    private void PopulateShop()
    {
        for (int i = 0; i < inventoryItem.Length; i++)
        {
            AttackItem si = inventoryItem[i];
            GameObject itemObject = Instantiate(cardItemPrefab, inventoryContainer);

            itemObject.transform.GetChild(0).GetComponent<Image>().sprite= si.sprite;
            
            updateNameinventary=itemObject.transform.GetChild(1).GetComponent<Text>().text = si.itemName;

            itemObject.GetComponent<Button>().onClick.AddListener(()=>OnButtonClick(si,itemObject));

        }
    }
    private void PopulateAttacks()
    {
        for (int i = 0; i < selectedItem.Length; i++)
        {
            AttackItem si = selectedItem[i];
            GameObject itemObject = Instantiate(cardItemPrefab, attacksSelectedContainer);

            itemObject.transform.GetChild(0).GetComponent<Image>().sprite= si.sprite;
            
            updateNameSelected=itemObject.transform.GetChild(1).GetComponent<Text>().text = si.itemName;

            itemObject.GetComponent<Button>().onClick.AddListener(()=>OnButtonSelectedAttackClick(si, itemObject));
        }
    }


    private void OnButtonClick(AttackItem item, GameObject gO)
    {
        if (gridIsChoosed)
        {
            boton2seleccionado = gO;
            //ataque en el inventario
            string nombre = item.itemName;
            int id = item.id;
            Sprite sprite = item.sprite;
            
            //ataque seleccionado
            string nombreSeleccionado = selectedItem[selectedGrid].itemName;
            Sprite spriteSeleccionado = selectedItem[selectedGrid].sprite;
            
            //paso datos del seleccionado al del inventario
            item.itemName = nombreSeleccionado;
            item.id = selectedGrid;
            item.sprite = spriteSeleccionado;
            updateNameinventary = item.name;
            
            //paso datos del inventario al seleccionado
            selectedItem[selectedGrid].itemName= nombre;
            selectedItem[selectedGrid].sprite = sprite;
            selectedItem[selectedGrid].id = id;
            updateNameSelected = nombre;

            gridIsChoosed = false;
            UpdatingData(boton1seleccionado,boton2seleccionado);
            UpdateFlags();
        }
        //Debug.Log(item.itemName);
    }

    bool ValidateAttacks()
    {
        bool[] list = new []{shopData.canyonSold, shopData.superHitSold, shopData.scannerSold, shopData.deleteSold, 
            shopData.electroshockSold, shopData.healSold, shopData.controlzSold, shopData.resettingSold, shopData.updateSold};
        foreach (var attack in list)
        {
            if (attack)
            {
                return true;
            }
        }
        return false;
    }

    void OnButtonSelectedAttackClick(AttackItem item, GameObject gO)
    {
        bool sold = ValidateAttacks();
        if (sold)
        {
            //Debug.Log(item.id);
            selectedGrid = item.id;
            gridIsChoosed = true;
            boton1seleccionado = gO;
            //Debug.Log(gO); 
        }
        
    }

    void UpdatingData(GameObject boton1, GameObject boton2)
    {
        Sprite sprite1= boton1.transform.GetChild(0).GetComponent<Image>().sprite;
        string name1 = boton1.transform.GetChild(1).GetComponent<Text>().text;
        
        Sprite sprite2=boton2.transform.GetChild(0).GetComponent<Image>().sprite;
        string name2 = boton2.transform.GetChild(1).GetComponent<Text>().text;


        boton1.transform.GetChild(0).GetComponent<Image>().sprite = sprite2;
        boton1.transform.GetChild(1).GetComponent<Text>().text = name2;
        boton2.transform.GetChild(0).GetComponent<Image>().sprite = sprite1;
        boton2.transform.GetChild(1).GetComponent<Text>().text = name1;
        
        //para enviar los nombres a la batalla
        attack1 = selectedItem[0].itemName;
        attack2 = selectedItem[1].itemName;
        attack3 = selectedItem[2].itemName;
        
    }

    void UpdateFlags()
    {

        if (attack1 == "Pixel" | attack2 == "Pixel" | attack3 == "Pixel")
        {
            pixelSelected = true;
        }
        else
        {
            pixelSelected = false;
        }
        if (attack1 == "Steal" | attack2 == "Steal" | attack3 == "Steal")
        {
            stealSelected = true;
        }
        else
        {
            stealSelected = false;
        }
        if (attack1 == "Bug" | attack2 == "Bug" | attack3 == "Bug")
        {
            bugSelected = true;
        }
        else
        {
            bugSelected = false;
        }
        if (attack1 == "Ctrl-Z" | attack2 == "Ctrl-Z" | attack3 == "Ctrl-Z")
        {
            controlZSelected = true;
        }
        else
        {
            controlZSelected = false;
        }
        if (attack1 == "Reset" | attack2 == "Reset" | attack3 == "Reset")
        {
            resetSelected = true;
        }
        else
        {
            resetSelected = false;
        }
        if (attack1 == "Delete" | attack2 == "Delete" | attack3 == "Delete")
        {
            deleteSelected = true;
        }
        else
        {
            deleteSelected = false;
        }
        if (attack1 == "Heal" | attack2 == "Heal" | attack3 == "Heal")
        {
            healSelected = true;
        }
        else
        {
            healSelected = false;
        }
        if (attack1 == "Update" | attack2 == "Update" | attack3 == "Update")
        {
            updatingSelected = true;
        }
        else
        {
            updatingSelected = false;
        }
        if (attack1 == "Electroshock" | attack2 == "Electroshock" | attack3 == "Electroshock")
        {
            electroshockSelected = true;
        }
        else
        {
            electroshockSelected = false;
        }
        if (attack1 == "Light" | attack2 == "Light" | attack3 == "Light")
        {
            lightSelected = true;
        }
        else
        {
            lightSelected = false;
        }
        if (attack1 == "Shock" | attack2 == "Shock" | attack3 == "Shock")
        {
            shockSelected = true;
        }
        else
        {
            shockSelected = false;
        }
        if (attack1 == "Electricty" | attack2 == "Electricity" | attack3 == "Electricity")
        {
            electricitySelected = true;
        }
        else
        {
            electricitySelected = false;
        }
        if (attack1 == "SuperHit" | attack2 == "SuperHit" | attack3 == "SuperHit")
        {
            superhitSelected = true;
        }
        else
        {
            superhitSelected = false;
        }
        if (attack1 == "Canyon" | attack2 == "Canyon" | attack3 == "Canyon")
        {
            canyonSelected = true;
        }
        else
        {
            canyonSelected = false;
        }
        if (attack1 == "Scanner" | attack2 == "Scanner" | attack3 == "Scanner")
        {
            scannerSelected = true;
        }
        else
        {
            scannerSelected = false;
        }
        if (attack1 == "Recharge" | attack2 == "Recharge" | attack3 == "Recharge")
        {
            rechargeSelected = true;
        }
        else
        {
            rechargeSelected = false;
        }
        if (attack1 == "IronFirst" | attack2 == "IronFirst" | attack3 == "IronFirst")
        {
            ironfirstSelected= true;
        }
        else
        {
            ironfirstSelected = false;
        }
        if (attack1 == "DirectAttack" | attack2 == "DirectAttack" | attack3 == "DirectAttack")
        {
            directattackSelected = true;
        }
        else
        {
            directattackSelected = false;
        }
    }
}