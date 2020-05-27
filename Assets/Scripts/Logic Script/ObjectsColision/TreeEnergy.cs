using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEnergy : MonoBehaviour
{

    private ActivatePanelGeneral activatePanel;
    private int language;
    private string textSend;


    void Start()
    {
        activatePanel = GameObject.Find("Canvas/TextBoxManager").GetComponent<ActivatePanelGeneral>();

        language = PlayerPrefs.GetInt("LenguajeGuardado", 0);

        if (language == 0)
            textSend = "PRESS KEY E, FOR CHARGE ENERGY";
        else
            textSend = "PRESIONA LA TECLA E PARA CARGAR ENERGIA";

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            activatePanel.ActivatePanel();

            activatePanel.SetText(textSend);

            if (Input.GetKey(KeyCode.E))
            {

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            activatePanel.UnactivePanel();

            activatePanel.SetText("");
        }
    }
}
