using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWorld : MonoBehaviour
{
    private ActivatePanelGeneral activatePanel;
    private int language;
    private string textSend;


    void Start()
    {
        activatePanel = GameObject.Find("Canvas/TextBoxManager").GetComponent<ActivatePanelGeneral>();

        language = PlayerPrefs.GetInt("LenguajeGuardado", 0);

        if (language == 0)
            textSend = "NO PUEDES INGRESAR POR AQUÍ";
        else
            textSend = "YOU CANNOT ENTER HERE";

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollisionWorld"))
        {
            activatePanel.ActivatePanel();
            activatePanel.SetText(textSend);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CollisionWorld"))
        {
            activatePanel.UnactivePanel();
            activatePanel.SetText("");
        }
    }
}
