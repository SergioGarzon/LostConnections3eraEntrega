using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CollisionObjects : MonoBehaviour
{

    public ActivatePanelGeneral activatePanel;
    public TextPanelInformation txtPanelInformation;
    public LifePlayer lifePlayer;

    private int language;
    private bool control;


    void Awake()
    {
        activatePanel = GameObject.Find("Canvas/TextBoxManager").GetComponent<ActivatePanelGeneral>();
        language = PlayerPrefs.GetInt("LenguajeGuardado", 0);


        control = false;
    }


    //Unicamente para este caso lo pongo
    private void Update()
    {
        if(control)
        {
            if (Input.GetKey(KeyCode.E))
            {
                lifePlayer.hpPlayerOne = 100;
                lifePlayer.manaPlayerOne = 100;

                //Esto de abajo hay que sacarlo ya que es un solo player en la escena
                lifePlayer.hpPlayerTwo = 100;
                lifePlayer.manaPlayerTwo = 100;
                lifePlayer.hpPlayerThree = 100;
                lifePlayer.manaPlayerThree = 100;

                Value(9);
                control = false;                
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Tree":
                {
                    Value(1); 
                    activatePanel.ActivatePanel();
                    control = true;
                }
                break;
            case "NoTree": 
                Value(2); 
                activatePanel.ActivatePanel(); 
                break;
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
                {
                    Destroy(other.gameObject);
                }                    
                break;
            case "CollisionWorld": Value(5); activatePanel.ActivatePanel(); break;
            case "ShopLevelArc2": Value(6); activatePanel.ActivatePanel(); break;
            case "ShopLevelArc4": Value(7); activatePanel.ActivatePanel(); break;
            case "ShopLevelArc7": Value(8); activatePanel.ActivatePanel(); break;
            case "Panal":
                if (PlayerPrefs.GetInt("TarjetaPanal", 0) == 0)
                {
                    Value(4);
                    activatePanel.ActivatePanel();
                }                    
                else
                {
                    SavePosition.cargarPosicionInicial = 2;
                    SceneManager.LoadScene("BattleScene");
                }                    
                break;
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
            case "Panal":
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
            case 9: activatePanel.SetText(txtPanelInformation.energyChargedSpanish); break;            

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
            case 9: activatePanel.SetText(txtPanelInformation.energyChargedEnglish); break;
        }
    }


}
