using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInventoryController : MonoBehaviour
{
    public GameObject AtifInventory;
    public GameObject CharlieInventory;
    public GameObject OptionsInventory;
    public Button _buttonBack;
    
    void Awake()
    {
        int player = PlayerPrefs.GetInt("ObjetoElegido",0);
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
            Debug.Log("Player no recibido");
        }
    }
    
    public void CloseInventory()
    {
        this.gameObject.SetActive(false);
        
    }

    public void ShowAtifAttacks()
    {
        AtifInventory.SetActive(true);
        CharlieInventory.SetActive(false);
        OptionsInventory.SetActive(false);
    }

    public void ShowCharlieAttacks()
    {
        AtifInventory.SetActive(false);
        CharlieInventory.SetActive(true);
        OptionsInventory.SetActive(false);
    }

    public void GoBackCharlieAtif()
    {
        AtifInventory.SetActive(false);
        CharlieInventory.SetActive(false);
        OptionsInventory.SetActive(true);
    }
}
