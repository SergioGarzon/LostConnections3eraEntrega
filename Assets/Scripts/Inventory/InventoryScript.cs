using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript: MonoBehaviour
{
    [Header("List of the items sold")] 
    public InventoryItem[] inventoryItem;

    [Header("References")] 
    public Transform inventoryContainer;

    public GameObject cardItemPrefab;

    public string amount;

    public List<GameObject> prefabs;
    public GameObject panel;
    public Texture texturaEspanolAzul;
    public Texture texturaInglesAzul;
    public Texture textura2EspanolAzul;
    public Texture textura2InglesAzul;
    public Texture textura3EspanolAzul;
    public Texture textura3InglesAzul;
    public RawImage imagenAzul;
    
    public Texture texturaEspanolVerde;
    public Texture texturaInglesVerde;
    public Texture textura2EspanolVerde;
    public Texture textura2InglesVerde;
    public RawImage imagenVerde;
    
    public Texture texturaEspanolVioleta;
    public Texture texturaInglesVioleta;
    public RawImage imagenVioleta;


    private void Start()
    {
       PopulateShop();

    }
    

    public void PopulateShop()
    {
        for (int i = 0; i < inventoryItem.Length; i++)
        {
            InventoryItem si = inventoryItem[i];
            GameObject itemObject = Instantiate(cardItemPrefab, inventoryContainer);
            var controller = itemObject.GetComponent<ItemController>();
            controller.Load(si);
            prefabs.Insert(i, itemObject);
            itemObject.GetComponent<Button>().onClick.AddListener(()=>OnButtonClick(si));
        }
    }

    private void Update()
    {
    }


    public void LoadCards()
    {
        if (prefabs.Count != 0)
        {
            for (int i = 0; i < inventoryItem.Length; i++)
            {
                InventoryItem si = inventoryItem[i];
                GameObject itemObject = prefabs[i];
                var controller = itemObject.GetComponent<ItemController>();
                controller.Load(si);
            } 
        }
    }
   
    
    int i = 0;


    void OnButtonClick(InventoryItem item)
    { 

        if(panel.activeSelf ==true)
            panel.gameObject.SetActive(false);
        
        Debug.Log(item.name);
        
        if (this.VerificarLenguaje() == 0 && item.itemName=="Blue")
        {
            if (i == 0)
            {
                this.imagenAzul.texture = this.texturaInglesAzul;
                i++;
            }
            else if (i == 1)
            {
                this.imagenAzul.texture = this.textura2InglesAzul;
                i++;
            }
            else
            {
                this.imagenAzul.texture = this.textura3InglesAzul;
                i -= 2;
            }
            panel.gameObject.SetActive(true);
        }
        else if (item.itemName=="Blue")
        {
            if (i == 0)
            {
                this.imagenAzul.texture = this.texturaEspanolAzul;
                i++;
            }
            else if (i == 1)
            {
                this.imagenAzul.texture = this.textura2EspanolAzul;
                i++;
            }
            else
            {
                this.imagenAzul.texture = this.textura3EspanolAzul;
                i -= 2;
            }
            
            panel.gameObject.SetActive(true);
        }
        if (this.VerificarLenguaje() == 0 && item.itemName=="Green")
        {
            if (i == 0)
            {
                this.imagenVerde.texture = this.texturaInglesVerde;
                i++;
            }
            else 
            {
                this.imagenVerde.texture = this.textura2InglesVerde;
                Debug.Log("segunda fto");
                i--;
            }
            
            panel.gameObject.SetActive(true);
        }
        else if(item.itemName=="Green")
        {
            if (i == 0)
            {
                this.imagenVerde.texture = this.texturaEspanolVerde;
                i++;
            }
            else
            {
                this.imagenVerde.texture = this.textura2EspanolVerde;
                Debug.Log("segunda fto");
                i--;
            }
            
            panel.gameObject.SetActive(true);
            i++;
        }
        if (this.VerificarLenguaje() == 0 && item.itemName=="Violet")
        {
            this.imagenVioleta.texture = this.texturaInglesVioleta;
            panel.gameObject.SetActive(true);
        }
        else if ( item.itemName=="Violet")
        {
            this.imagenVioleta.texture = this.texturaEspanolVioleta;
            panel.gameObject.SetActive(true);
        }
        
    }
    private int VerificarLenguaje()
    {
        int valor = 0;

        if (PlayerPrefs.HasKey("LenguajeGuardado"))
            valor = PlayerPrefs.GetInt("LenguajeGuardado", 0);

        return valor;
    }
}