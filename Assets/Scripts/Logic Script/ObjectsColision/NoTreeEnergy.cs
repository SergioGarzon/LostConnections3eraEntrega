using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTreeEnergy : MonoBehaviour
{
    private ActivatePanelGeneral activatePanel;
    private int language;
    private string textSend;


    void Start()
    {
        activatePanel = GameObject.Find("Canvas/TextBoxManager").GetComponent<ActivatePanelGeneral>();

        language = PlayerPrefs.GetInt("LenguajeGuardado", 0);

        if (language == 0)
            textSend = "This tree was destroyed! You can't charge energy right now.";
        else
            textSend = "¡Este árbol fue destruido! No puedes cargar energía en estos momentos.";

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NoTree"))
        {
            activatePanel.ActivatePanel();

            activatePanel.SetText(textSend);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NoTree"))
        {
            activatePanel.UnactivePanel();

            activatePanel.SetText("");
        }
    }
}
