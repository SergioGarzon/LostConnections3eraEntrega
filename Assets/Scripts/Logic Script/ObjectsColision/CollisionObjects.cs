using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObjects : MonoBehaviour
{

    public ActivatePanelGeneral activatePanel;
    public TextPanelInformation txtPanelInformation;
    private int language;


    void Awake()
    {
        activatePanel = GameObject.Find("Canvas/TextBoxManager").GetComponent<ActivatePanelGeneral>();
        language = PlayerPrefs.GetInt("LenguajeGuardado", 0);
    }


    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Tree": Value(1); activatePanel.ActivatePanel(); break;
            case "NoTree": Value(2); activatePanel.ActivatePanel(); break;
            case "Arcade":
                if (PlayerPrefs.GetInt("ArcadeGame") == 0)
                    Value(4);
                else
                {
                    Value(3);
                    activatePanel.ActivatePanel();
                }
                break;
            case "CollisionShop":
                if (PlayerPrefs.GetInt("TarjetaShop") == 0)
                {
                    Value(4);
                    activatePanel.ActivatePanel();
                }
                else
                    Destroy(other.gameObject);
                break;
            case "CollisionWorld": Value(5); activatePanel.ActivatePanel(); break;
            case "ShopLevelArc2": Value(6); activatePanel.ActivatePanel(); break;
            case "ShopLevelArc4": Value(7); activatePanel.ActivatePanel(); break;
            case "ShopLevelArc7": Value(8); activatePanel.ActivatePanel(); break;
        }

    }


    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Tree":
            case "NoTree":
            case "Arcade":
            case "CollisionShop":
            case "CollisionWorld":
            case "ShopLevelArc2":
            case "ShopLevelArc4":
            case "ShopLevelArc7":
                {
                    activatePanel.SetText("");
                    activatePanel.UnactivePanel();
                    break;
                }
        }
    }

    private void Value(int number)
    {
        if (language == 0)
            English(number);
        else
            Spanish(number);
    }

    private void Spanish(int number)
    {
        switch (number)
        {
            case 1: activatePanel.SetText(txtPanelInformation.treeSpanish); break;
            case 2: activatePanel.SetText(txtPanelInformation.noTreeSpanish); break;
            case 3: activatePanel.SetText(txtPanelInformation.noArcadeSpanish); break;
            case 4: activatePanel.SetText(txtPanelInformation.noAutorizeSpanish); break;
            case 5: activatePanel.SetText(txtPanelInformation.stopEnterSpanish); break;
            case 6: activatePanel.SetText(txtPanelInformation.shopArc2Spanish); break;
            case 7: activatePanel.SetText(txtPanelInformation.shopArc4Spanish); break;
            case 8: activatePanel.SetText(txtPanelInformation.shopArc7Spanish); break;

        }
    }

    private void English(int number)
    {
        switch (number)
        {
            case 1: activatePanel.SetText(txtPanelInformation.treeEnglish); break;
            case 2: activatePanel.SetText(txtPanelInformation.noTreeEnglish); break;
            case 3: activatePanel.SetText(txtPanelInformation.noArcadeEnglish); break;
            case 4: activatePanel.SetText(txtPanelInformation.noAutorizeEnglish); break;
            case 5: activatePanel.SetText(txtPanelInformation.stopEnterEnglish); break;
            case 6: activatePanel.SetText(txtPanelInformation.shopArc2English); break;
            case 7: activatePanel.SetText(txtPanelInformation.shopArc4English); break;
            case 8: activatePanel.SetText(txtPanelInformation.shopArc7English); break;
        }
    }

}
