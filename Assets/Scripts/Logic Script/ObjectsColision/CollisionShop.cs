using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CollisionShop : MonoBehaviour
{
    private ActivatePanelGeneral activatePanel;
    private int language;


    void Start()
    {
        activatePanel = GameObject.Find("Canvas/TextBoxManager").GetComponent<ActivatePanelGeneral>();
        language = PlayerPrefs.GetInt("LenguajeGuardado", 0);       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShopLevelArc2"))
        {
            activatePanel.ActivatePanel();
            activatePanel.SetText(ChangeString(2));
        }

        if (other.CompareTag("ShopLevelArc4"))
        {
            activatePanel.ActivatePanel();
            activatePanel.SetText(ChangeString(4));
        }

        if (other.CompareTag("ShopLevelArc7"))
        {
            activatePanel.ActivatePanel();
            activatePanel.SetText(ChangeString(7));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ShopLevelArc2") || other.CompareTag("ShopLevelArc4") || other.CompareTag("ShopLevelArc7"))
        {
            activatePanel.UnactivePanel();

            activatePanel.SetText("");
        }
    }

    private string ChangeString(int value)
    {
        string totalValue = "";

        if (language == 0)
            totalValue = "You can't enter this place until you reach level " + value;
        else
            totalValue = "No puedes ingresar a este espacio hasta llegar al nivel " + value;

        return totalValue;
    }


}
